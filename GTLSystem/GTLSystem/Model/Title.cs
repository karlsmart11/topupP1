using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Model
{
    class Title
    {
        private String ISBN { get; set; }
        private bool Requested { get; set; }
        private String TitleName { get; set; }
        private String Description { get; set; }
        private bool Available { get; set; }
        private String Author { get; set; }
        private String Subject { get; set; }
        private bool Loanable { get; set; }
    }
}
