using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Model
{
    public class Material
    {
        public int MaterialId { get; set; }
        public String Type { get; set; }
        public String ISBN { get; set; }
        public bool Available { get; set; }
    }
}
