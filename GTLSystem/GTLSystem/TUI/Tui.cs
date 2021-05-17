using GTLSystem.Controller;
using GTLSystem.Model;
using GTLSystem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.TUI
{
    public static class Tui
    {
        public static void GenerateLoans(int amount, ControllerContainer controllers)
        {
            var loancontroller = new LoanController();
            loancontroller.GenerateLoans(amount, controllers);
        }

        public static void Start(ControllerContainer controllers)
        {
            MainMenu(controllers);
        }

        private static void RegisterLoan(ControllerContainer controllers)
        {

            Console.Clear();
            Console.WriteLine("Georgia Tech Library Reservation system Inc.");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("            Registering new loan");
            Console.WriteLine("");
            Console.WriteLine("Please Enter SSN");
            var SSN = Console.ReadLine();

            int? currNoOfMaterials = controllers.loanController.GetCurrentNoOfMaterialsBySSN(SSN);


            Console.WriteLine();
            Console.WriteLine("Please enter up to " + (5-currNoOfMaterials) + " titles by ISBN or finish by typing 'done'");
            string input;
            var isbns = new List<string>();

            for (int? i = 0; i < 5 - currNoOfMaterials; i++)
            {
                Console.Write("item no " + (i+1) + ": ");
                input = (string) Console.ReadLine();

                if (input.ToLower().Equals("done"))
                {
                    i = 5 - currNoOfMaterials;
                }
                else if (!controllers.titleController.checkISBN(input))
                {
                    Console.WriteLine("ISBN not found");
                    Console.WriteLine();
                    i--;
                }
                else
                {
                    isbns.Add(input);
                }
            }
            var res = controllers.loanController.RegisterLoan(SSN, isbns, controllers);

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

            AnyKey();
        }

        private static void GetNumberOfAvailable(ControllerContainer controllers)
        {
            int? noOfMaterials = controllers.materialController.GetNumberOfAvailableMaterials();

            if (noOfMaterials >= 0)
            {
                Console.WriteLine("There are " + noOfMaterials + " materials available in total");
            }
            else
            {
                Console.WriteLine("Error when reading number of available materials");
            }

            AnyKey();
        }

        private static void GetNumberOfUnavailable(ControllerContainer controllers)
        {
            int? noOfMaterials = controllers.materialController.GetNumberOfUnavailableMaterials();

            if (noOfMaterials >= 0)
            {
                Console.WriteLine("There are " + noOfMaterials + " materials unavailable in total");
            }
            else
            {
                Console.WriteLine("Error when reading number of unavailable materials");
            }

            AnyKey();
        }

        private static void GetTitleByISBN(ControllerContainer controllers)
        {
            Console.Write("Please Enter ISBN: ");
            string ISBN = Console.ReadLine();

            Title title = controllers.titleController.GetByISBN(ISBN);

            if (title != null)
            {
                Console.WriteLine(title.Description);
            }
            else
            {
                Console.WriteLine("Title not found");
            }

            AnyKey();
        }

        private static void MainMenu(ControllerContainer controllers)
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
            Console.WriteLine();

            Console.Write("Select entry: ");

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
                        RegisterLoan(controllers);
                        break;

                    case 2:
                        GetNumberOfAvailable(controllers);
                        break;

                    case 3:
                        GetNumberOfUnavailable(controllers);
                        break;
                    case 4:
                        GetTitleByISBN(controllers);
                        break;
                }

            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Invalid Menu Entry");    
                Console.WriteLine(e); //for debugging
                AnyKey();
                MainMenu(controllers);
            }

            // Reprint main menu for continuity, use exit to end process
            MainMenu(controllers);
        }

        private static void AnyKey()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
