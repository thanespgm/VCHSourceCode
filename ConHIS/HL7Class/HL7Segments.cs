using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace ConHIS
{
    /// <summary>
    /// HL7Segments is a collection of segments from a HL7 message file,
    /// with methods for accessing and updating parts of the message.
    /// </summary>
    public class HL7Segments
    {
        private ArrayList mSegments;

        public HL7Segments()
        {
            mSegments = new ArrayList();
        }

        /// <summary>
        /// Direct access to the arraylist containing the message segments
        /// </summary>
        public ArrayList SegmentArray
        {
            get { return mSegments; }
            set { mSegments = value; }
        }

        public int LoadFile(string filePath)
        {
            mSegments = new ArrayList();

            FileInfo filHL7 = new FileInfo(filePath);
            if (!filHL7.Exists)
            {
                MessageBox.Show("File not found (" + filePath + ")");
                return 0;
            }

            try
            {
                string msg;
                using (StreamReader strHL7 = filHL7.OpenText())
                {
                    msg = strHL7.ReadToEnd();
                }
                LoadHL7Message(msg);
            }
            catch (IOException e)
            {
                MessageBox.Show("File error:\r\n" + e.Message);
            }
            catch (ApplicationException e)
            {
                MessageBox.Show("File error:\r\n" + e.Message);
            }
            return mSegments.Count;
        }

        public int LoadHL7Message(string rawMessage)
        {
            mSegments = new ArrayList();
            if (string.IsNullOrEmpty(rawMessage))
                return 0;
            rawMessage = rawMessage.Replace("\r\n", "\r").Replace("\n", "\r");      // TODO move this into the Split call?
            string[] rows = rawMessage.Split(new string[] { "\r" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string row in rows)
            {
                string seg = row.Trim();
                // Assumption: a valid HL7 segment has a segment type code followed by at least one field-delimiter, e.g. "NTE|"
                if ((seg.Length > 3) && (seg.IndexOf('|') > 2))
                    mSegments.Add(seg);
            }
            return mSegments.Count;
        }

        /// <summary>
        /// Method to save the current segments collection to a file
        /// </summary>
        /// <param name="savePath">Full path name of the file to be written</param>
        /// <returns>True if no exceptions were raised</returns>
        public bool SaveFile(string savePath)
        {
            try
            {
                FileInfo filHL7 = new FileInfo(savePath);
                if (filHL7.Exists)
                    filHL7.Delete();
                StreamWriter strHL7 = new StreamWriter(filHL7.OpenWrite());
                foreach (string strSeg in mSegments)
                {
                    strHL7.WriteLine(strSeg);
                }
                strHL7.Close();
                return true;
            }
            catch (ApplicationException e)
            {
                //TextExpcetionLogs("Application error:\r\n" + e.Message);
                MessageBox.Show("Application error:\r\n" + e.Message, "Cannot save file");
            }
            return false;
        }

        /// <summary>
        /// Put the full HL7 message back together from the segment collection
        /// </summary>
        /// <returns>The HL7 message in text format</returns>
        public override string ToString()
        {
            return string.Join("\r", mSegments.ToArray());
        }

        /// <summary>
        /// Return an array containing the fields in the specified segment.
        /// Throws exception if index is out of range.
        /// </summary>
        /// <param name="segIndex">The segment to retrieve fields from</param>
        /// <returns>The fields in the specified segment</returns>
        private ArrayList GetSegmentArray(int segIndex)
        {
            if (segIndex >= 0 && segIndex < mSegments.Count)
            {
                ArrayList fieldArray = new ArrayList(((string)mSegments[segIndex]).Split('|'));
                return fieldArray;
            }
            else
                throw new IndexOutOfRangeException(string.Format("Segment index ({0}) is out of range.", segIndex.ToString()));
        }

        /// <summary>
        /// Return the segment type-code
        /// </summary>
        /// <param name="segIndex"></param>
        /// <returns></returns>
        public string GetSegmentType(int segIndex)
        {
            ArrayList fieldArr = GetSegmentArray(segIndex);
            return (string)fieldArr[0];
        }

        /// <summary>
        /// Return a string containing the element defined in the HL7Index
        /// </summary>
        /// <param name="elmIndex">HL7Index indicating the element to retrieve</param>
        /// <returns>The segment, field or component reqested</returns>
        public string GetElement(HL7Index elmIndex)
        {
            int fieldIdx = elmIndex.FieldIdx;

            if (fieldIdx < 0)
            {
                if (elmIndex.SegmentIdx > -1 && elmIndex.SegmentIdx < mSegments.Count)
                    return (string)mSegments[elmIndex.SegmentIdx];
                else
                    return "";
            }
            ArrayList segArr = GetSegmentArray(elmIndex.SegmentIdx);

            if ((string)segArr[0] == "MSH")
            {
                /* Don't give access to the field-mark or message-delimiters,
				 * just return empty string.
				 * Otherwise, step the field-index back by one as the raw data
				 * for the MSH is out by 1 position because of the field-marker field
				 */
                if (fieldIdx > 0 && fieldIdx < 3)
                    return "";
                if (fieldIdx > 2)
                    fieldIdx--;
            }

            if (fieldIdx >= segArr.Count)
                return "";
            string fldFull = (string)segArr[fieldIdx];
            string[] rpts = fldFull.Split('~');
            if (elmIndex.RepeatIdx > rpts.Length)
                return "";
            if (elmIndex.ComponentIdx > -1)
            {   // Return the component from the position specified
                string fld;
                if (elmIndex.RepeatIdx < 0)
                    fld = rpts[0];
                else
                    fld = rpts[elmIndex.RepeatIdx];
                string[] cmps = fld.Split('^');
                if (elmIndex.ComponentIdx < cmps.Length)
                    return cmps[elmIndex.ComponentIdx];
                else
                    return "";
            }
            else
            {   // Field or field-repeat - if RepeatIdx = -1 return the whole
                // field, otherwise only return the specified repeat-item
                if (elmIndex.RepeatIdx < 0)
                    return fldFull;
                else
                {
                    if (elmIndex.RepeatIdx < rpts.Length)
                        return rpts[elmIndex.RepeatIdx];
                    else
                        return "";
                }
            }
        }

        /// <summary>
        /// Method to remove a segment from the collection
        /// </summary>
        /// <param name="elmIndex"></param>
        /// <returns></returns>
        public bool RemoveSegment(HL7Index elmIndex)
        {
            if (elmIndex.SegmentIdx > -1 && elmIndex.SegmentIdx < mSegments.Count)
            {
                mSegments.RemoveAt(elmIndex.SegmentIdx);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Insert a segment into the message, or append it to the end.
        /// If insertIndex is less than zero or greater than array size then
        /// the segment will be appended to end of the message array.
        /// </summary>
        /// <param name="insertIndex">Index in the message array to insert at, or -1 to append</param>
        /// <param name="newSegment">The new segment value</param>
        /// <returns></returns>
        public int InsertSegment(int insertIndex, string newSegment)
        {
            newSegment = newSegment.Replace("\r", "").Replace("\n", "");
            if (insertIndex < 0 || insertIndex >= mSegments.Count)
            {
                mSegments.Add(newSegment);
                return mSegments.Count - 1;
            }
            else
            {
                mSegments.Insert(insertIndex, newSegment);
                return insertIndex;
            }
        }

        /// <summary>
        /// Update the element defined by the HL7Index
        /// e.g. entire segment, field or component, or repeat-field
        /// assumption: new value may contain component,field or repeat markers
        /// in the new value, but not segment markers (cr and/or lf)
        /// </summary>
        /// <param name="elmIndex"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public string UpdateElement(HL7Index elmIndex, string newValue)
        {
            int segIndex = elmIndex.SegmentIdx;
            if (segIndex >= 0 && segIndex < mSegments.Count)
            {
                newValue = newValue.Replace("\r", "");
                newValue = newValue.Replace("\n", "");
                // TODO any other validation or hl7-encoding

                int fieldIdx = elmIndex.FieldIdx;

                if (fieldIdx < 0)
                {
                    // update the segment
                    mSegments[segIndex] = newValue;
                }
                else
                {
                    // update field or component, possibly with repeat-groups
                    ArrayList segArr = GetSegmentArray(segIndex);
                    if ((string)segArr[0] == "MSH")
                    {
                        /* Don't update the field-mark or message-delimiters.
						 * For other fields, step the field-index back by one as the raw data
						 * for the MSH is out by 1 position because of the field-marker field
						 * Note: will get messy if user edits MSH-0 and inserts field-markers
						 */
                        if (fieldIdx > 0 && fieldIdx < 3)
                            return "";
                        if (fieldIdx > 2)
                            fieldIdx--;
                    }

                    if (fieldIdx < segArr.Count)
                    {
                        if (elmIndex.RepeatIdx < 0 && elmIndex.ComponentIdx < 0)
                        {
                            // just update the field
                            segArr[fieldIdx] = newValue;
                        }
                        else
                        {
                            // update a component value, which may be in a repeat-field position
                            string fld = (string)segArr[fieldIdx];

                            if (elmIndex.RepeatIdx > -1)
                            {
                                // update a repeat-field position
                                string[] rpts = fld.Split('~');
                                int rIdx = elmIndex.RepeatIdx;
                                if (rIdx < rpts.Length)
                                {
                                    if (elmIndex.ComponentIdx > -1)
                                    {
                                        // update a component value within the repeat-field
                                        string[] cmp = ((string)rpts[rIdx]).Split('^');
                                        if (cmp.Length > elmIndex.ComponentIdx)
                                        {
                                            cmp[elmIndex.ComponentIdx] = newValue;
                                            rpts[rIdx] = string.Join("^", cmp);
                                        }
                                        else
                                        {
                                            throw new IndexOutOfRangeException(string.Format("Component index ({0}) is out of range.", elmIndex.ToString()));
                                        }
                                    }
                                    else
                                    {
                                        // update the whole repeat-field value
                                        rpts[rIdx] = newValue;
                                    }
                                    segArr[fieldIdx] = string.Join("~", rpts);
                                }
                                else
                                    throw new IndexOutOfRangeException(string.Format("Field-repeat index ({0}) is out of range.", elmIndex.ToString()));
                            }
                            else
                            {
                                // update a component value - not in a repeat-field
                                string[] cmp = fld.Split('^');
                                if (cmp.Length > elmIndex.ComponentIdx)
                                {
                                    cmp[elmIndex.ComponentIdx] = newValue;
                                    segArr[fieldIdx] = string.Join("^", cmp);
                                }
                                else
                                {
                                    throw new IndexOutOfRangeException(string.Format("Component index ({0}) is out of range.", elmIndex.ToString()));
                                }
                            }
                        }// update component or repeat-field

                        // now put the updated segment back together in the segments-collection
                        string[] seg2 = (string[])segArr.ToArray("".GetType());
                        //assumption: user may have inserted component,field or repeat markers in the edited value
                        mSegments[segIndex] = string.Join("|", seg2);
                    }
                    else
                        throw new IndexOutOfRangeException(string.Format("Field index ({0}) is out of range.", elmIndex.ToString()));
                }//update field, component or repeat-field
            }
            else
                throw new IndexOutOfRangeException(string.Format("Segment index ({0}) is out of range.", segIndex.ToString()));

            return "";
        }//UpdateElement()

        /// <summary>
        /// Return the number of fields in the specified segment
        /// </summary>
        /// <param name="segIndex"></param>
        /// <returns></returns>
        public int FieldCount(int segIndex)
        {
            ArrayList fieldArr = GetSegmentArray(segIndex);
            return fieldArr.Count;
        }

        /// <summary>
        /// Return the number of repeat-values in the specified field
        /// </summary>
        /// <param name="elmIndex"></param>
        /// <returns></returns>
        public int RepeatCount(HL7Index elmIndex)
        {
            ArrayList segArr = GetSegmentArray(elmIndex.SegmentIdx);
            if (elmIndex.FieldIdx > -1 && elmIndex.FieldIdx < segArr.Count)
            {
                string fld = (string)segArr[elmIndex.FieldIdx];
                string[] rpts = fld.Split('~');
                return rpts.Length;
            }
            else
                throw new IndexOutOfRangeException(string.Format("Field index ({0}) is out of range.", elmIndex.ToString()));
        }

        /// <summary>
        /// Return the number of components in the specified field
        /// and optional repeat-value (defaults to first repeat-value,
        /// or the whole field if there are no repeats)
        /// </summary>
        /// <param name="elmIndex">HL7Index</param>
        /// <returns>Number of components</returns>
        public int ComponentCount(HL7Index elmIndex)
        {
            ArrayList segArr = GetSegmentArray(elmIndex.SegmentIdx);
            if ("MSH" == (string)segArr[0])
            {
                // bit of a cludge again
                string rawMSH = (string)mSegments[elmIndex.SegmentIdx];
                string part2 = "";
                int field2Pos = rawMSH.IndexOf("|", 5);
                if (field2Pos > -1)
                    part2 = rawMSH.Substring(field2Pos + 1);
                rawMSH = "MSH|<field-mark>|<encoding-chars>|" + part2;
                segArr = new ArrayList(rawMSH.Split('|'));
            }

            if (elmIndex.FieldIdx > -1 && elmIndex.FieldIdx < segArr.Count)
            {
                string fld = (string)segArr[elmIndex.FieldIdx];
                string[] rpts = fld.Split('~');
                int rIdx = elmIndex.RepeatIdx;
                if (rIdx < 0)
                    rIdx = 0;
                if (rIdx < rpts.Length)
                {
                    string[] flds = rpts[rIdx].Split('^');
                    return flds.Length;
                }
                else
                    throw new IndexOutOfRangeException(string.Format("Field-repeat index ({0}) is out of range.", elmIndex.ToString()));
            }
            else
                throw new IndexOutOfRangeException(string.Format("Field index ({0}) is out of range.", elmIndex.ToString()));
        }
    }
}