using GTLSystem.IRepository;
using GTLSystem.Model;
using GTLSystem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Controller
{
    public class MaterialLoanController
    {
        static DbConnection connection = new DbConnection();
        private IMaterialLoanRepository materialLoanRepository = new MaterialLoanRepository(connection);
        public bool CreateMaterialLoan(Loan loan, Material material)
        {
            MaterialLoan materialLoan = new MaterialLoan() { LoanId = loan.LoanId, MaterialId = material.MaterialId };
            bool result = true;

            try
            {
                materialLoanRepository.Insert(materialLoan);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}
