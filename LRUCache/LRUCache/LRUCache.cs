using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LRUCache
{
    public interface ICache<TKey, TValue>
    {
        bool TryGetValue(TKey key, out TValue value);
        void Put(TKey key, TValue value);
    }
    class LRUCache<TKey, TValue> : ICache<TKey, TValue>
    {
        public Dictionary<TKey, TValue> thing;
        public LinkedList<TValue> thingy;
        public int max;

        public LRUCache(int maxAmount)
        {
            thing = new Dictionary<TKey, TValue>();
            thingy = new LinkedList<TValue>();
            max = maxAmount;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (thing.ContainsKey(key))
            {
                var yeet = thing[key];
                thingy.Remove(yeet);
                thingy.AddFirst(yeet);
                value = yeet;
                return true;
            }
            value = default;
            return false;
        }

        public void Put(TKey key, TValue value)
        {
            if (thing.ContainsKey(key))
            {
                var yeet = thing[key];
                thingy.Remove(yeet);
                thingy.AddFirst(yeet);
            }

            else
            {
                if (thing.Count == max)
                {
                    thingy.RemoveLast();
                }
                thingy.AddFirst(value);
                thing.Add(key, value);
            }
        }
    }
}
