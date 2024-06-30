using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurstTrie
{
    public class ContainerNode : BurstNode
    {
        public override int Count => throw new NotImplementedException();

        BST<string> Container;

        public ContainerNode(BurstTrie parent) : base(parent)
        {
            Container = new BST<string>();
        }

        public override BurstNode Insert(string value, int index)
        {
            throw new NotImplementedException();
        }

        private BurstNode Burst()
        {
            InternalNode replacement = new InternalNode(ParentTrie);
            List<string> values = new List<string>();
            Container.GetAll(values);
            foreach (string value in values)
            {
                replacement.Insert(value);
            }
        }

        public override BurstNode? Remove(string value, int index, out bool success)
        {
            throw new NotImplementedException();
        }

        public override BurstNode? Search(string prefix, int index)
        {
            throw new NotImplementedException();
        }

        internal override void GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
