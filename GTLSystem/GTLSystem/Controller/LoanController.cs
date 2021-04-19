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

        public void RegisterLoan(String ssn)
        {
            Member member = memberRepository.GetBySSN(ssn);

            Loan loan = new Loan()
            {
                StartDate = DateTime.Now,
                MemberSSN = member.SSN                
            };

            loanRepository.Insert(loan);
        }
    }
}
