using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Starif
{
    class Node
    {
        private string namaNode;
        private Coordinate koordinatNode;
        private List<Edge> edges = new List<Edge>();

        //default constructor
        public Node(){
            this.namaNode = "XXX";
            this.koordinatNode = new Coordinate();
        }

        //user defined constructor
        public Node(string namaNode, Coordinate koordinatNode){
            this.namaNode = namaNode;
            this.koordinatNode = koordinatNode;
        }

        //getter nama node
        public string getNamaNode(){
            return this.namaNode;
        }

        //getter koordinat node
        public Coordinate getKoordinatNode(){
            return this.koordinatNode;
        }

        //getter list edge node
        public List<Edge> getEdges(){
            return this.edges;
        }

        //setter nama node
        public void setNamaNode(string namaNode){
            this.namaNode = namaNode;
        }

        //setter koordinat node
        public void setKoordinatNode(Coordinate koordinatNode){
            this.koordinatNode = koordinatNode;
        }

        //menambahkan edge pada node dengan suatu next node
        public void addEdge(Node nextNode){
            int i;
            bool adaNext = false;
            bool adaCurr = false;
            i = 0;
            List<Edge> edgeCurrNode = this.getEdges();
            List<Edge> edgeNextNode = nextNode.getEdges();
            while (!adaCurr && i<edgeCurrNode.Count){              
                if (edgeCurrNode[i].getNode()==this && edgeCurrNode[i].getNext()==nextNode){
                    adaCurr = true;
                }
                i+=1;
            }
            i = 0;
            while (!adaNext && i < edgeNextNode.Count){
                if (edgeNextNode[i].getNode()==nextNode && edgeNextNode[i].getNext()==this){
                    adaNext = true;
                }
                i +=1;
            }
            double bobot = Edge.euclideanDistance(this.getKoordinatNode(),nextNode.getKoordinatNode());
            if (!adaCurr){
                this.edges.Add(new Edge(this,bobot,nextNode));
            }
            if (!adaNext){
                nextNode.getEdges().Add(new Edge(nextNode,bobot,this));
            }
        }

        //setter list edge node
        public void setEdges(List<Edge> newEdges)
        {
            this.edges = newEdges;
        } 

        //menghapus edge node dengan suatu next node
        public void removeEdge(Node nextNode){
            int i = 0;
            foreach (Edge edge in this.edges)
            {
                if(edge.getNext() == nextNode){
                    break;
                }
                i += 1;
            } 
            this.edges.RemoveAt(i);
        }
    }
}