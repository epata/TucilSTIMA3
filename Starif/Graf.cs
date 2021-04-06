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

        public Graf(int N){
            this.nodeGraf = new List<Node>(N);
        }

        public Graf(List<Node> nodeGraf){
            this.nodeGraf = nodeGraf;
        }

        //cconst
        public Graf(Graf G)
        {
            this.nodeGraf = G.nodeGraf;
        }

        public Node addNode(string namaNode, Coordinate koordinatNode){
            Node addedNode = new Node(namaNode, koordinatNode);
            nodeGraf.Add(addedNode);
            return addedNode;
        }
        public void addNode(Node node){
            this.nodeGraf.Add(node);
        }
        public void removeNode(Node node){
            this.nodeGraf.Remove(node);
        }

        public List<Node> getGraphNode(){
            return this.nodeGraf;
        }
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

        public void setListNodes(List<Node> newNodes)
        {
            this.nodeGraf = newNodes;
        }
        public void printNodeAndEdge(){
            foreach (Node node in this.nodeGraf)
            {
                Console.Write(node.getNamaNode());
                Console.WriteLine(" Tetangganya: ");
                int i = 0;
                foreach (var edge in node.getEdges()){
                    i+=1;
                    Console.Write("Bobot: ");
                    Console.Write(edge.getBobot());
                    Console.Write("; ");
                    Console.Write(i);
                    Console.Write(". ");
                    Console.WriteLine(edge.getNext().getNamaNode());
                }
            }
        }
    }
}