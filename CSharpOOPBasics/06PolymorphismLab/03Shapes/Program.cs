﻿using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Circle(3.5));
        shapes.Add(new Rectangle(3.5, 1.2));
        shapes.Add(new Rectangle(1.5, 1.5));
        shapes.Add(new Rectangle(3.4, 1.5));
        shapes.Add(new Circle(3.6));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.Draw());
        }
    }
}