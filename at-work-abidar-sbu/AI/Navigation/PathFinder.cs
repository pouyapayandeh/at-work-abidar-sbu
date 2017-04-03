﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace at_work_abidar_sbu.AI.Navigation
{
    public class PathFinder
    {
        private int _MapWidth=800;
        private int _MapHeight=600;
		private int[] _dy = {+1, 0, -1, 0}; //Front, Left, Rear, Right
		private int[] _dx = {0, +1, 0, -1};
        private int MapWidth => _MapWidth;
//x, cm

        int MapHeight => _MapHeight;
//y, cm
        const int RobotSize = 55; //cm
        int[,] dis;
        int[,] map;
        int[,] touchWall;
        Point[,] nxt;
        Point src, dst;
        List<Point> path;
        public PathFinder()
        {
            SetUp();
        }

        private void SetUp()
        {
            path = new List<Point>();
            dis = new int[MapWidth + 10, MapHeight + 10];
            map = new int[MapWidth + 10, MapHeight + 10];
            touchWall = new int[MapWidth + 10, MapHeight + 10];
            nxt = new Point[MapWidth + 10, MapHeight + 10];
            setSrc(0, 0);
            setDst(0, 0);
            for (int i = 0; i <= MapWidth; i++)
                for (int j = 0; j <= MapHeight; j++)
                {
                    map[i, j] = 0;
                    dis[i, j] = -1;
                    touchWall[i, j] = 0;
				}
			for (int i = 0; i <= MapWidth; i++)
                for (int j = 0; j <= MapHeight; j++)
                    nxt[i, j] = new Point(-1, -1);

           
        }

        public void setSrc(int x, int y)
        {
            if (isInMap(x, y))
                src = new Point(x, y);
        }
        public void setDst(int x, int y)
        {
            if (isInMap(x, y))
                dst = new Point(x, y);
        }
        public void findPath()
        {
            for (int i = 0; i <= MapWidth; i++)
                for (int j = 0; j <= MapHeight; j++)
                    nxt[i, j] = new Point(-1, -1);
            for (int i = 0; i <= MapWidth; i++)
                for (int j = 0; j <= MapHeight; j++)
                {
                 //   map[i, j] = 0;
                    dis[i, j] = -1;
                  //  touchWall[i, j] = 0;
                }

            path.Clear();
            List<Point> q = new List<Point>();
            q.Add(src);
            dis[(int)src.x, (int)src.y] = 0;
            for (int i = 0; i < q.Count(); i++)
            {
                Point v = q[i];
                for (int k = 1; k >= 1; k--)
                    for (int dx = -1; dx <= 1; dx++)
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (Math.Abs(dx) + Math.Abs(dy) == k)
                            {
                                int x2 = (int)v.x + dx;
                                int y2 = (int)v.y + dy;
                                if (isInMap(x2, y2) && touchWall[x2, y2] == 0 && dis[x2, y2] == -1)
                                {
                                    nxt[x2, y2] = v;
                                    dis[x2, y2] = dis[(int)v.x, (int)v.y] + 1;
                                    q.Add(new Point(x2, y2));
                                }
                            }
                        }
            }
            path.Clear();
            Point cell = dst;
            while (cell.x >= 0 && cell.y >= 0 && isInMap((int)cell.x, (int)cell.y))
            {
                path.Add(cell);
                cell = nxt[(int)cell.x, (int)cell.y];
            }
            path.Reverse();
        }

        public void addObstacle(int x, int y, int w, int h, bool isWall)
        {
            int tmp = 1;
            if (isWall)
                tmp = 2;
            for (int i = x; i < x + w; i++)
                for (int j = y; j < y + h; j++)
                {
                    if (!isInMap(i, j))
                        continue;
                    map[i, j] = tmp; //1 for FULL, 0 for EMPTY
                    for (int i2 = i - RobotSize / 2; i2 <= i + RobotSize / 2; i2++)
                        for (int j2 = j - RobotSize / 2; j2 <= j + RobotSize / 2; j2++)
                            if (isInMap(i2, j2))
                                touchWall[i2, j2] = 1;
                }
        }
        public Point getSrc()
        {
            return src;
        }

        public void LoadInMap(Map map)
        {
            _MapWidth = (int)map.width;
            _MapHeight = (int)map.height;
            SetUp();
            foreach (MapObject o in map.obstacles)
            {
                addObstacle((int)o.X, (int)o.Y, (int)o.Width, (int)o.Height,o.Type==WordObjectType.Wall);
            }
        }
        public Point getDst()
        {
            return dst;
        }
        public bool isInMap(int x, int y)
        {
            if (x < 0 || x > MapWidth)
                return false;
            if (y < 0 || y > MapHeight)
                return false;
            return true;
        }
        public bool isValid(int x, int y)
        {
            if (!isInMap(x, y))
                return false;
            for (int i = x - RobotSize / 2; i <= x + RobotSize / 2; i++)
                for (int j = y - RobotSize / 2; j <= y + RobotSize / 2; j++)
                    if (!isInMap(i, j) || map[i, j] != 0) //out of bounds or obstacle
                        return false;
            return true;
        }
        public List<Point> getPath()
        {
            return path;
        }	
    }
}
