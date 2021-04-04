using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Starif
{
    class Edge 
    {
        private Node currNode;
        private double bobot;
        private Node nextNode;

        public Edge(){
            Node defaultNode = new Node();
            this.currNode = defaultNode;
            this.bobot = 0.0;
            this.nextNode = defaultNode;
        }
        public Edge(Node currNode, double bobot, Node nextNode){
            this.currNode = currNode;
            this.bobot = bobot;
            this.nextNode = nextNode;
        }
        public Edge(Node currNode, Node nextNode){
            this.currNode = currNode;
            this.bobot = euclideanDistance(currNode.getKoordinatNode(), nextNode.getKoordinatNode());
            this.nextNode = nextNode;
        }
        public Node getNode(){
            return this.currNode;
        }
        public double getBobot(){
            return this.bobot;
        }
        public Node getNext(){
            return this.nextNode;
        }
        public void setNode(Node currNode){
            this.currNode = currNode;
        }
        public void setBobot(double bobot){
            this.bobot = bobot;
        }
        public void setNext(Node next){
            this.nextNode = next;
        }

        public static double euclideanDistance(Coordinate A, Coordinate B){
            return(Math.Sqrt(Math.Pow((A.getX()-B.getX()),2) + Math.Pow((A.getY()-B.getY()),2)));
        }
    }
}