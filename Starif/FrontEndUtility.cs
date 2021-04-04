using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Starif
{
    class FrontEndUtility
    {
        //Menghapus edge duplikat pada frontend
        public static Graf deletedDuplicatedEdgesGraph(Graf graf, int N)
        {
            List<Edge> noDuplicateEdges = new List<Edge>();
            List<Node> newNodes = new List<Node>();
            Graf newGraph = new Graf(N);
            foreach (Node node in graf.getGraphNode())
            {
                List<Edge> newEdges = new List<Edge>();
                foreach (Edge edge in node.getEdges())
                {
                    string namaNodeTestedEdge = edge.getNode().getNamaNode();
                    string namaNextNodeTestedEdge = edge.getNext().getNamaNode();
                    bool exist = noDuplicateEdges.Any(x => x.getNode().getNamaNode() == namaNextNodeTestedEdge && x.getNext().getNamaNode() == namaNodeTestedEdge);
                    if (!exist)
                    {
                        noDuplicateEdges.Add(edge);
                        newEdges.Add(edge);
                    }
                }
                Node newNode = new Node(node.getNamaNode(), node.getKoordinatNode());
                newNode.setEdges(newEdges);
                newNodes.Add(newNode);
            }
            newGraph.setListNodes(newNodes);
            return newGraph;

        }
    }
}