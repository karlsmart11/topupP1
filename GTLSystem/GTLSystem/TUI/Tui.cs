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
        static MaterialController materialController = new MaterialController();

        public static void Start()
        {
            MainMenu();
        }

        private static void RegisterLoan()
        {
            Console.Clear();
            Console.WriteLine("Georgia Tech Library Reservation system Inc.");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("            Registering new loan");
            Console.WriteLine("");
            Console.WriteLine("Please Enter SSN");
            var SSN = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Please enter up to 5 titles by ISBN or finish by typing 'done'");
            string input;
            var materials = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                input = Console.ReadLine();

                if (input.ToLower().Equals("done"))
                {
                    i = 5;
                }
                else if (!materialController.checkISBN(input))
                {
                    i--;
                    Console.WriteLine("Material not found");
                }
                else
                {
                    materials.Add(input);
                }
            }

            // Check if loan has been registered
            if (loanController.RegisterLoan(SSN))
            {
                Console.WriteLine("Loan registered successfully");
            } else
            {
                Console.WriteLine("Failed to register Loan");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
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
            Console.WriteLine("1: Register Loan");

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
                        RegisterLoan();
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
