﻿using GTLSystem.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.TUI
{
    static class Tui
    {
        static MemberController memberController = new MemberController();
        static LoanController loanController = new LoanController();

        public static void Start()
        {
            MainMenu();
        }

        private static void CreateLoan()
        {
            Console.WriteLine("Please Enter SSN");
            var SSN = Console.ReadLine();

            loanController.RegisterLoan(SSN);

            Console.Clear();         
        }

        private static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Georgia Tech Library Reservation system Inc.");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("                Main menu");
            Console.WriteLine("");
            Console.WriteLine("1: Create Loan");

            string input = Console.ReadLine().ToLower();
            if(input.Equals("exit"))
            {
                return;
            }

            try
            {                
                int option = int.Parse(input);

                switch (option)
                {
                    case 1:
                        CreateLoan();
                        return;
                }

            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Invalid Menu Entry");
                Console.WriteLine(e);
                Console.ReadLine();
                MainMenu();
            }            
        }
    }
}
