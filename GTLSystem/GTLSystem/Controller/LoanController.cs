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
            int result;
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

            if (member != null)
            {
                Loan loan = new Loan()
                {
                    StartDate = DateTime.Now,
                    MemberSSN = member.SSN
                };

                loanRepository.Insert(loan);
                loan = loanRepository.getNewestBySSN(loan.MemberSSN);

                //materialLoanController.CreateMaterialLoan();

                try
                {
                    loanRepository.Insert(loan);
                }
                catch (Exception)
                {
                    result = -1;
                }
                
                result = 1;
            }
            else
            {
                result = -1;
            }

            return result;
        }
    }
}
