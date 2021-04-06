using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Starif
{
    class Graf
    {
        private List<Node> nodeGraf;

        //user defined graf constructor
        public Graf(string[] input)
        {
            int i, j;
            int N = Int32.Parse(input[0]);
            this.nodeGraf = new List<Node>(N);
            for (i = 1; i <= N; i++)
            {

                double x = Convert.ToDouble(input[i].Split(" ")[1], CultureInfo.InvariantCulture);
                double y = Convert.ToDouble(input[i].Split(" ")[2], CultureInfo.InvariantCulture);
                double z = x + y;

                Coordinate nodeCoordinate = new Coordinate(x, y);
                string namaNode = input[i].Split(" ")[0];
                //Node node = new Node(namaNode, nodeCoordinate);
                this.addNode(namaNode, nodeCoordinate);
            }
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    if (input[i + N + 1].Split("  ")[j] == "1")
                    {
                        this.nodeGraf[i].addEdge(this.nodeGraf[j]);
                    }
                }
            }
        }

        //user defined graf constructor 
        public Graf(int N){
            this.nodeGraf = new List<Node>(N);
        }

        //user defined graf constructor
        public Graf(List<Node> nodeGraf){
            this.nodeGraf = nodeGraf;
        }

        //graf copy constructor
        public Graf(Graf G)
        {
            this.nodeGraf = G.nodeGraf;
        }

        //menambahkan node ke graf dan mengembalikan node tersebut
        public Node addNode(string namaNode, Coordinate koordinatNode){
            Node addedNode = new Node(namaNode, koordinatNode);
            nodeGraf.Add(addedNode);
            return addedNode;
        }

        //menambahkan node (prosedural)
        public void addNode(Node node){
            this.nodeGraf.Add(node);
        }

        //menghapus node 
        public void removeNode(Node node){
            this.nodeGraf.Remove(node);
        }

        //getter list node graf
        public List<Node> getGraphNode(){
            return this.nodeGraf;
        }

        //mengecek apakah ada node pada graf
        public bool searchNode(Node node){
            bool ketemu = false;
            int i = 0;
            while (!ketemu && i < this.nodeGraf.Count){
                if (nodeGraf[i] == node){
                    ketemu = true;
                }
                i+=1;
            }
            return ketemu;
        }

        //mengecek apakah ada node pada graf dan mengembalikan node tersebut jika ada
        public Node searchNode(string namaNode){
            int i = 0;
            while (i < this.nodeGraf.Count){
                if (nodeGraf[i].getNamaNode() == namaNode){
                    return nodeGraf[i];
                }
                i+=1;
            }
            return null;
        }

        //setter list node graf
        public void setListNodes(List<Node> newNodes)
        {
            this.nodeGraf = newNodes;
        }
    }
}