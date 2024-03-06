using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

//using System.Web.Script.Serialization;

namespace ConHIS
{
    /// <summary>
    /// HL7Message is a tool for constructing, editing or accessing elements of an HL7 message file.
    /// This class wraps functionality around the more primitive HL7Segments collection class, which
    /// was originally created specifically for use by the treeview based editor.
    /// The HL7Message wrapper is provided as a helper class to be used in macro scripts, so methods
    /// and interfaces should use basic types suitable for public COM access and use in JavaScript.
    /// In the script env window.external.CurrentHL7 and the method window.external.NewHL7()
    /// both return one of these objects.
    /// </summary>
    [ComVisibleAttribute(true)]
    public class HL7Message
    {
        private HL7Segments mSegmentCollection;

        /// <summary>
        /// Constructor
        /// </summary>
        public HL7Message()
        {
            mSegmentCollection = new HL7Segments();
        }

        /// <summary>
        /// Constructor, loading segments collection from the given segments set
        /// </summary>
        /// <param name="newMessage"></param>
        public HL7Message(HL7Segments newMessage)
        {
            this.LoadSegments(newMessage);
        }

        /// <summary>
        /// Load an HL7 message from a string, into the segments collection.
        /// </summary>
        /// <param name="newMessage">Source HL7 message to be parsed</param>
        public void LoadHL7(string newMessage)
        {
            mSegmentCollection = new HL7Segments();
            mSegmentCollection.LoadHL7Message(newMessage);
        }

        /// <summary>
        /// Load an HL7 message from a segments collection.
        /// </summary>
        /// <param name="newCollection">Source segment collection to be copied</param>
        public void LoadSegments(HL7Segments newCollection)
        {
            mSegmentCollection = new HL7Segments();
            mSegmentCollection.SegmentArray.AddRange(newCollection.SegmentArray.ToArray());
        }

        /// <summary>
        /// Retrieve the complete HL7 message, as it would be written to file.
        /// </summary>
        /// <returns>The full HL7 message</returns>
        public override string ToString()
        {
            // return string.Join("\r", mSegmentCollection);
            return mSegmentCollection.ToString().Replace("\r", "\r\n");
        }

        /// <summary>
        /// Count segments in the message
        /// </summary>
        /// <returns>Total number of segments</returns>
        public int SegmentCount()
        {
            return mSegmentCollection.SegmentArray.Count;
        }

        /// <summary>
        /// Count the segments of a specific type in the message.
        /// </summary>
        /// <param name="segmentType">The segment type to count</param>
        /// <returns>Number of matching segments found</returns>
        public int TypeCount(string segmentType)
        {
            if (string.IsNullOrEmpty(segmentType))
                return 0;
            int segCount = 0;
            string rowType;
            foreach (string row in mSegmentCollection.SegmentArray)
            {
                rowType = row.Substring(0, row.IndexOf("|"));
                if (rowType.Equals(segmentType, StringComparison.InvariantCultureIgnoreCase))
                    segCount += 1;
            }
            return segCount;
        }

        /// <summary>
        /// Return the index position of the nth instance of the segment of the specified type-code.
        /// Example: if there is more than 1 "PID" in the message, FindSegment("PID",2) will return
        /// the position of the second instance.
        /// Returns -1 if instance specified does not exist.
        /// </summary>
        /// <param name="segmentType">Segment type-code to locate</param>
        /// <param name="segmentInstance">1-based instance to retrieve</param>
        /// <returns>The index position in the segments collection</returns>
        public int FindSegment(string segmentType, int segmentInstance)
        {
            if (segmentInstance < 1 || segmentInstance > mSegmentCollection.SegmentArray.Count)
                return -1;

            // No type specified, return segment at requested position
            if (string.IsNullOrEmpty(segmentType))
                return -1;

            int instanceOfSeg = 0;
            string rowType;
            string row;
            for (int segIdx = 0; segIdx < mSegmentCollection.SegmentArray.Count; segIdx++)
            {
                row = (string)mSegmentCollection.SegmentArray[segIdx];
                rowType = row.Substring(0, row.IndexOf("|"));
                if (rowType.Equals(segmentType, StringComparison.InvariantCultureIgnoreCase))
                {
                    instanceOfSeg += 1;
                    if (instanceOfSeg == segmentInstance)
                        return segIdx;
                }
            }
            return -1;
        }

