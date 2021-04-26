using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Model
{
    class Loan
    {
        public DateTime StartDate { get; set; }
        public string MemberSSN { get; set; }
        public List<Material> materials;
    }
}
