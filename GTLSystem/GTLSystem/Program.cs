using GTLSystem.Controller;
using GTLSystem.Repository;
using GTLSystem.TUI;

namespace GTLSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Tui.Start(controllerConfig());
        }

        static private ControllerContainer controllerConfig()
        {
            var db = new DbConnection();
            var materialRepository = new MaterialRepository(db);
            var materialLoanRepository = new MaterialLoanRepository(db);
            var titleRepository = new TitleRepository(db);
            var memberRepository = new MemberRepository(db);
            var loanRepository = new LoanRepository(db);

            return new ControllerContainer(materialRepository, materialLoanRepository, titleRepository, memberRepository, loanRepository);
        }
    }
}
