using System;
using System.Collections;

namespace ConHIS
{
    /// <summary>
    /// Collection and management of some HL7BucketItems.
    /// </summary>
    public class HL7BucketItems : ICollection
    {
        private readonly ArrayList mItemArray = new ArrayList();

        /// <summary>
        /// Public enumerator property for the buckets collection
        /// </summary>
        public HL7BucketItem this[int index]
        {
            get { return (HL7BucketItem)mItemArray[index]; }
        }

        /// <summary>
        /// Public method for modifying the collection
        /// </summary>
        /// <param name="a"></param>
        /// <param name="index"></param>
        public void CopyTo(Array a, int index)
        {
            mItemArray.CopyTo(a, index);
        }

        /// <summary>
        /// Public property for the collection
        /// </summary>
        public int Count
        {
            get { return mItemArray.Count; }
        }

        /// <summary>
        /// Public enumerator property for the buckets collection
        /// </summary>
        public object SyncRoot
        {
            get { return this; }
        }

        /// <summary>
        /// Public enumerator property for the buckets collection
        /// </summary>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Public enumerator property for the buckets collection
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return mItemArray.GetEnumerator();
        }

        /// <summary>
        /// Public enumerator property for the buckets collection
        /// </summary>
        /// <param name="newItem"></param>
        public void Add(HL7BucketItem newItem)
        {
            mItemArray.Add(newItem);
        }

        /// <summary>
        /// Public enumerator property for the buckets collection
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAT(int index)
        {
            if (index > -1 && index < mItemArray.Count)
                mItemArray.RemoveAt(index);
        }

        /// <summary>
        /// Public method to find the given bucket name in the collection
        /// </summary>
        /// <param name="bucketName">Bucket name to find</param>
        /// <returns>Index of the bucket in the collection, -1 if not found</returns>
        public int IndexOf(string bucketName)
        {
            HL7BucketItem bkt;
            for (int idx = 0; idx < mItemArray.Count; idx++)
            {
                bkt = (HL7BucketItem)mItemArray[idx];
                if (bkt.BucketName.Equals(bucketName, StringComparison.InvariantCultureIgnoreCase))
                    return idx;
            }
            return -1;
        }

        /// <summary>
        /// Public method to find the given path in the collection
        /// </summary>
        /// <param name="findPath">File path to find in the bucket collection</param>
        /// <returns>Name of the first bucket found with this path, empty string if not found</returns>
        public string FindByPath(string findPath)
        {   // Return the bucket name if the path is found in the bucket collection
            //if (!findPath.EndsWith("\\"))
            //	findPath = findPath + "\\";

            HL7BucketItem bkt;
            for (int idx = 0; idx < mItemArray.Count; idx++)
            {
                bkt = (HL7BucketItem)mItemArray[idx];
                if (bkt.BucketPath.Equals(findPath, StringComparison.InvariantCultureIgnoreCase))
                    return bkt.BucketName;
            }
            return "";
        }
    }//class HL7BucketItems
}//namespace QuickViewHL7