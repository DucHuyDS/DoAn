using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DoAn
{
    class Distoriginal
    {
        public int distance;
        public int parentvert;
        public Distoriginal(int pv, int d)
        {
            distance = d;
            parentvert = pv;
        }
    }
    class Vertex
    {
        public object label;
        public bool isintree;
        public Vertex(object lab)
        {
            label = lab;
            isintree = false;
        }
    }
    class Graph
    {
        private const int max_verts = 20;
        int infinity = 1000000;
        int nTree;
        Distoriginal[] sPath;
        int currentVert;
        int startToCurrent;
        public int nVerts;
        public Vertex[] vertexList;
        public int[,] adjMat;
        public string[] ff = new string[10];
        public Graph()
        {
            vertexList = new Vertex[max_verts];
            adjMat = new int[max_verts, max_verts];
            nVerts = 0; nTree = 0;
            for (int j = 0; j <= max_verts - 1; j++)
            {
                for (int k = 0; k <= max_verts - 1; k++)
                {
                    adjMat[j, k] = infinity;
                    sPath = new Distoriginal[max_verts];
                }

            }
        } 
        public void AddVertex(object lab)
        {
            vertexList[nVerts] = new Vertex(lab);
            nVerts++;
        }
        private string f;
        public string duong()
        {
            f = Console.ReadLine();
            return f;
        }
        public int start1()
        {
        test:
            for (int i = 0; i < nVerts; i++)
            {
                if (f.ToUpper() == ((Router)vertexList[i].label).getid())
                {
                    return i;
                }
            }
            Console.Write("Không tìm thấy Router xin nhập lại: ");
            f = Console.ReadLine();
            goto test;

        }
        public void AddEdge(int start, int theEnd, int weight)
        {
            if (start == start1())
            {
                adjMat[0, theEnd] = weight;
                adjMat[theEnd, 0] = weight;
            }
            else if (theEnd == start1())
            {
                adjMat[start, 0] = weight;
                adjMat[0, start] = weight;
            }
            else if (start == 0)
            {
                adjMat[start1(), theEnd] = weight;
                adjMat[theEnd, start1()] = weight;
            }
            else if (theEnd == 0)
            {
                adjMat[start, start1()] = weight;
                adjMat[start1(), start] = weight;
            }
            else
            {
                adjMat[start, theEnd] = weight;
                adjMat[theEnd, start] = weight;
            }
            for (int i = 0; i < nVerts; i++)
            {
                if (adjMat[i, i] < infinity)
                {
                    adjMat[i, start1()] = adjMat[i, i];
                    adjMat[i, i] = infinity;
                }
            }
        }
        public void Path(int t)
        {
            vertexList[nVerts] = vertexList[start1()];
            vertexList[start1()] = vertexList[0];
            vertexList[0] = vertexList[nVerts];
            int startTree = 0;
            vertexList[startTree].isintree = true;
            nTree = 1;
            for (int j = 0; j <= nVerts - 1; j++)
            {
                int tempDist = adjMat[startTree, j];
                sPath[j] = new Distoriginal(startTree, tempDist);
            }
            while (nTree < nVerts)
            {
                int indexMin = GetMin();
                int minDist = sPath[indexMin].distance;
                currentVert = indexMin;
                startToCurrent = sPath[indexMin].distance;
                vertexList[currentVert].isintree = true;
                nTree++;
                AdjustShortPath();
            }
            for (int i = 0; i < nVerts; i++)
            {
                if (ff[i] != null)
                {
                    for (int j = 0; j < nVerts; j++)
                    {
                        if (ff[j] != null)
                        {
                            string g = ff[i].Substring(0, ((Router)vertexList[i].label).getid().Length);
                            string g1 = ff[j].Substring(ff[j].Length - ((Router)vertexList[i].label).getid().Length);
                            if (g == g1)
                            {
                                string h = ff[i].Substring(ff[i].Length - ((Router)vertexList[i].label).getid().Length);
                                ff[i] = ff[j] + "-" + h;
                            }
                        }
                    }
                }
            }
            if(t==1)
            {
                Displaypath();
            }
            else if (t == 2)
            {
                lone();
            }
            else if(t==3)
            {

            }
            nTree = 0;
            for (int j = 0; j <= nVerts - 1; j++)
                vertexList[j].isintree = false;
        }
        public int GetMin()
        {
            int minDist = infinity;
            int indexMin = 0;
            for (int j = 1; j <= nVerts - 1; j++)
            {
                if (!(vertexList[j].isintree) && sPath[j].distance < minDist)
                {
                    minDist = sPath[j].distance;
                    indexMin = j;
                }
            }
            return indexMin;
        }
        public void AdjustShortPath()
        {
            int column = 1;
            while (column < nVerts)
                if (vertexList[column].isintree)
                {
                    column++;
                }
                else
                {
                    int currentToFring = adjMat[currentVert, column];
                    int startToFringe = startToCurrent + currentToFring;
                    int sPathDist = sPath[column].distance;
                    if (startToFringe < sPathDist)
                    {
                        ff[column] = ((Router)vertexList[currentVert].label).getid() + "-" + ((Router)vertexList[column].label).getid();
                        sPath[column].parentvert = currentVert;
                        sPath[column].distance = startToFringe;

                    }
                    column++;

                }
        }
        public void Displaypath()
        {
            Console.WriteLine("|Thời gian ngắn nhất để kết nối đến tất cả các Router còn lại|");
            for (int j = 1; j < nVerts; j++)
            {
                Console.Write("->Từ {0} đến {1}: ", ((Router)vertexList[0].label).getid(), ((Router)vertexList[j].label).getid());
                Console.WriteLine(sPath[j].distance + " phút ");
                if (sPath[j].parentvert == 0 || sPath[j].parentvert == infinity)
                {

                    Console.WriteLine("Đường đi:" + ((Router)vertexList[0].label).getid() + "-" + ((Router)vertexList[j].label).getid());
                }
                else
                    Console.WriteLine("Đường đi:" + ((Router)vertexList[0].label).getid() + "-" + ff[j]);

            }
        }
        public string lone()
        {
            Group10:
            int u = 0;
            Console.ResetColor();
            Console.Write("Đến Router mong muốn(id): ");
            string s = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            for (int j = 1; j < nVerts; j++)
            {
                if (s.ToUpper() == ((Router)vertexList[j].label).getid())
                {
                    u++;
                    Console.Write("->Từ {0} đến {1}: ", ((Router)vertexList[0].label).getid(), ((Router)vertexList[j].label).getid());
                    Console.WriteLine(sPath[j].distance + " phút ");
                    if (sPath[j].parentvert == 0 || sPath[j].parentvert == infinity)
                    {

                       Console.WriteLine("Đường đi:" + ((Router)vertexList[0].label).getid() + "-" + ((Router)vertexList[j].label).getid());
                    }
                    else
                        Console.WriteLine("Đường đi:" + ((Router)vertexList[0].label).getid() + "-" + ff[j]);
                }
            }
            if(u==0)
            {
                Console.WriteLine("Không tìm thấy Router xin nhập lại");
                goto Group10;
            }
            return null;
        }
        private int getadj(int v)
        {
            for (int j = 0; j <= nVerts - 1; j++)
            {
                if (adjMat[v, j] != infinity && vertexList[j].isintree == false)
                {
                    return j;
                }
            }
            return -1;
        }
        public void showvertex(int v)
        {
            Console.Write(((Router)vertexList[v].label).getid() + " ");
        }
        public void DepthFirstSearch()
        {
            Path(0);
            vertexList[0].isintree = true;
            showvertex(0);
            Stack gStack = new Stack();
            gStack.Push(0);
            int v;
            while (gStack.Count > 0)
            {
                v = getadj((int)gStack.Peek());
                if (v == -1) gStack.Pop();
                else
                {
                    vertexList[v].isintree = true;
                    showvertex(v);
                    gStack.Push(v);
                }
            }
            for (int j = 0; j <= nVerts - 1; j++)
                vertexList[j].isintree = false;
        }
        public void Bread()
        {
            Path(0);
            Queue gque = new Queue();
            vertexList[0].isintree = true;
            showvertex(0);
            gque.Enqueue(0);
            int ver1, ver2;
            while (gque.Count > 0)
            {
                ver1 = (int)gque.Dequeue();
                ver2 = getadj(ver1);
                while (ver2 != -1)
                {
                    vertexList[ver2].isintree = true;
                    showvertex(ver2);
                    gque.Enqueue(ver2);
                    ver2 = getadj(ver1);
                }
            }
            for (int i = 0; i <= nVerts - 1; i++)
            {
                vertexList[i].isintree = false;
            }
            Console.WriteLine();
        }
        public void choo()
        {

            long z = 0, t = 100000000;
            Router v = new Router("", "", 0, 0, 0);
            Router v1 = new Router("", "", 0, 0, 0);
            for (int j = 0; j <= nVerts - 1; j++)
            {
                if (((Router)vertexList[j].label).getgia() > z)
                {
                    z = ((Router)vertexList[j].label).getgia();
                    v = (Router)vertexList[j].label;
                }
                if (((Router)vertexList[j].label).getgia() < t)
                {
                    t = ((Router)vertexList[j].label).getgia();
                    v1 = (Router)vertexList[j].label;
                }
            }
            Console.WriteLine("->Router có giá tiền cao nhất: " + v);
            Console.WriteLine("->Router có giá tiền thấp nhất: " + v1);
        }
    }
}

