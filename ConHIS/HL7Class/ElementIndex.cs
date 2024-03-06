using System.Runtime.InteropServices;

namespace ConHIS
{
    /// <summary>
    /// ElementIndex holds indices to a specific element in an HL7 message.
    /// -1 for unassigned item, in any of the properties, e.g. only SegmentIdx is specified when referring
    /// to a segment.
    /// RepeatIdx is the position of a field within a multi-value set,
    /// e.g. fields seperated by a repeat-marker.
    ///
    /// This is a replacement for the struct HL7Index, providing visibility in JavaScript.
    /// TODO replace all use of HL7Index with this class.
    ///
    /// For display to the user, field indexing will be 1-based, while internally it is logically zero-based.
    /// TODO: Determine if repeat-index should be displayed to user as 1-based instead of zero-based.
    /// </summary>
    [ComVisibleAttribute(true)]
    public class ElementIndex
    {
        /// <summary>
        /// Segment index, zero based, -1 when undefined
        /// </summary>
        public int SegmentIdx;

        /// <summary>
        /// Field index, zero based, -1 when undefined
        /// </summary>
        public int FieldIdx;

        /// <summary>
        /// Component index within a field, zero based, -1 when undefined
        /// </summary>
        public int ComponentIdx;

        /// <summary>
        /// Repeat index within a field component, zero based, -1 when undefined
        /// </summary>
        public int RepeatIdx;

        /// <summary>
        /// Tag attribute for an ElementIndex (is it used?)
        /// </summary>
        public string Tag;

        /// <summary>
        /// Constructor, properties set to default
        /// </summary>
        public ElementIndex()
        {
            this.SegmentIdx = -1;
            this.FieldIdx = -1;
            this.ComponentIdx = -1;
            this.RepeatIdx = -1;
            this.Tag = string.Empty;
        }

        /// <summary>
        /// Constructor, copying property values from the given ElementIndex instance
        /// </summary>
        /// <param name="copyFromElement"></param>
        public ElementIndex(ElementIndex copyFromElement)
        {
            if (copyFromElement == null)
            {
                this.SegmentIdx = 0;
            }
            else
            {
                this.SegmentIdx = copyFromElement.SegmentIdx;
                this.FieldIdx = copyFromElement.FieldIdx;
                this.ComponentIdx = copyFromElement.ComponentIdx;
                this.RepeatIdx = copyFromElement.RepeatIdx;
                this.Tag = string.Empty;
            }
        }

        /// <summary>
        /// Constructor, copying property values from the given HL7Index instance
        /// </summary>
        /// <param name="copyFromIndex"></param>
        public ElementIndex(HL7Index copyFromIndex)
        {
            // Temporary - until HL7Index type is removed completely from the project
            this.SegmentIdx = copyFromIndex.SegmentIdx;
            this.FieldIdx = copyFromIndex.FieldIdx;
            this.ComponentIdx = copyFromIndex.ComponentIdx;
            this.RepeatIdx = copyFromIndex.RepeatIdx;
            this.Tag = string.Empty;
        }

        /// <summary>
        /// Render a displayable representation of the element index
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
}