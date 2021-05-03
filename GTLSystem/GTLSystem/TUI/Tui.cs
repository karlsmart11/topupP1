﻿using GTLSystem.Controller;
using GTLSystem.Model;
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
        static TitleController titleController = new TitleController();

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

            int currNoOfMaterials = loanController.GetCurrentNoOfMaterialsBySSN(SSN);


            Console.WriteLine();
            Console.WriteLine("Please enter up to 5 titles by ISBN or finish by typing 'done'");
            string input;
            var isbns = new List<string>();

            for (int i = 0; i < 5 - currNoOfMaterials; i++)
            {
                input = Console.ReadLine();

                if (input.ToLower().Equals("done"))
                {
                    i = 5 - currNoOfMaterials;
                }
                else if (!titleController.checkISBN(input))
                {
                    Console.WriteLine(input);
                    Console.WriteLine(titleController.checkISBN(input));
                    i--;
                    Console.WriteLine("ISBN not found");
                }
                else
                {
                    isbns.Add(input);
                }
            }
            var res = loanController.RegisterLoan(SSN, isbns);

            // Check if loan has been registered
            if (res == 1)
            {
                Console.WriteLine("Loan registered successfully");
            }
            if (res == 0)
            {
                Console.WriteLine("All items are reserved");
            }
            if (res == -1)
            {
                Console.WriteLine("Failed to register Loan");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();         
        }

        private static void GetNumberOfAvailable()
        {
            int noOfMaterials = materialController.GetNumberOfAvailableMaterials();

            Console.WriteLine("There are " + noOfMaterials + " materials available in total");
            Console.ReadKey();

        }

        private static void GetNumberOfUnavailable()
        {
            int noOfMaterials = materialController.GetNumberOfUnavailableMaterials();

            Console.WriteLine("There are " + noOfMaterials + " materials unavailable in total");
            Console.ReadKey();
        }

        private static void GetTitleByISBN()
        {
            Console.WriteLine("Please Enter SSN");
            var ISBN = Console.ReadLine();

            Title title = titleController.GetByISBN(ISBN);

            Console.WriteLine(title.Description);
            Console.ReadKey();

        }

        private static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Georgia Tech Library Reservation system Inc.");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("                Main menu");
            Console.WriteLine("");
            Console.WriteLine("1: Register Loan");
            Console.WriteLine("2: Number of available materials");
            Console.WriteLine("3: Number of unavailable materials");
            Console.WriteLine("4: Get information on a title");


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

                    case 2:
                        GetNumberOfAvailable();
                        break;

                    case 3:
                        GetNumberOfUnavailable();
                        break;
                    case 4:
                        GetTitleByISBN();
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
