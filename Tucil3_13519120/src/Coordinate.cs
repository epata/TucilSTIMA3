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

        //default constructor
        public Coordinate(){
            this.x = 0.0;
            this.y = 0.0;
        }

        //user defined constructor
        public Coordinate(double x, double y){
            this.x = x;
            this.y = y;
        }

        //getter x
        public double getX(){
            return this.x;
        }

        //getter y
        public double getY(){
            return this.y;
        }

        //setter x
        public void setX(double x){
            this.x = x;
        }

        //setter y
        public void setY(double y){
            this.y = y;
        }
    }
}