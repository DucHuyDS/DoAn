using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    class Program
    {
        static void menu()
        {
            Console.WriteLine("             menu    ");
            Console.WriteLine("1: Xem giá cao và thấp nhất");
            Console.WriteLine("2: Từ Router đã chọn đến tất cả các Router");
            Console.WriteLine("3: Từ Router đã chọn đến một Router khác");
            Console.WriteLine("4: Từ Router đã chọn tìm DFS và BFS");
            Console.WriteLine("5: Thoát chương trình");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("\t\tĐỒ ÁN: CẤU TRÚC DỮ LIỆU VÀ GIẢI THUẬT");
            Console.WriteLine("\t\t\tNHÓM 10, LỚP: DS001");
            Console.WriteLine("\t\tCác thành viên:");
            Console.WriteLine("\t\t-Nguyễn Đức Huy");
            Console.WriteLine("\t\t-Trương Thế Bảo");
            Console.WriteLine("\t\t-Lê Minh Hoàng");
            Console.WriteLine("\t\t-Nguyễn Văn Hoàng Dũng");
            Console.WriteLine("\t\t-Bùi Nhật Tuấn");
            Console.WriteLine("----------------------------------------------------------------------");
            int z;
            do
            {
                Console.WriteLine("-----------------------------------");
                menu();
                Console.Write("Chọn yêu cầu: ");
                z = int.Parse(Console.ReadLine());
                Graph Thegraph = new Graph();
                Thegraph.AddVertex(new Router("RT0", "11/3", 2021, 144, 250000));
                Thegraph.AddVertex(new Router("RT1", "25/4", 2020, 200, 400000));
                Thegraph.AddVertex(new Router("RT2", "8/8", 2021, 360, 700000));
                Thegraph.AddVertex(new Router("RT3", "17/6", 2018, 120, 200000));
                Thegraph.AddVertex(new Router("RT4", "22/10", 2020, 170, 300000));
                Thegraph.AddVertex(new Router("RT5", "22/10", 2019, 150, 250000));
                if(z==1)
                {
                    Thegraph.choo();
                    continue;
                }
                else if(z>=5)
                {
                    break;
                }
                Console.Write("Nhập Router bắt đầu(id): ");
                Thegraph.duong();
                Thegraph.AddEdge(0, 1, 3);
                Thegraph.AddEdge(0, 2, 2);
                Thegraph.AddEdge(0, 3, 5);
                Thegraph.AddEdge(1, 3, 1);
                Thegraph.AddEdge(1, 4, 4);
                Thegraph.AddEdge(2, 5, 1);
                Thegraph.AddEdge(2, 3, 2);
                Thegraph.AddEdge(3, 4, 3);
                Thegraph.AddEdge(5, 4, 2); 
                if (z == 2)
                {
                    Thegraph.Path(1);
                }
                else if(z==3)
                {
                    Thegraph.Path(2);
                }
                else if (z == 4)
                {
                    Console.WriteLine("-Deep First Search: ");
                    Thegraph.DepthFirstSearch();
                    Console.WriteLine("\n-Bread First Search: ");
                    Thegraph.Bread();
                }
            } while (true);
        }
    }
}
