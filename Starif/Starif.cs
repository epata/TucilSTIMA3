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
        private string[] input;
        private Graf graf;
        public Starif()
        {   
            InitializeComponent();
        }

        //browse
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            //string directory;
            Microsoft.Msagl.Drawing.Graph grafVisualization = new Microsoft.Msagl.Drawing.Graph("graf");
            browse.Filter = "*.txt (file berekstensi txt) | *.txt";
            if (browse.ShowDialog() == DialogResult.OK)
            {   
                int i;
                string fileDirectory = browse.FileName;
                string filename = browse.SafeFileName;
                input = File.ReadAllLines(fileDirectory);
                label4.Text = filename;
                graf = new Graf(input);
                //menambahkan simpul simpul pada comboBox
                for (i = 1; i <= graf.getGraphNode().Count; i++)
                {
                    comboBox2.Items.Add(graf.getGraphNode()[i-1].getNamaNode());
                    comboBox3.Items.Add(graf.getGraphNode()[i-1].getNamaNode());
                }
                //visualisasi graf awal
                grafVisualization = FrontEndUtility.grafVisualization(graf);
                gViewer1.Graph = grafVisualization;
            }
        }

        //submit
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "awal" && comboBox3.Text != "tujuan")
            {
                label7.Text = "";
                //label4.Text = "Jalur";
                Microsoft.Msagl.Drawing.Graph grafVisualization = new Microsoft.Msagl.Drawing.Graph("graf");
                int i, j;
                // input simpul awal dan tujuan
                string awal = comboBox2.Text;
                string tujuan = comboBox3.Text;

                graf = new Graf(input);
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
                    List<Node> ruteNode = new List<Node>();
                    Node nodeAwalAlgo = nodeAwal;

                    j = 0;
                    while (nodeAwalAlgo != nodeTujuan) //selama nodeAwalAlgo bukan nodeTujuan
                    {
                        ruteNode.Add(nodeAwalAlgo);
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
                            if (!ruteNode.Contains(nodeAwalAlgo.getEdges()[i].getNext()))
                            {
                                results.Add(nodeAwalAlgo.getEdges()[i].getNext(), f);
                            }
                             
                            i += 1;
                        }
                        Node tempNodeAwal = nodeAwalAlgo;
                        if (results.Count > 0)
                        {
                            nodeAwalAlgo = results.OrderBy(KeyValuePair => KeyValuePair.Value).First().Key;
                            Edge edgeRute = new Edge(tempNodeAwal, nodeAwalAlgo);
                            rute.Add(edgeRute);
                        } 
                        else
                        {
                            break;
                        }                       
                    }

                    //visualisasi graf hasil
                    grafVisualization = FrontEndUtility.colorizedGrafVisualization(graf, rute);
                    gViewer1.Graph = grafVisualization;

                    //hitung jarak rute yang dihasilkan
                    double sumBobot = 0;
                    foreach (Edge edge in rute)
                    {
                        sumBobot += edge.getBobot() * 100000;
                    }
                    label7.Text = sumBobot.ToString();

                    //kasus tidak ada tujuan
                    if (nodeAwalAlgo != nodeTujuan)
                    {
                        grafVisualization = FrontEndUtility.grafVisualization(graf);
                        gViewer1.Graph = grafVisualization;
                        label7.Text = "Tidak ada jalur";
                    }
                }
            } 
            else
            {
                label4.Text = "Tidak ada jalur";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
