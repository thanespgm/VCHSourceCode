namespace ConHIS
{
    /// <summary>
    /// Structure defining a Bucket for HL7 message retrieval or posting.
    /// Currently simply a reference list of win32 pathnames, but planned
    /// extensions are FTP drop/pickup, database transaction mapping/scripting,
    /// maybe SOAP or whatever else is needed.
    /// </summary>
    public class HL7BucketItem
    {
        /// <summary>
        /// Public property, bucket name
        /// </summary>
        public string BucketName;

        /// <summary>
        /// Public property, bucket path
        /// </summary>
        public string BucketPath;

        /// <summary>
        /// Public property, bucket type
        /// </summary>
        public int itemType;

        /// <summary>
        /// Constructor
        /// </summary>
        public HL7BucketItem() : this("new bucket", "c:\\new\\path") { }

        /// <summary>
        /// Constructor, property values set to given values
        /// </summary>
        /// <param name="newName">Bucket name</param>
        /// <param name="newPath">Bucket path</param>
        public HL7BucketItem(string newName, string newPath)
        {
            BucketName = newName;
            BucketPath = newPath;
            itemType = 1;
        }

        /// <summary>
        /// Render a displayable representation of this bucket instance
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return BucketName;
        }

        /// <summary>
        /// Render an alternative display value for this bucket instance
        /// </summary>
        /// <returns></returns>
        public string ToDetailString()
        {
            return string.Format("{0} ({1})", BucketName, BucketPath);
        }
    }//class HL7BucketItem
}//namespace QuickViewHL7