        /// <summary>
        /// Retrieve a segment in string format
        /// </summary>
        /// <param name="segmentIndex">0-based index position in the segment collection</param>
        /// <returns></returns>
        public string GetSegment(int segmentIndex)
        {
            if (segmentIndex < 0 || segmentIndex >= mSegmentCollection.SegmentArray.Count)
                return "";

            return (string)mSegmentCollection.SegmentArray[segmentIndex];
        }

        /// <summary>
        /// Retrieve a field in string format
        /// </summary>
        /// <param name="segmentIndex">0-based index position in the segment collection</param>
        /// <param name="fieldIndex">0-based field position in the specified segment</param>
        /// <returns>The complete field contents in string format</returns>
        public string GetField(int segmentIndex, int fieldIndex)
        {
            string segString = this.GetSegment(segmentIndex);
            if (string.IsNullOrEmpty(segString))
                return "";

            if (segString.StartsWith("MSH|", StringComparison.InvariantCultureIgnoreCase))
                segString = segString.Substring(0, 3) + "|<field-marker>" + segString.Substring(3);

            string[] segFields = segString.Split('|');
            if (fieldIndex < 0 || fieldIndex >= segFields.Length)
                return "";

            return segFields[fieldIndex];
        }

        /// <summary>
        /// Retrieve a field as a JSON object. This will contain a variable number of elements:
        /// { 'repeats' : 1,			// the number of fields seperated by a repeat-marker or zero if the field is empty, 1 if no repeat-marker is present
        ///   'fields' : [				// array of fields, only one element if there was no repeat-marker in the field
        /// 		[components], 		// For each field, a string array of the components
        /// 		[components] etc...
        ///              ]
        /// }
        /// </summary>
        /// <param name="segmentIndex">0-based index position in the segment collection</param>
        /// <param name="fieldIndex">0-based field position in the specified segment</param>
        /// <returns>The field contents in a JSON object declaration</returns>
        public string GetFieldJSON(int segmentIndex, int fieldIndex)
        {
            string fldString = this.GetField(segmentIndex, fieldIndex);
            StructJSONField fieldStruct = new StructJSONField
            {
                repeats = 0
            };
            if (!string.IsNullOrEmpty(fldString))
            {
                if (fldString.StartsWith("MSH|", StringComparison.InvariantCultureIgnoreCase))
                    fldString = fldString.Substring(0, 3) + "|<field-marker>" + fldString.Substring(3);

                string[] rptFields = fldString.Split('~');
                fieldStruct.repeats = rptFields.Length;
                List<string[]> comps = new List<string[]>();
                foreach (string fld in rptFields)
                {
                    comps.Add((string[])fld.Split('^'));
                }
                fieldStruct.fields = comps.ToArray();
            }
            //JavaScriptSerializer ser = new JavaScriptSerializer();
            //string json = ser.Serialize(fieldStruct);
            // Don't know how wise this is but this inserts a ToString function into the JSON object
            //string fn = ", ToString:function(){if(this.fields==null||this.fields.length <1){return '';}var cmps=new Array(); for(idx=0; idx < this.fields.length; idx++){cmps.push(this.fields[idx].join(\"^\"));} return cmps.join(\"~\");}";
            //int idx = json.LastIndexOf("}");
            //json = json.Insert(idx, fn);
            string json = "";
            return json;
        }

        /// <summary>
        /// Replace the entire contents at the specified segment position.
        /// </summary>
        /// <param name="segmentIndex">0-based index position in the segment collection</param>
        /// <param name="segmentValue">The new segment value</param>
        /// <returns>True on success</returns>
        public bool SetSegment(int segmentIndex, string segmentValue)
        {
            if (segmentIndex < 0 || segmentIndex >= mSegmentCollection.SegmentArray.Count)
                return false;
            mSegmentCollection.SegmentArray[segmentIndex] = segmentValue;
            return true;
        }

