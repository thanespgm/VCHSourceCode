using System;
using System.Runtime.InteropServices;

namespace ConHIS
{
    /// <summary>
    /// Enumerated types of nodes used in tree view
    /// </summary>
    public enum HL7NodeType
    {
        /// <summary>
        /// Node represents a full segment
        /// </summary>
        HL7Segment,

        /// <summary>
        /// Node represents a field
        /// </summary>
        HL7Field,

        /// <summary>
        /// Node represents a component
        /// </summary>
        HL7Component,

        /// <summary>
        /// Virtual node representing a group of repeating values in a field
        /// </summary>
        HL7RepeatGrouper
    };

    [ComVisibleAttribute(true)]
    public struct HL7Index
    {
        /// <summary>
        /// Segment index
        /// </summary>
        public int SegmentIdx;

        /// <summary>
        /// Field index within a segment
        /// </summary>
        public int FieldIdx;

        /// <summary>
        /// Component index within a field
        /// </summary>
        public int ComponentIdx;

        /// <summary>
        /// Repeat index of a field, if it is multi-valued
        /// </summary>
        public int RepeatIdx;

        /// <summary>
        /// Constructor, setting initial property values
        /// </summary>
        /// <param name="seg">Segment index</param>
        /// <param name="fld">Field index</param>
        /// <param name="cmp">Component index</param>
        /// <param name="rpt">Repeat index</param>
        public HL7Index(int seg, int fld, int cmp, int rpt)
        {
            this.SegmentIdx = seg;
            this.FieldIdx = fld;
            this.ComponentIdx = cmp;
            this.RepeatIdx = rpt;
        }

        /// <summary>
        /// Property indicating if the current value contains a repeat marker
        /// </summary>
        /// <returns></returns>
        public bool InRepeatGroup()
        {
            return RepeatIdx > 0;
        }

        /// <summary>
        /// Public method to set property values
        /// </summary>
        /// <param name="seg"></param>
        /// <param name="fld"></param>
        /// <param name="cmp"></param>
        /// <param name="rpt"></param>
        public void SetData(int seg, int fld, int cmp, int rpt)
        {
            this.SegmentIdx = seg;
            this.FieldIdx = fld;
            this.ComponentIdx = cmp;
            this.RepeatIdx = rpt;
        }

