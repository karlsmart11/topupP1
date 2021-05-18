using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.IRepository
{
    public interface IMaterialLoanRepository
    {
        bool Insert(Loan loan, Material material);
    }
}
