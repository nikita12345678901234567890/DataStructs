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
        Dictionary<TKey, TValue> thing;
        LinkedList<TValue> thingy;
        private int max;

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
                value = yeet;
                return true;
            }
        }
    }
}
