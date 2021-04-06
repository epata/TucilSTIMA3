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

        public static Microsoft.Msagl.Drawing.Graph grafVisualization(Graf graf)
        {
            Microsoft.Msagl.Drawing.Graph grafVisualization = new Microsoft.Msagl.Drawing.Graph("graf");
            int N = graf.getGraphNode().Count;
            //gViewer1.Controls.Clear();
            Graf frontEndGraph = FrontEndUtility.deletedDuplicatedEdgesGraph(graf, graf.getGraphNode().Count);
            foreach (Node node in frontEndGraph.getGraphNode())
            {
                foreach (Edge edge in node.getEdges())
                {
                    double roundedBobot = Math.Round(edge.getBobot() * 100000, 2);
                    var garis = grafVisualization.AddEdge(edge.getNode().getNamaNode(), roundedBobot.ToString(), edge.getNext().getNamaNode());
                    garis.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                    garis.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
                }
            }
            return grafVisualization;
        }
        public static Microsoft.Msagl.Drawing.Graph colorizedGrafVisualization(Graf graf, List<Edge> rute)
        {
            int i;
            Microsoft.Msagl.Drawing.Graph grafVisualization = new Microsoft.Msagl.Drawing.Graph("graf");
            int N = graf.getGraphNode().Count;
            Graf frontEndGraph = FrontEndUtility.deletedDuplicatedEdgesGraph(graf, graf.getGraphNode().Count);
            foreach (Node node in frontEndGraph.getGraphNode())
            {
                foreach (Edge edge in node.getEdges())
                {
                    double roundedBobot = Math.Round(edge.getBobot() * 100000, 2);
                    var garis = grafVisualization.AddEdge(edge.getNode().getNamaNode(), roundedBobot.ToString(), edge.getNext().getNamaNode());
                    garis.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                    garis.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;

                    for (i = 0; i < rute.Count; i++)
                    {
                        bool edgeFirstCheck = rute[i].getNode().getNamaNode() == edge.getNode().getNamaNode() && rute[i].getNext().getNamaNode() == edge.getNext().getNamaNode();
                        bool edgeSecondCheck = rute[i].getNode().getNamaNode() == edge.getNext().getNamaNode() && rute[i].getNext().getNamaNode() == edge.getNode().getNamaNode();
                        if (edgeFirstCheck || edgeSecondCheck)
                        {
                            garis.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                            if (i == 0)
                            {
                                grafVisualization.FindNode(rute[i].getNode().getNamaNode()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.LightBlue;
                                grafVisualization.FindNode(rute[i].getNext().getNamaNode()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.LightGreen;
                            }
                            else if (i == rute.Count - 1)
                            {
                                grafVisualization.FindNode(rute[i].getNode().getNamaNode()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Turquoise;
                                grafVisualization.FindNode(rute[i].getNext().getNamaNode()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.LightGreen;
                            }
                            else
                            {
                                grafVisualization.FindNode(rute[i].getNode().getNamaNode()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Turquoise;
                                grafVisualization.FindNode(rute[i].getNext().getNamaNode()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Turquoise;
                            }
                        }
                    }
                }
            }
            return grafVisualization;
        }
    }
}