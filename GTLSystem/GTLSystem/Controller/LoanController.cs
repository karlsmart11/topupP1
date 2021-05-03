using GTLSystem.Model;
using GTLSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTLSystem.Controller
{
    class LoanController        
    {
        MemberRepository memberRepository = new MemberRepository();
        LoanRepository loanRepository = new LoanRepository();
        TitleRepository titleRepository = new TitleRepository();
        MaterialRepository materialRepository = new MaterialRepository();
        MaterialController materialController = new MaterialController();
        MaterialLoanController materialLoanController = new MaterialLoanController();

        public int RegisterLoan(String ssn, List<string> isbns)
        {
            int result = 1;
            Member member = memberRepository.GetBySSN(ssn);
            List<Material> materials = new List<Material>();
            List<string> unavailable = new List<string>();

            foreach (var isbn in isbns)
            {
                var material = materialRepository.GetAvailableByISBN(isbn, true);

                if (material.Count() > 0)
                {
                    materials.Add(material.First());
                    materialController.ReserveMaterial(material.First());
                }
                else
                {
                    unavailable.Add(isbn);
                }                
            }

            if (unavailable.Count == isbns.Count)
            {
                result = 0;
            }

            if (member != null && result != 0)
            {
                Loan loan = new Loan()
                {
                    StartDate = DateTime.Now,
                    MemberSSN = member.SSN
                };

                try
                {
                    loanRepository.Insert(loan);
                }
                catch (Exception)
                {
                    result = -1;
                }
                
                loan = loanRepository.GetNewestLoan();

                foreach (var material in materials)
                {
                    try
                    {
                        materialLoanController.CreateMaterialLoan(loan, material);
                    }
                    catch (Exception)
                    {
                        result = -1;
                    }                    
                }
            }

            return result;
        }

        public int GetCurrentNoOfMaterialsBySSN(string SSN)
        {
            return loanRepository.MaterialCountBySSN(SSN);
        }
    }
}
