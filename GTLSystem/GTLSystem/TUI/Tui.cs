using GTLSystem.Controller;
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

            // Check if loan has been registered
            if (loanController.RegisterLoan(SSN))
            {
                Console.WriteLine("Loan registered successfully");
            } else
            {
                Console.WriteLine("SSN not found press any key to continue");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
            }

            Console.ReadKey();
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

            // Check if input is a number, else exception will print invalid input
            try
            {                
                int option = int.Parse(input);

                switch (option)
                {
                    case 1:
                        CreateLoan();
                        break;
                }

            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Invalid Menu Entry");    
                Console.WriteLine(e); //for debugging
                Console.ReadLine();
                MainMenu();
            }

            // Reprint main menu for continuity, use exit to end process
            MainMenu();
        }
    }
}
