using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Graph Thegraph = new Graph();
            Thegraph.AddVertex(new Router("RT0", "11/3", 2021, 144, 250000));
            Thegraph.AddVertex(new Router("RT1", "25/4", 2020, 200, 400000));
            Thegraph.AddVertex(new Router("RT2", "8/8", 2021, 360, 700000));
            Thegraph.AddVertex(new Router("RT3", "17/6", 2018, 120, 200000));
            Thegraph.AddVertex(new Router("RT4", "22/10", 2020, 170, 300000));
            Thegraph.AddVertex(new Router("RT5", "22/10", 2019, 150, 250000));
            Thegraph.AddEdge(0, 1, 3);
            Thegraph.AddEdge(0, 2, 2);
            Thegraph.AddEdge(0, 3, 5);
            Thegraph.AddEdge(1, 3, 1);
            Thegraph.AddEdge(1, 4, 4);
            Thegraph.AddEdge(2, 5, 1);
            Thegraph.AddEdge(2, 3, 2);
            Thegraph.AddEdge(3, 4, 3);
            Thegraph.AddEdge(5, 4, 2);
            Thegraph.Path();
            Console.WriteLine("-Deep First Search: ");
            Thegraph.DepthFirstSearch();
            Console.WriteLine("\n-Bread First Search: ");
            Thegraph.Bread();
            Console.WriteLine();
            Thegraph.choo();

        }
    }
}
