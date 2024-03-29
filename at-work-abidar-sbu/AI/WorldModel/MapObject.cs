﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;

namespace at_work_abidar_sbu
{
    public class MapObject
    {

        public string Name { get; set; }
        public WorldObjectType Type { get; set; }

        [JsonIgnore]
        public RectangleF Bound {
            get
            {
                return new RectangleF((float)X, (float)Y, (float)Width, (float)Height);
            }
        }

        public MapObject()
        {
        }

        public MapObject(WorldObjectType type,string name ,double x,double y,int width,int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Type = type;
            Name = name;
        }
        public MapObject(WorldObjectType type, double x, double y, int width, int height) : this(type, "", x, y, width, height)
        {
        }
        public MapObject(WorldObjectType type, double x, double y):this(type,"",x,y,10,10)
        {
        }

        public override string ToString()
        {
            return Type + " "+Name;
        }

        public double X { get; set; }
       public double Y { get; set; }
       public double Width { get; set; }
       public double Height { get; set; }

        public bool Left { get; set; }
        public bool Up { get; set; }
        public bool Right { get; set; }
        public bool Down { get; set; }

        // void draw(Bitmap scene);
    }
}
