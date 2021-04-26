using Dapper;
using GTLSystem.Model;
using GTLSystem.Repository;
using GTLSystem.TUI;
using System;
using System.Data.SqlClient;

namespace GTLSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tui.Start();

            TitleRepository titleRepository = new TitleRepository();

            titleRepository.Delete("1234")

            //Title title = new Title
            //{
            //    ISBN = "12345",
            //    Requested = false,
            //    TitleName = "God Titel",
            //    Description = "God beskrivelse",
            //    Available = true,
            //    Author = "God Forfatter",
            //    Subject = "Godt emne",
            //    Loanable = true
            //};

            //titleRepository.Insert(title);

            //MaterialRepository materialRep = new MaterialRepository();

            //Material material = new Material { Type = "Book", ISBN = "1234" };

            //materialRep.Insert(material);
        }
    }
}
