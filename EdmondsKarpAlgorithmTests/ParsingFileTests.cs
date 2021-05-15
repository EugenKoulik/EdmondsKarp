using NUnit.Framework;
using System;
using EdmondsKarpAlgorithm;
using RBTREE;


namespace EdmondsKarpAlgorithmTests
{
    public class ParsingFileTests
    {

        [Test]
        public void OpenFile_FileNotExist_Exception()
        {
            string fileName = "LOL.txt";

            Assert.Throws<Exception>(() => FileParser.GetRBTree(fileName));

        }


        [Test]
        public void OpenFile_NotCorrectData_Exception()
        {
            string fileName = "UncorrectDataFile.txt";

            Assert.Throws<Exception>(() => FileParser.GetRBTree(fileName));

        }


        [Test]
        public void OpenFile_CorrectData_FileExist()
        {
            string startPointName = "S";

            string fileName = "CorrectData.txt";

            Map<string, NetNode> RBTree = FileParser.GetRBTree(fileName);

            Assert.AreEqual(RBTree.Find("S").Data.Name, startPointName);

        }
    }
}