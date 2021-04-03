using System;
using System.IO;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace democonsole
{
    class Graf
    {
        private List<Node> nodeGraf;

        public Graf(int N){
            this.nodeGraf = new List<Node>(N);
        }

        public Graf(List<Node> nodeGraf){
            this.nodeGraf = nodeGraf;
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