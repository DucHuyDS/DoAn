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
        int[,] adjMat1;
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
            adjMat1 = new int[max_verts, max_verts];
            nVerts = 0; nTree = 0;
            for (int j = 0; j <= max_verts - 1; j++)
            {
                for (int k = 0; k <= max_verts - 1; k++)
                {
                    adjMat[j, k] = infinity;
                    adjMat1[j, k] = 0;
                    sPath = new Distoriginal[max_verts];
                }

            }
        }
        public void AddVertex(object lab)
        {
            vertexList[nVerts] = new Vertex(lab);
            nVerts++;
        }
        public void AddEdge(int start, int theEnd, int weight)
        {
            adjMat[start, theEnd] = weight;
            adjMat1[start, theEnd] = 1;
            adjMat1[theEnd, start] = 1;
        }
        public void Path()
        {
            int startTree = 0;
            vertexList[startTree].isintree = true;
            nTree = 1;
            for (int j = 0; j <= nVerts; j++)
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
                    for (int j = i + 1; j < nVerts; j++)
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
            Displaypath();
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
            Console.WriteLine("|Thời gian ngắn nhất|");

            for (int j = 1; j < nVerts; j++)
            {
                Console.Write(">Từ {0} đến {1}: ", ((Router)vertexList[0].label).getid(), ((Router)vertexList[j].label).getid());
                Console.WriteLine(sPath[j].distance + " phút ");
                if (sPath[j].parentvert == 0)
                {

                    Console.WriteLine("Đường đi:" + ((Router)vertexList[0].label).getid() + "-" + ((Router)vertexList[j].label).getid());
                }
                else
                    Console.WriteLine("Đường đi:" + ((Router)vertexList[0].label).getid() + "-" + ff[j]);
            }
        }
        private int getadj(int v)
        {
            for (int j = 0; j <= nVerts - 1; j++)
            {
                if (adjMat1[v, j] == 1 && vertexList[j].isintree == false)
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

