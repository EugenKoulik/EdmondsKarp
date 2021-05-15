using System;
using System.Collections.Generic;
using RBTREE;

namespace EdmondsKarpAlgorithm
{
    public class EdmondsKarpAlgorithm
    {

        public static int GetMaxFlow(string filePath, string startNode, string endNode)
        {
            Map<string, NetNode> RBTree = FileParser.GetRBTree(filePath);

            Map<string, NetNode> pathTree;

            int maxFlow = 0;

            while ((pathTree = BFS(RBTree, startNode, endNode)) != null)
            {
                var flow = GetFlow(pathTree, endNode);

                maxFlow += flow;

                UpdateGraph(flow, pathTree, endNode);
            }

            return maxFlow;
        }

        private static Map<string, NetNode> BFS(Map<string, NetNode> rbTree, string startNode, string endNode)
        {
            Map<string, bool> visitTree = new Map<string, bool>();

            Map<string, NetNode> pathTree = new Map<string, NetNode>();

            Queue<NetNode> queue = new Queue<NetNode>();

            visitTree.Insert(startNode, true);           

            pathTree.Insert(startNode, null);

            NetNode startPoint = rbTree.Find(startNode).Data;

            queue.Enqueue(startPoint);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                foreach (var edge in currentNode.Edges)
                {
                    if (edge.Capacity != edge.Size)
                    {
                        var to = edge.To;

                        try
                        {
                            visitTree.Find(to.Name);
                        }
                        catch
                        {
                            visitTree.Insert(to.Name, true);

                            pathTree.Insert(to.Name, currentNode);

                            queue.Enqueue(to);
                        }
                    }
                }
            }

            try
            {
                pathTree.Find(endNode);

                return pathTree;
            }
            catch
            {
                return null;
            }
        }

        private static void UpdateGraph(int maxFlow, Map<string, NetNode> pathTree, string endNode)
        {
            string currentName = endNode;

            NetNode currentNode;

            while ((currentNode = pathTree.Find(currentName).Data) != null)
            {
                NetEdge edge = GetEdgeByName(currentNode, currentName);

                edge.Size += maxFlow;

                edge.PreviousEdge.Size -= maxFlow;

                currentName = currentNode.Name;
            }
        }

        private static int GetFlow(Map<string, NetNode> pathTree, string endNode)
        {
            string currentName = endNode;

            int maxFlow = int.MaxValue;

            NetNode currentNode;

            while ((currentNode = pathTree.Find(currentName).Data) != null)
            {
                NetEdge edge = GetEdgeByName(currentNode, currentName);

                maxFlow = Math.Min(edge.Capacity - edge.Size, maxFlow);

                currentName = currentNode.Name;
            }

            return maxFlow;
        }

        private static NetEdge GetEdgeByName(NetNode node, string toName)
        {
            foreach (var edge in node.Edges)
            {
                NetNode to = edge.To;

                if (to.Name == toName)
                {
                    return edge;
                }
            }
            return null;
        }
    }
}
