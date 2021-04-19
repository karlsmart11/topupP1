using GTLSystem.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.TUI
{
    static class Tui
    {
        static MemberController memberController = new MemberController();

        public static void Start()
        {
            Console.WriteLine("Georgia Tech Library Reservation system Inc.");
            bool status = Login();

            if (status)
            {
                MainMenu();
            }
        }

        private static bool Login()
        {
            Console.WriteLine("Please Enter SSN");
            var SSN = Console.ReadLine();

            Console.Clear();

            return memberController.CheckSSN(SSN);            
        }

        private static void MainMenu()
        {
            Console.WriteLine("Georgia Tech Library Reservation system Inc.");
            Console.WriteLine("Option 1: ");
            Console.ReadLine();
        }
    }
}
