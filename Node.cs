using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace democonsole
{
    class Node
    {
        private string namaNode;
        private Coordinate koordinatNode;
        private List<Edge> edges = new List<Edge>();
        
        public Node(){
            this.namaNode = "XXX";
            this.koordinatNode = new Coordinate();
        }
        public Node(string namaNode, Coordinate koordinatNode){
            this.namaNode = namaNode;
            this.koordinatNode = koordinatNode;
        }
        public string getNamaNode(){
            return this.namaNode;
        }
        public Coordinate getKoordinatNode(){
            return this.koordinatNode;
        }
        public List<Edge> getEdges(){
            return this.edges;
        }
        public void setNamaNode(string namaNode){
            this.namaNode = namaNode;
        }
        public void setKoordinatNode(Coordinate koordinatNode){
            this.koordinatNode = koordinatNode;
        }

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