using System;
using System.Collections.Generic;
using System.Text;

namespace HashMap
{
    class Pair<TKey, TValue>
    {
        public TKey key;
        public TValue value;

        private Pair(TKey Key, TValue Value)
        {
            key = Key;
            value = Value;
        }

        public static Pair<TKey, TValue> Create(TKey key, TValue value)
        {
            return new Pair<TKey, TValue>(key, value);
        }
    }
}