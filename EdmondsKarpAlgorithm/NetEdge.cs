using System;
using System.Collections.Generic;

namespace EdmondsKarpAlgorithm
{
    public class NetEdge
    {
        public NetNode To { get; set; }
        public NetEdge PreviousEdge { get; set; }
        public int Capacity { get; set; }
        public int Size { get; set; }        

    }
}