        /// <summary>
        /// Render a displayable string representing the current indices
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string indexSummary = this.SegmentIdx.ToString();
            if (this.FieldIdx > -1)
            {
                indexSummary = indexSummary + "." + (this.FieldIdx + 1).ToString();
                if (this.RepeatIdx > -1)
                    indexSummary = string.Format("{0}(r{1})", indexSummary, this.RepeatIdx);
                if (this.ComponentIdx > -1)
                    indexSummary = indexSummary + "." + this.ComponentIdx.ToString();
            }
            return indexSummary;
        }
    }

    public class HL7NodeInfo
    {
        // public string KeyValue;
        // public string RawData;
        /// <summary>
        /// Message index
        /// </summary>
        public HL7Index MsgIndex;

        /// <summary>
        /// Node type
        /// </summary>
        public HL7NodeType NodeType;

        /// <summary>
        /// Segment type code
        /// </summary>
        public string SegmentType;

        /// <summary>
        /// Number of elements
        /// </summary>
        public int ElementCount;

        /// <summary>
        /// Constructor, properties set to default values
        /// </summary>
        public HL7NodeInfo() :
            this(HL7NodeType.HL7Segment, "", -1, -1, -1, -1)
        { }

        /// <summary>
        /// Constructor, properties are set to given values
        /// </summary>
        /// <param name="NodeType"></param>
        /// <param name="SegmentType"></param>
        public HL7NodeInfo(HL7NodeType NodeType, string SegmentType) :
            this(NodeType, SegmentType, -1, -1, -1, -1)
        { }

        /// <summary>
        /// Constructor, properties are set to given values
        /// </summary>
        /// <param name="NodeType"></param>
        /// <param name="SegmentType"></param>
        /// <param name="SegmentIndex"></param>
        /// <param name="FieldIndex"></param>
        /// <param name="ComponentIndex"></param>
        /// <param name="RepeatIndex"></param>
        public HL7NodeInfo(HL7NodeType NodeType, string SegmentType,
                           int SegmentIndex, int FieldIndex,
                           int ComponentIndex, int RepeatIndex)
        {   // NodeType : tells us what type of tv-node to represent
            // HL7Index parameters : tracks the location of this data element in the HL7 message
            //
            this.NodeType = NodeType;
            this.SegmentType = SegmentType;
            this.MsgIndex = new HL7Index(SegmentIndex, FieldIndex, ComponentIndex, RepeatIndex);
        }

        /// <summary>
        /// Render alternative displayable representation of the node
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public string SummaryString(string element)
        {
            return string.Format("{0} {1}", this.ToString(), element);
        }

        /// <summary>
        /// Render displayable representation of the node
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {   /*
			* Return notation identifying the segment type, field and
			* component details, as appropriate for the element type.
		 	* Assumption: all instances will have been populated
		 	* with their correct segment-type & position indices.
			*
			* From user feedback, should show 1-based component numbers to match the HL7 documentation.
			*/
            switch (this.NodeType)
            {
                case HL7NodeType.HL7Segment:
                    return String.Format("[{0}:{1}]",
                                            this.MsgIndex.SegmentIdx.ToString(),
                                            this.SegmentType);

                case HL7NodeType.HL7Field:
                    // if field is in a group of repeating fields show the repeat-pos as well
                    return this.MsgIndex.RepeatIdx < 0
                        ? String.Format("[{0}-{1}]",
                                                this.SegmentType,
                                                this.MsgIndex.FieldIdx)
                        : String.Format("[{0}-{1}/{2}]",
                                                this.SegmentType,
                                                this.MsgIndex.FieldIdx,
                                                (this.MsgIndex.RepeatIdx + 1).ToString());

                case HL7NodeType.HL7RepeatGrouper:
                    return String.Format("[{0}-{1}] <<repeating field>>",
                                            this.SegmentType,
                                            this.MsgIndex.FieldIdx);

                case HL7NodeType.HL7Component:
                    return String.Format("[{0}-{1}.{2}]",
                                            this.SegmentType,
                                            this.MsgIndex.FieldIdx,
                                            (this.MsgIndex.ComponentIdx + 1).ToString());

                default:
                    return this.SegmentType;
            }
        }

        /*
		public int ElementCount()
		{
			// number of fields in the segment:
			if (this.NodeType == HL7NodeType.HL7Segment)
				return this.RawData.Split('|').Length;
			// number of components in the field:
			if (this.NodeType == HL7NodeType.HL7Field)
				return this.RawData.Split('^').Length;
			// number of repeated fields in the repeat-group:
			if (this.NodeType == HL7NodeType.HL7RepeatGrouper)
				return this.RawData.Split('~').Length;
			// For a component, just return length of data (not going to
			// descend to the sub-component level in this version of the app)
			if (this.NodeType == HL7NodeType.HL7Component)
				return this.RawData.Length;

			return 0;
		}

		public string GetElement(int ElementIndex)
		{// Return: The requested element of this item's data,
		 // either a field from a segment, a component from a field,
		 // or a field from a repeat-group.
		 // Return empty string if index is out of bounds.
		 //
		 	string[] elementData = {};

			// get all fields in the segment:
			if (this.NodeType == HL7NodeType.HL7Segment)
				elementData = this.RawData.Split('|');
			// all components in the field:
			if (this.NodeType == HL7NodeType.HL7Field)
				elementData = this.RawData.Split('^');
			// number of repeated fields in the repeat-group:
			if (this.NodeType == HL7NodeType.HL7RepeatGrouper)
				elementData = this.RawData.Split('~');

			if ((ElementIndex >= 0) && (ElementIndex < elementData.Length))
				return elementData[ElementIndex];
			return "";
		}
		*/
    }//class HL7NodeInfo
}//namespace QuickViewHL7