using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.IRepository
{
    public interface ILoanRepository
    {
        bool Insert(Loan loan);
        bool Update(Loan loan);
        bool Delete(string loanId);
        Loan GetNewestLoan();
        int? MaterialCountBySSN(string SSN);
    }
}
