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
        private List<Edge> edges;
        public Node(){
            this.namaNode = "XXX";
            this.koordinatNode = new Coordinate();
            this.edges = new List<Edge>();
        }
        public Node(string namaNode, Coordinate koordinatNode, List<Edge> edges){
            this.namaNode = namaNode;
            this.koordinatNode = koordinatNode;
            this.edges = edges;
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
        public void addEdge(Edge e) {
            this.edges.add(e);
        }
        public void removeEdge() {
            
        }
    }
}