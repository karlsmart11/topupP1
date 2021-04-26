using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.IRepository
{
    interface ILoan
    {
        void Insert(Loan loan);
        int Update(Loan loan);
        int Delete(string loanId);
    }
}
