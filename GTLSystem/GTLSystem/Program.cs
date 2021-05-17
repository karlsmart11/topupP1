using Dapper;
using GTLSystem.Controller;
using GTLSystem.IRepository;
using GTLSystem.Model;
using GTLSystem.Repository;
using GTLSystem.TUI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.SqlClient;

namespace GTLSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            ControllerContainer controllerContainer = new ControllerContainer(new DbConnection());

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
