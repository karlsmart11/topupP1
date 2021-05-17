using GTLSystem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Controller
{


    public class ControllerContainer
    {
        private DbConnection _connection;
        public ControllerContainer(DbConnection connection)
        {
            _connection = connection;
            materialController = new MaterialController(new MaterialRepository(_connection));
            materialLoanController = new MaterialLoanController(new MaterialLoanRepository(_connection));
            titleController = new TitleController(new TitleRepository(_connection));
            memberController = new MemberController(new MemberRepository(_connection));
            loanController = new LoanController(new LoanRepository(_connection));
        }

        public MaterialController materialController;
        public MaterialLoanController materialLoanController;
        public TitleController titleController;
        public MemberController memberController;
        public LoanController loanController;
    }
}
