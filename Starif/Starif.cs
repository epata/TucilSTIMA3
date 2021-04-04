using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Starif
{
    public partial class Starif : Form
    {
        private OpenFileDialog browse = new OpenFileDialog();

        public Starif()
        {
            InitializeComponent();
        }

        //browse
        private void button1_Click(object sender, EventArgs e)
        {
            //string directory;
            browse.Filter = "*.txt (file berekstensi txt) | *.txt";
            if (browse.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Msagl.Drawing.Graph grafVisualization = new Microsoft.Msagl.Drawing.Graph("graf");
                int i, j;
                string[] input = File.ReadAllLines(@"input.txt");
                int N = Int32.Parse(input[0]);
                Graf graf = new Graf(N);
                for (i = 1; i <= N; i++)
                {
                    double x = Convert.ToDouble(input[i].Split(" ")[1]);
                    double y = Convert.ToDouble(input[i].Split(" ")[2]);
                    Coordinate nodeCoordinate = new Coordinate(x, y);
                    string namaNode = input[i].Split(" ")[0];
                    //Node node = new Node(namaNode, nodeCoordinate);
                    graf.addNode(namaNode, nodeCoordinate);
                }
                for (i = 0; i < N; i++)
                {
                    for (j = 0; j < N; j++)
                    {
                        if (input[i + N + 1].Split("  ")[j] == "1")
                        {
                            graf.getGraphNode()[i].addEdge(graf.getGraphNode()[j]);
                        }
                    }
                }

                Graf frontEndGraph = FrontEndUtility.deletedDuplicatedEdgesGraph(graf, N);

                foreach (Node node in frontEndGraph.getGraphNode())
                {
                    foreach (Edge edge in node.getEdges())
                    {
                        double roundedBobot = Math.Round(edge.getBobot(), 2);
                        grafVisualization.AddEdge(edge.getNode().getNamaNode(), roundedBobot.ToString(), edge.getNext().getNamaNode()).Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                    }                    
                }

                

                // input simpul awal dan tujuan

                string awal = "Bandung";


                string tujuan = "Jakarta";

                Node nodeAwal = graf.searchNode(awal);
                Node nodeTujuan = graf.searchNode(tujuan);

                if (!graf.searchNode(nodeAwal) || !graf.searchNode(nodeTujuan))
                {
                    //Console.WriteLine("Simpul tidak ada");
                }
                else
                {
                    //ALGORITMA A*
                    int iNode = 0;
                    List<Node> rute = new List<Node>();
                    Node nodeAwalAlgo = nodeAwal;
                    rute.Add(nodeAwalAlgo);
                    grafVisualization.FindNode(rute[iNode].getNamaNode()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                    j = 0;
                    while (nodeAwalAlgo != nodeTujuan)
                    {
                        iNode += 1;
                        Dictionary<Node, double> results = new Dictionary<Node, double>();
                        int jumlahEdges = nodeAwalAlgo.getEdges().Count;
                        i = 0;
                        j += 1;
                        while (i < jumlahEdges)
                        {
                            //g(n) = distance dari nodeAwalAlgo ke n
                            double g = nodeAwalAlgo.getEdges()[i].getBobot();
                            //h(n) = straight line distance from n ke nodeTujuan
                            double h = Edge.euclideanDistance(nodeAwalAlgo.getEdges()[i].getNext().getKoordinatNode(), nodeTujuan.getKoordinatNode());
                            //f(n) = g(n) + h(n)
                            double f = g + h;
                            results.Add(nodeAwalAlgo.getEdges()[i].getNext(), f);
                            comboBox1.Items.Add("jumlahedges:" +jumlahEdges);
                    

                            i += 1;
                        }
                        
                        nodeAwalAlgo = results.OrderBy(KeyValuePair => KeyValuePair.Value).First().Key;
                        rute.Add(nodeAwalAlgo);
                        grafVisualization.FindNode(rute[iNode].getNamaNode()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                    }
                }
                gViewer1.Graph = grafVisualization;
            }
        }
    }
}
