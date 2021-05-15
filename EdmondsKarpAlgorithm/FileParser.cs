using System;
using System.IO;
using System.Collections.Generic;
using RBTREE; 

namespace EdmondsKarpAlgorithm
{
    public class FileParser
    {
        public static Map<string, NetNode> GetRBTree(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception("File not exist!!!");
            }

            Map<string, NetNode> RBTree = new Map<string, NetNode>();

            StreamReader sr = new StreamReader(filePath);

            string line;                     

            while ((line = sr.ReadLine()) != null)
            {
                AddCity(line, RBTree);
            }

            return RBTree;
        }

        private static void AddCity(string line, Map<string, NetNode> RBTree)
        {
            string[] parameters = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parameters.Length != 3)
            {
                throw new Exception("Uncorrect data!!!");
            }

            string weight = parameters[2];

            int capacity = int.Parse(weight);

            string nodeName1 = parameters[0];

            string nodeName2 = parameters[1];

            NetNode node1, node2;

            try
            {
                node1 = RBTree.Find(nodeName1).Data;
            }
            catch
            {
                node1 = new NetNode(){ Name = nodeName1, Edges = new List<NetEdge>()};

                RBTree.Insert(nodeName1, node1);
            }

            try
            {
                node2 = RBTree.Find(nodeName2).Data;
            }
            catch
            {
                node2 = new NetNode(){ Name = nodeName2, Edges = new List<NetEdge>()};

                RBTree.Insert(nodeName2, node2);
            }

            NetEdge city1ToCity2 = new NetEdge{Capacity = capacity, To = node2};

            NetEdge city2ToCity1 = new NetEdge{Capacity = capacity, To = node1};

            city2ToCity1.PreviousEdge = city1ToCity2;

            city1ToCity2.PreviousEdge = city2ToCity1;

            node1.Edges.Add(city1ToCity2);

            node2.Edges.Add(city2ToCity1);
        }

    }
}
