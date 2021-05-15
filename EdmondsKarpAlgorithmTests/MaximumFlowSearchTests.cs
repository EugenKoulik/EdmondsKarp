using NUnit.Framework;
using System;
using RBTREE;



namespace EdmondsKarpAlgorithmTests
{
    class MaximumFlowSearchTests
    {

        [Test]
        public void EdmondKarpAlg_Network_MaxFlow()
        {
            string FileName = "CorrectData.txt";

            int ExpectationFlow = 5;

            int Flow = EdmondsKarpAlgorithm.EdmondsKarpAlgorithm.GetMaxFlow(FileName, "S", "T");

            Assert.AreEqual(Flow, ExpectationFlow);
        }

        [Test]
        public void EdmondKarpAlg_Network_ZeroFlow()
        {
            string FileName = "CorrectData(ZeroFlow).txt";

            int ExpectationFlow = 0;

            int Flow = EdmondsKarpAlgorithm.EdmondsKarpAlgorithm.GetMaxFlow(FileName, "S", "T");

            Assert.AreEqual(Flow, ExpectationFlow);
        }


    }
}
