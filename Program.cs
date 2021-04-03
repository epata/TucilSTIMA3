using System;

namespace democonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Graf G = new Graf();
            Coordinate A = new Coordinate(1,2);
            Node jambi = new Node("Jambi", A,  jambiBetung);
            Node betung = new Node("Betung", A, jambiBetung);
            Node palembang = new Node("Palembang", A, palembangIndralaya);
            Node indralaya = new Node("Indralaya", A, palembangIndralaya);
            Edge jambiBetung = new Edge(jambi, 200, betung);
            Edge palembangIndralaya = new Edge(palembang, 330, indralaya);
            
            //Node(string namaNode, Coordinate koordinatNode, List<Edge> edges);
            G.addNode(jambi);
            G.addNode(betung);
            G.addNode(palembang);
            G.addNode(indralaya);
            G.printNode();
            //Console.WriteLine("Hello World!");
            Console.WriteLine("TES");
        }
    }
}
