using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3
{
    public class Tshirt
    {
        public int TshirtID { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public Tshirt(int tshirtId, string size, string color)
        {
            this.TshirtID = tshirtId;
            this.Size = size;
            this.Color = color;
        }
    }
}