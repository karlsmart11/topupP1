using GTLSystem.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.TUI
{
    class Tui
    {
        MemberController memberController = new MemberController();
        public void Start()
        {
            Console.WriteLine("Georgia Tech Library Reservation system Inc.");
            bool status = Login();

            if (status)
            {
                MainMenu();
            }
        }

        private bool Login()
        {
            Console.WriteLine("Please Enter SSN");
            var SSN = Console.ReadLine();

            Console.Clear();

            return memberController.CheckSSN(SSN);            
        }

        private void MainMenu()
        {
            Console.WriteLine("Georgia Tech Library Reservation system Inc.");
            Console.WriteLine("Option 1: ");
            Console.ReadLine();
        }
    }
}
