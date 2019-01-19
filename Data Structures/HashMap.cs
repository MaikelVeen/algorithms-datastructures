using System;

namespace Data_Structures
{
    public class HashMap<TK, TV>
    {
        private Entry<TK, TV>[] Slots { get; set; }
        public int Entries { get; set; }
        public int Size { get; set; }

        public HashMap(int initialSize)
        {
            Slots = new Entry<TK, TV>[initialSize];
            Size = initialSize;
        }

        public void Put(TK key, TV value)
        {
            Entry<TK, TV> newEntry = new Entry<TK, TV>(key, value);
            int hashCode = newEntry.Hashcode;
            int initialSlot = hashCode % Size;

            if (Slots[initialSlot] == null)
            {
                Slots[initialSlot] = newEntry;
                Entries++;
            }
            else
            {
                for (int i = 1; i < Size; i++)
                {
                    int probedSlot = initialSlot + i;
                    if (probedSlot > Size)
                    {
                        probedSlot = i - 1;
                    }

                    if (Slots[probedSlot] != null) continue;
                    Slots[probedSlot] = newEntry;
                    Entries++;
                    break;
                }
            }

            CheckLoadFactor();
        }

        public TV GetValue(TK key)
        {
            int index = key.GetHashCode() % Size;
            if (Slots[index] == null) throw new Exception($"No value with key {key.ToString()} in hashtable");
            
            if (Slots[index].Key.Equals(key))
            {
                return Slots[index].Value;
            }

            for (int i = 1; i < Size; i++)
            {
                int next = index + i;
                if (next > Size)
                {
                    next = i - 1;
                }

                if (Slots[next].Key.Equals(key))
                {
                    return Slots[index].Value;
                }
            }

            throw new Exception($"No value with key {key.ToString()} in hashtable");
        }

        private void CheckLoadFactor()
        {
            float loadFactor = (float) Entries / Size;
            if (loadFactor > (2.0 / 3.0))
            {
                Resize();
            }
        }

        private void Resize()
        {
            Entry<TK, TV>[] newSlots = new Entry<TK, TV>[Size * 2];
            foreach (Entry<TK, TV> entry in Slots)
            {
                if (entry == null) continue;
                int newIndex = entry.Hashcode % (Size * 2);

                // Also linear probing when resizing ?
                if (newSlots[newIndex] == null)
                {
                    newSlots[newIndex] = entry;
                }
                else
                {
                    for (int i = 1; i < (Size * 2); i++)
                    {
                        int probedSlot = newIndex + i;
                        if (probedSlot > Size * 2)
                        {
                            probedSlot = i - 1;
                        }

                        if (newSlots[probedSlot] != null) continue;
                        newSlots[probedSlot] = entry;
                        break;
                    }
                }
            }

            Size = Size * 2;
            Slots = newSlots;
        }
    }

    public class Entry<TK, TV>
    {
        public Entry(TK key, TV value)
        {
            Key = key;
            Value = value;
            Hashcode = Key.GetHashCode();
        }

        public int Hashcode { get; set; }
        public TK Key { get; set; }
        public TV Value { get; set; }
    }
}