using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Model
{
    public class Loan
    {
        public int LoanId { get; set; }
        public DateTime StartDate { get; set; }
        public string MemberSSN { get; set; }
    }
}
