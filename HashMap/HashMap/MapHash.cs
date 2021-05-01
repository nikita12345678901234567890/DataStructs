using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HashMap
{
    interface IMyDictionary<TKey, TValue>
    {
        
    }
    class MapHash<TKey,TValue>
    {
        public TValue this[TKey key]
        {
            get
            {
                int index = GetHash(key);
                if (map[index] == null || map[index].Count == 0)
                {
                    throw new Exception("The number you are trying to reach has been disconnected.");
                }
                if (map[index].Count == 1)
                {
                    return map[index].First.Value.value;
                }
                else
                {
                    LinkedListNode<Pair<TKey, TValue>> tempNode = tempNode = map[index].First;
                    while (!tempNode.Value.key.Equals(key))
                    {
                        tempNode = tempNode.Next;
                    }
                    return tempNode.Value.value;
                }
            }

            set
            {
                int index = GetHash(key);
                if (map[index] == null || map[index].Count == 0)
                {
                    throw new Exception("The number you are trying to reach has been disconnected.");
                }
                if (map[index].Count == 1)
                {
                    map[index].First.Value.value = value;
                }
                else
                {
                    LinkedListNode<Pair<TKey, TValue>> tempNode = tempNode = map[index].First;
                    while (!tempNode.Value.key.Equals(key))
                    {
                        tempNode = tempNode.Next;
                    }
                    tempNode.Value.value = value;
                }
                ReHash();
            }
        }

        int count = 0;
        LinkedList<Pair<TKey, TValue>>[] map = new LinkedList<Pair<TKey, TValue>>[10];
        public void Add(TKey key, TValue value)
        {
            Pair<TKey, TValue> pair = Pair<TKey, TValue>.Create(key, value);
            Add(pair);
        }

        public void Add(Pair<TKey, TValue> pair)
        {
            int index = GetHash(pair.key);
            if (map[index] == null)
            {
                map[index] = new LinkedList<Pair<TKey, TValue>>();
                map[index].AddLast(pair);
            }
            else
            {
                var pairy = map[index].First;
                for (int i = 0; i < map[index].Count; i++)
                {
                    if (pairy.Value.key.Equals(pair.key))
                    {
                        throw new Exception("No Duplicates!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    pairy = pairy.Next;
                }

                map[index].AddLast(pair);
            }
            count++;
            ReHash();
        }

        public void ReHash()
        {
            if (count >= map.Length)
            {
                LinkedList<Pair<TKey, TValue>>[] Tempmap = new LinkedList<Pair<TKey, TValue>>[map.Length * 2];
                for (int i = 0; i < map.Length; i++)
                {
                    if (map[i] != null)
                    {
                        foreach (var item in map[i])
                        {
                            int index = item.key.GetHashCode() % Tempmap.Length;
                            Tempmap[index] = new LinkedList<Pair<TKey, TValue>>();
                            Tempmap[index].AddLast(map[i].First.Value);
                        }
                    }
                }
                map = Tempmap;
            }
        }

        public void Remove(TKey key)
        {
            int index = GetHash(key);
            if (map[index] == null || map[index].Count == 0)
            {
                throw new Exception("The number you are trying to reach has been disconnected.");
            }
            count--;
            if (map[index].Count == 1)
            {
                map[index].Clear();
            }
            else
            {
                count--;
                key.Equals(null); //wat? cry...
                var orange = 3; // since we're typing random code...

                LinkedListNode<Pair<TKey, TValue>> tempNode = tempNode = map[index].First;
                while (!tempNode.Value.key.Equals(key))
                {
                    tempNode = tempNode.Next;
                }
                map[index].Remove(tempNode);
            }
        }

        public int GetHash(TKey thing)
        {
            return thing.GetHashCode() % map.Length;
        }
    }
}
// "I will enjoy making monopoly" -Santiago 2/11/20