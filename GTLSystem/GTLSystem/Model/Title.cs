using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Model
{
    class Title
    {
        public String ISBN { get; set; }
        public bool Requested { get; set; }
        public String TitleName { get; set; }
        public String Description { get; set; }
        public bool Available { get; set; }
        public String Author { get; set; }
        public String Subject { get; set; }
        public bool Loanable { get; set; }
    }
}
