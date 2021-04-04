using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Starif
{
    class ProgramGIT
    {   
        static void Main(string[] args)
        {
            int i, j;
            string[] input = File.ReadAllLines(@"input.txt");
            int N = Int32.Parse(input[0]);
            Graf graf = new Graf(N);
            for (i = 1; i <= N; i++){
                double x = Convert.ToDouble(input[i].Split(" ")[1]);
                double y = Convert.ToDouble(input[i].Split(" ")[2]);
                Coordinate nodeCoordinate = new Coordinate(x,y);
                string namaNode = input[i].Split(" ")[0];
                //Node node = new Node(namaNode, nodeCoordinate);
                graf.addNode(namaNode, nodeCoordinate);
            }
            for (i = 0; i < N; i++){
                for (j = 0; j < N; j++){
                    if (input[i+N+1].Split("  ")[j] == "1"){
                        graf.getGraphNode()[i].addEdge(graf.getGraphNode()[j]); 
                    }
                }
                Console.WriteLine();
            }
            graf.printNodeAndEdge();
            // input simpul awal dan tujuan
            Console.Write("Masukkan node awal: ");
            string awal = Console.ReadLine();
            Console.Write("Masukkan node tujuan: ");
            string tujuan = Console.ReadLine();
            
            Node nodeAwal = graf.searchNode(awal);
            Node nodeTujuan = graf.searchNode(tujuan);
            
            if (!graf.searchNode(nodeAwal) || !graf.searchNode(nodeTujuan)){
                Console.WriteLine("Simpul tidak ada");
            } else {
                //ALGORITMA A*
                Node nodeAwalAlgo = nodeAwal;
                j = 0;
                while (nodeAwalAlgo != nodeTujuan){
                    Dictionary<Node,double> results = new Dictionary<Node, double>();
                    int jumlahEdges = nodeAwalAlgo.getEdges().Count;
                    i = 0;
                    j+=1;
                    while(i<jumlahEdges){
                        //g(n) = distance dari nodeAwalAlgo ke n
                        double g = nodeAwalAlgo.getEdges()[i].getBobot();
                        //h(n) = straight line distance from n ke nodeTujuan
                        double h = Edge.euclideanDistance(nodeAwalAlgo.getEdges()[i].getNext().getKoordinatNode(), nodeTujuan.getKoordinatNode());
                        //f(n) = g(n) + h(n)
                        double f = g+h;
                        Console.Write("hasil f(n) = ");
                        Console.WriteLine(f);
                        results.Add(nodeAwalAlgo.getEdges()[i].getNext(),f);
                        
                        i+=1;
                    }
                    
                    nodeAwalAlgo = results.OrderBy(KeyValuePair => KeyValuePair.Value).First().Key;
                    Console.Write("n");
                    Console.Write(j);
                    Console.Write(" ");
                    Console.WriteLine(nodeAwalAlgo.getNamaNode());
                }
            }
        }
    }
}