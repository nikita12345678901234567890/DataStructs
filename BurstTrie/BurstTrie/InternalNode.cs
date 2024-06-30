using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurstTrie
{
    public class InternalNode : BurstNode
    {
        public override int Count => throw new NotImplementedException();

        public InternalNode(BurstTrie parent) : base(parent)
        {

        }

        public override BurstNode Insert(string value, int index)
        {
            throw new NotImplementedException();
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
