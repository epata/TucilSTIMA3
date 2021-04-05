using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Msagl.Drawing;

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
                
                    double x = Convert.ToDouble(input[i].Split(" ")[1], CultureInfo.InvariantCulture);
                    double y = Convert.ToDouble(input[i].Split(" ")[2], CultureInfo.InvariantCulture);
                    Coordinate nodeCoordinate = new Coordinate(x, y);
                    string namaNode = input[i].Split(" ")[0];
                    //Node node = new Node(namaNode, nodeCoordinate);
                    graf.addNode(namaNode, nodeCoordinate);
                    comboBox2.Items.Add(namaNode);
                    comboBox3.Items.Add(namaNode);
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
                    List<Edge> rute = new List<Edge>();
                    Node nodeAwalAlgo = nodeAwal;

                    j = 0;
                    while (nodeAwalAlgo != nodeTujuan)
                    {
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
                            comboBox1.Items.Add("jumlahedges:" + jumlahEdges);


                            i += 1;
                        }
                        Node tempNodeAwal = nodeAwalAlgo;

                        nodeAwalAlgo = results.OrderBy(KeyValuePair => KeyValuePair.Value).First().Key;
                        Edge edgeRute = new Edge(tempNodeAwal, nodeAwalAlgo);
                        rute.Add(edgeRute);
                    }

                    Graf frontEndGraph = FrontEndUtility.deletedDuplicatedEdgesGraph(graf, N);
                    foreach (Node node in frontEndGraph.getGraphNode())
                    {
                        foreach (Edge edge in node.getEdges())
                        {
                            comboBox1.Items.Add(edge.getNode().getNamaNode());
                            comboBox1.Items.Add(edge.getNext().getNamaNode());
                            double roundedBobot = Math.Round(edge.getBobot(), 2);
                            var garis = grafVisualization.AddEdge(edge.getNode().getNamaNode(), roundedBobot.ToString(), edge.getNext().getNamaNode());
                            garis.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                            garis.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
                        
                            for (i=0; i<rute.Count; i++){
                                bool edgeFirstCheck = rute[i].getNode().getNamaNode() == edge.getNode().getNamaNode() && rute[i].getNext().getNamaNode() == edge.getNext().getNamaNode();
                                bool edgeSecondCheck = rute[i].getNode().getNamaNode() == edge.getNext().getNamaNode() && rute[i].getNext().getNamaNode() == edge.getNode().getNamaNode();
                                if (edgeFirstCheck || edgeSecondCheck){
                                    comboBox1.Items.Add("INI RUTE");
                                    garis.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                                    if (i == 0){
                                        grafVisualization.FindNode(edge.getNode().getNamaNode()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.LightGreen;
                                    } else if (i == rute.Count-1){
                                        grafVisualization.FindNode(edge.getNext().getNamaNode()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.MediumBlue;
                                    } else {
                                        grafVisualization.FindNode(edge.getNode().getNamaNode()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.LightBlue;
                                        grafVisualization.FindNode(edge.getNext().getNamaNode()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.LightBlue;
                                    }
                                }
                            }                            
                        }
                    }
                }
                gViewer1.Graph = grafVisualization;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "" || comboBox3.Text != "")
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
