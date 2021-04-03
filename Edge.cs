using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace democonsole
{
    class Edge 
    {
        private Node currNode;
        private double bobot;
        private Node nextNode;

        public Edge(){
            Coordinate defaultNodeCoordinate = new Coordinate(0,0);
            Node defaultNode = new Node("XXX",defaultNodeCoordinate);
            this.currNode = defaultNode;
            this.bobot = 0.0;
            Node defaultNode = new Node("XXX",defaultNodeCoordinate);
            this.nextNode = defaultNode;
        }
        public Edge(Node currNode, int bobot, Node nextNode){
            this.currNode = currNode;
            this.bobot = bobot;
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
    }
}