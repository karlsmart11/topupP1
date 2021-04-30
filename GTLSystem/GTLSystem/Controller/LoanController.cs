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

        public bool RegisterLoan(String ssn, List<string> isbns)
        {
            bool result = false;
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



            foreach (var item in materials)
            {
                Console.WriteLine(item.MaterialId);
            }

            if (member != null)
            {
                Loan loan = new Loan()
                {
                    StartDate = DateTime.Now,
                    MemberSSN = member.SSN
                };

                loanRepository.Insert(loan);
                result = true;
            }

            return result;
        }
    }
}
