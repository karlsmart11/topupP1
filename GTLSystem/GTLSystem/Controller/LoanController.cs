using GTLSystem.Model;
using GTLSystem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Controller
{
    class LoanController        
    {
        MemberRepository memberRepository = new MemberRepository();
        LoanRepository loanRepository = new LoanRepository();

        public bool RegisterLoan(String ssn)
        {
            bool result;

            Member member = memberRepository.GetBySSN(ssn);

            if (member != null)
            {
                Loan loan = new Loan()
                {
                    StartDate = DateTime.Now,
                    MemberSSN = member.SSN
                };

                loanRepository.Insert(loan);
                result = true;
            } else result = false;

            return result;
        }
    }
}
