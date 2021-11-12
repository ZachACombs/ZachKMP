using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>List of entries in a KMP section</summary>
    ///<typeparam name="T">Type of entries</typeparam>
    public class KmpEntryList<T>
    {
        private List<T> Var_List;

        ///<summary>Gets or sets the entry at the specified index</summary>
        ///<param name="index">Index to get or set entry</param>
        ///<returns>Entry at specified index</returns>
        public T this[int index]
        {
            set
            {
                if (index < 0)
                    throw new ArgumentOutOfRangeException(nameof(index), nameof(index) + " is less than 0");
                if (index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index), nameof(index) + " is greater than or equal to " + nameof(Count));
                Var_List[index] = value;
            }
            get
            {
                if (index < 0)
                    throw new ArgumentOutOfRangeException(nameof(index), nameof(index) + " is less than 0");
                if (index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index), nameof(index) + " is greater than or equal to " + nameof(Count));
                return Var_List[index];
            }
        }

        ///<summary>Gets the maximum number of entries</summary>
        public const ushort MaxCount = ushort.MaxValue;
        ///<summary>Gets the number of entries</summary>
        public ushort Count
        {
            get
            {
                return (ushort)Var_List.Count;
            }
        }

        ///<summary>Copies the entries to a new array</summary>
        ///<returns>An array containing the entries</returns>
        public T[] ToArray()
        {
            return Var_List.ToArray();
        }

        ///<summary>Adds an entry to the end of the list</summary>
        ///<param name="entry">Entry to add</param>
        public void Add(T entry)
        {
            if (Var_List.Count >= MaxCount)
                throw new Exception("Maximum number of entries reached");
            Var_List.Add(entry);
        }
        ///<summary>Adds the entries of the specified collection to the end of the list</summary>
        ///<param name="collection">Entries to add</param>
        public void AddRange(System.Collections.Generic.IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection), nameof(collection) + " is null");
            Var_List.AddRange(collection);
            if (Var_List.Count > MaxCount)
            {
                Var_List.RemoveRange(MaxCount, Var_List.Count - MaxCount);
                throw new Exception("Maximum number of entries reached");
            }
        }

        ///<summary>Inserts an entry into the list at the specified index</summary>
        ///<param name="index">Zero-based index at which entry should be inserted</param>
        ///<param name="entry">Entry to insert</param>
        public void Insert(int index, T entry)
        {
            if (Var_List.Count >= MaxCount)
                throw new Exception("Maximum number of entries reached");
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), nameof(index) + " is less than 0");
            if (index > Count)
                throw new ArgumentOutOfRangeException(nameof(index), nameof(index) + " is greater than " + nameof(Count));
            Var_List.Insert(index, entry);
        }
        ///<summary>Inserts the entries of the specified collection into the list at the specified index</summary>
        ///<param name="index">Zero-based index at which entries should be inserted</param>
        ///<param name="collection">Entries to insert</param>
        public void InsertRange(int index, System.Collections.Generic.IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection), nameof(collection) + " is null");
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), nameof(index) + " is less than 0");
            if (index > Count)
                throw new ArgumentOutOfRangeException(nameof(index), nameof(index) + " is greater than " + nameof(Count));
            Var_List.InsertRange(index, collection);
            if (Var_List.Count > MaxCount)
            {
                Var_List.RemoveRange(MaxCount, Var_List.Count - MaxCount);
                throw new Exception("Maximum number of entries reached");
            }
        }

        ///<summary>Removes the first occurance of the specified entry</summary>
        ///<param name="entry">Entry to remove</param>
        ///<returns>Whether or not first occurance of entry was successfully removed</returns>
        public bool Remove(T entry)
        {
            return Var_List.Remove(entry);
        }
        ///<summary>Removes entry at the specified index</summary>
        ///<param name="index">Zero-based index of entry to remove</param>
        public void RemoveAt(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), nameof(index) + " is less than 0");
            if (index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), nameof(index) + " is greater than or equal to " + nameof(Count));
            Var_List.RemoveAt(index);
        }
        ///<summary>Removes a range of entries</summary>
        ///<param name="index">Zero-based index to begin removing entries</param>
        ///<param name="count">Number of entries to remove</param>
        public void RemoveRange(int index, int count)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), nameof(index) + " is less than 0");
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), nameof(count) + " is less than 0");
            if ((index + count) > Var_List.Count)
                throw new ArgumentException(index + " and " + count + " do not denote a valid range of elements in the list");
            Var_List.RemoveRange(index, count);
        }
        ///<summary>Removes all entries from the list</summary>
        public void Clear()
        {
            Var_List.Clear();
        }

        ///<summary>Reverses the order of entries in list</summary>
        public void Reverse()
        {
            Var_List.Reverse();
        }

        ///<summary>Returns the zero-based index of the first occurance of the specified entry</summary>
        ///<param name="entry">Entry to find</param>
        ///<returns>Zero-based index of the specified entry (or -1 if it doesn't exist within list)</returns>
        public int IndexOf(T entry)
        {
            return Var_List.IndexOf(entry);
        }

        ///<summary>Creates a new KMP Entry List</summary>
        public KmpEntryList ()
        {
            Var_List = new List<T>();
        }
        ///<summary>Creates a new KMP Entry List using entries of the specified collection</summary>
        ///<param name="collection">Entries to use</param>
        public KmpEntryList (System.Collections.Generic.IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection), nameof(collection) + " is null");
            Var_List = new List<T>();
            Var_List.AddRange(collection);
            if (Var_List.Count > MaxCount)
            {
                Var_List.RemoveRange(MaxCount, Var_List.Count - MaxCount);
                throw new Exception("Maximum number of entries reached");
            }
        }
    }
}
