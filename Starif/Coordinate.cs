using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Starif
{
    class Coordinate
    {
        private double x;
        private double y;

        public Coordinate(){
            this.x = 0.0;
            this.y = 0.0;
        }
        public Coordinate(double x, double y){
            this.x = x;
            this.y = y;
        }
        public double getX(){
            return this.x;
        }
        public double getY(){
            return this.y;
        }
        public void setX(double x){
            this.x = x;
        }
        public void setY(double y){
            this.y = y;
        }
        public void printCoordinate(){
            Console.Write("(");
            Console.Write(this.x);
            Console.Write("; ");
            Console.Write(this.y);
            Console.Write(")");
        }
    }
}