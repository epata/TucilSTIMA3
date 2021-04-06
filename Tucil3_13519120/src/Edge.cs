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

        //default constructor
        public Edge(){
            Node defaultNode = new Node();
            this.currNode = defaultNode;
            this.bobot = 0.0;
            this.nextNode = defaultNode;
        }

        //user defined constructor
        public Edge(Node currNode, double bobot, Node nextNode){
            this.currNode = currNode;
            this.bobot = bobot;
            this.nextNode = nextNode;
        }

        //user defined constructor
        public Edge(Node currNode, Node nextNode){
            this.currNode = currNode;
            this.bobot = euclideanDistance(currNode.getKoordinatNode(), nextNode.getKoordinatNode());
            this.nextNode = nextNode;
        }

        //getter node mengembalikan node
        public Node getNode(){
            return this.currNode;
        }

        //getter bobot
        public double getBobot(){
            return this.bobot;
        }

        //getter next node
        public Node getNext(){
            return this.nextNode;
        }

        //setter node
        public void setNode(Node currNode){
            this.currNode = currNode;
        }

        //setter bobot
        public void setBobot(double bobot){
            this.bobot = bobot;
        }

        //setter next node
        public void setNext(Node next){
            this.nextNode = next;
        }

        //fungsi jarak euclidean antara dua koordinat
        public static double euclideanDistance(Coordinate A, Coordinate B){
            return(Math.Sqrt(Math.Pow((A.getX()-B.getX()),2) + Math.Pow((A.getY()-B.getY()),2)));
        }
    }
}