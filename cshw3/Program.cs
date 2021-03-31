using System;
using System.Collections.Generic;

namespace cshw3
{
    internal abstract class Shape
    {
        public abstract string Name { get; }
        public abstract double Area { get; }
    }
    
    internal interface IValidator
    {
        bool IsValid();
    }

    internal class Rectangle : Shape
    {
        private readonly double _length;
        private readonly double _width;
        public double length => _length;
        public Rectangle(int length, int width) 
        {
            _length = length;
            _width = width;
        }
        public override string Name => "长方形";
        public override double Area => _length * _width;
    }

    internal class Square : Shape
    {
        private readonly double _side;
        public double side => _side;
        public Square(double side)
        {
            _side = side;
        }

        public override string Name => "正方形";
        public override double Area => _side * _side;
    }

    internal class Triangle : Shape, IValidator
    {
        private readonly double[] _sides = {0, 0, 0};
        public double[] sides => _sides;
        public Triangle(double side1, double side2, double side3)
        {
            _sides[0] = side1;
            _sides[1] = side2;
            _sides[2] = side3;
            Validate();
        }

        public override string Name => "三角形";

        public override double Area
        {
            get
            {
                var p = (_sides[0] + _sides[1] + _sides[2]) / 2.0;
                return Math.Sqrt(p * (p - _sides[0]) * (p - _sides[1]) * (p - _sides[2]));
            }
        }
        public bool IsValid()
        {
            var flag =  sides[0] + sides[1] > sides[2] &&
                   sides[0] + sides[2] > sides[1] &&
                   sides[1] + sides[2] > sides[0];
            return flag;
        }
        private void Validate()
        {
            if (!IsValid()) throw new Exception();
        }
    }

    internal abstract class Factory
    {
        void Generate() {}
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            var a = new Triangle(3, 4, 5);
            Console.WriteLine(a.sides);
        }
    }
}