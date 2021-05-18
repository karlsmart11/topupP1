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
        IMaterialLoanRepository _materialLoanRepository;

        public MaterialLoanController(IMaterialLoanRepository materialLoanRepository)
        {
            _materialLoanRepository = materialLoanRepository;
        }

        public bool CreateMaterialLoan(Loan loan, Material material)
        {
            return _materialLoanRepository.Insert(loan, material);        
        }
    }
}
