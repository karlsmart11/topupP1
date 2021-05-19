using GTLSystem.Controller;
using GTLSystem.Repository;
using GTLSystem.TUI;

namespace GTLSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DbConnection();
            var materialRepository = new MaterialRepository(db);
            var materialLoanRepository = new MaterialLoanRepository(db);
            var titleRepository = new TitleRepository(db);
            var memberRepository = new MemberRepository(db);
            var loanRepository = new LoanRepository(db);

            ControllerContainer controllerContainer = new ControllerContainer(materialRepository, materialLoanRepository, titleRepository, memberRepository, loanRepository);

            Tui.Start(controllerContainer);

            //Tui.GenerateLoans(200);

            //MemberRepository memberRepository = new MemberRepository();

            //Member member = memberRepository.GetBySSN("101-81-1695");

            //Console.WriteLine(member.SSN);

            //var titlerepo = new TitleRepository();

            //Console.WriteLine(titlerepo.GetByISBN("test"));

            /*
            MaterialRepository materialRepository = new MaterialRepository();

            var test = materialRepository.GetAvailableByISBN("test", true);

            foreach (var durgen in test)
            {
                Console.WriteLine(durgen.ISBN);
                Console.WriteLine(durgen.MaterialId);
                Console.WriteLine(durgen.Type);
            }

            */
        }
    }
}