        /// <summary>
        /// Replace contents of the field at the specified position in the specified segment.
        /// If the segment index is out of bounds it fails and returns False.
        /// </summary>
        /// <param name="segmentIndex">0-based index position in the segment collection</param>
        /// <param name="fieldIndex">0-based field position in the specified segment</param>
        /// <param name="fieldValue">New field value, or empty string</param>
        /// <returns>True on success else False</returns>
        public bool SetField(int segmentIndex, int fieldIndex, string fieldValue)
        {
            if (segmentIndex < 0 || segmentIndex >= mSegmentCollection.SegmentArray.Count)
                return false;       // should prolly throw an exception - let macro exception handler take this?
            if (fieldIndex < 0)
                return false;

            /* MSH fix
			string segString = this.GetSegment(segmentIndex);
			if (string.IsNullOrEmpty(segString))
				return "";

			if (segString.StartsWith("MSH|",StringComparison.InvariantCultureIgnoreCase))
				segString = segString.Substring(0,3) + "|<field-marker>" + segString.Substring(3);

			string[] segFields = segString.Split('|');
			*/
            string segString = (string)mSegmentCollection.SegmentArray[segmentIndex];
            if (segString.StartsWith("MSH|", StringComparison.InvariantCultureIgnoreCase))
                segString = segString.Substring(0, 3) + "|<field-marker>" + segString.Substring(3);

            string[] fieldList = (segString).Split('|');
            if (fieldIndex < fieldList.Length)
            {
                fieldList[fieldIndex] = fieldValue;
            }
            else
            {
                // extend number of fields in the segment
                List<string> newSegList = new List<string>(fieldList);
                while (newSegList.Count < fieldIndex)
                {
                    newSegList.Add("");
                }
                newSegList[fieldIndex] = fieldValue;
                fieldList = (string[])newSegList.ToArray();
            }

            segString = string.Join("|", fieldList);
            if (segString.StartsWith("MSH|<field-marker>|", StringComparison.InvariantCultureIgnoreCase))
                segString = segString.Replace("<field-marker>|", "");

            mSegmentCollection.SegmentArray[segmentIndex] = segString;
            return true;
        }

        /// <summary>
        /// Insert a new segment at the specified position.
        /// If the segment index is greater than the number of existing segments, or = -1,
        /// then the new segment will be appended to the end of the message.
        /// </summary>
        /// <param name="segmentIndex">0-based index position in the segment collection</param>
        /// <param name="segmentValue">The new segment value</param>
        /// <returns>True on success</returns>
        public bool InsertSegment(int segmentIndex, string segmentValue)
        {
            // TODO: validate the segment value? maybe require at least a segment-type code?
            if (segmentIndex < 0 || segmentIndex >= mSegmentCollection.SegmentArray.Count)
            {
                mSegmentCollection.SegmentArray.Add(segmentValue);
                return true;
            }
            else
            {
                if (segmentValue.Contains("\r") || segmentValue.Contains("\n"))
                {
                    Console.WriteLine("multiple-segment insertion");
                    segmentValue = segmentValue.Replace("\r\n", "\r").Replace("\n", "\r");
                    string[] segGroup = segmentValue.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    int offset = 0;
                    for (int idx = 0; idx < segGroup.Length; idx++)
                    {
                        if (!string.IsNullOrEmpty(segGroup[idx].Trim()))
                        {
                            mSegmentCollection.SegmentArray.Insert(segmentIndex + offset, segGroup[idx]);
                            offset++;
                        }
                    }
                }
                else
                    mSegmentCollection.SegmentArray.Insert(segmentIndex, segmentValue);
                return true;
            }
        }

        /// <summary>
        /// Delete the specified segment from the segments collection.
        /// </summary>
        /// <param name="segmentIndex">0-based index position in the segment collection</param>
        /// <returns>True on success</returns>
        public bool DeleteSegment(int segmentIndex)
        {
            if (segmentIndex < 0 || segmentIndex >= mSegmentCollection.SegmentArray.Count)
                return false;
            mSegmentCollection.SegmentArray.RemoveAt(segmentIndex);
            return true;
        }

        /// <summary>
        /// Get a unique key for updating or creating a message with a unique control-id or
        /// order number etc.  If the key type is set to "guid" it will return a freshly ground
        /// guid, otherwise it will return a timestamp in the format "yyyyMMddHHmmssffff".
        /// </summary>
        /// <param name="keyType">Either "guid" or "timestamp"(or anything else)</param>
        /// <returns>A relatively unique key</returns>
        public string GetUniqueKey(string keyType)
        {
            if (string.Equals(keyType, "guid", StringComparison.OrdinalIgnoreCase))
                return Guid.NewGuid().ToString();
            else
                return DateTime.Now.ToString("yyyyMMddHHmmssffff");     // only unique for low-volume and slow processes
        }
    }//class HL7Message

    internal class StructJSONField
    {
        public int repeats;
        public object[] fields;
    }
}//namespace QuickViewHL7