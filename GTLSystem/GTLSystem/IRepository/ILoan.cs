using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.IRepository
{
    public interface ILoan
    {
        void Insert(Loan loan);
        int Update(Loan loan);
        int Delete(string loanId);
        Loan GetNewestLoan();
        int MaterialCountBySSN(string SSN);
    }
}
