using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace democonsole
{
    class Graf
    {
        private List<Node> nodeGraf;

        public Graf(){
            this.nodeGraf = new List<Node>();
        }

        public Graf(List<Node> nodeGraf){
            this.nodeGraf = nodeGraf;
        }

        public void addNode(Node node){
            this.nodeGraf.Add(node);
        }
        public void removeNode(Node node){
            this.nodeGraf.Remove(node);
        }
        public void printNode(){
            foreach (Node node in this.nodeGraf)
            {
                Console.WriteLine(node.getNamaNode());
            }
        }
    }
}