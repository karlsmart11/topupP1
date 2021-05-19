using GTLSystem.IRepository;
using GTLSystem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Controller
{


    public class ControllerContainer
    {
        public ControllerContainer(IMaterialRepository materialRepository,
                                   IMaterialLoanRepository materialLoanRepository,
                                   ITitleRepository titleRepository,
                                   IMemberRepository memberRepository,
                                   ILoanRepository loanRepository)
        {
            materialController = new MaterialController(materialRepository);
            materialLoanController = new MaterialLoanController(materialLoanRepository);
            titleController = new TitleController(titleRepository);
            memberController = new MemberController(memberRepository);
            loanController = new LoanController(loanRepository);
        }

        public MaterialController materialController;
        public MaterialLoanController materialLoanController;
        public TitleController titleController;
        public MemberController memberController;
        public LoanController loanController;
    }
}
