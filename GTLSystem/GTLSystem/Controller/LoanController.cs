using GTLSystem.IRepository;
using GTLSystem.Model;
using GTLSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTLSystem.Controller
{
    public class LoanController        
    {
        private ILoanRepository _loanRepository;

        public LoanController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        // Generate random loans as test data
        public bool GenerateLoans(int amount, ControllerContainer controllers)
        {
            bool result = true;
            List<Member> members = new List<Member>();
            List<Material> allMaterials = new List<Material>();
            Member member;
            Random random = new Random();

            foreach (var item in controllers.memberController.GetAllMembers())
            {
                members.Add(item);
            }
            foreach (var item in controllers.materialController.GetAvailableMaterials())
            {
                allMaterials.Add(item);
            }

            if (allMaterials.Count == 0) result = false;
            
            for (int i = 0; i < amount && result ; i++)
            {
                member = members[random.Next(0, members.Count)];
                var materials = new List<Material>();
                int max;

                if (allMaterials.Count() > 5)
                {
                    max = 5;
                }
                else
                {
                    max = allMaterials.Count();
                }

                int count = random.Next(1, max);

                Console.WriteLine("Creating Loan with " + count + " materials");

                for (int j = 0; j < count ; j++)
                {
                    var index = random.Next(0, allMaterials.Count());
                    materials.Add(allMaterials[index]);
                    controllers.materialController.ReserveMaterial(allMaterials[index]);
                    allMaterials.RemoveAt(index);

                    Console.WriteLine("Material " + (j+1) + " added to loan");
                }

                if (member != null && result)
                {
                    Loan loan = new Loan()
                    {
                        StartDate = DateTime.Now,
                        MemberSSN = member.SSN
                    };

                    try
                    {
                        _loanRepository.Insert(loan);
                        Console.WriteLine("Loan registered");
                    }
                    catch (Exception)
                    {
                        result = false;
                    }

                    loan = _loanRepository.GetNewestLoan();

                    Console.WriteLine("Registering " + materials.Count() + " MaterialLoans");

                    foreach (var material in materials)
                    {
                        try
                        {
                            controllers.materialLoanController.CreateMaterialLoan(loan, material);
                        }
                        catch (Exception)
                        {
                            result = false;
                        }
                    }

                    Console.WriteLine("------------------------");
                }
                if (members.Count == 0 || allMaterials.Count == 0) result = false;                
            }

            Console.WriteLine("remaining free materials: " + allMaterials.Count());

            return result;
        }

        public IEnumerable<Material> test(ControllerContainer controllers)
        {
            return controllers.materialController.GetAvailableByISBN("isbn", true);
        }

        public int RegisterLoan(String ssn, List<string> isbns, ControllerContainer controllers)
        {
            int result = 1;
            Member member = controllers.memberController.GetBySSN(ssn);
            List<Material> materials = new List<Material>();
            List<string> unavailable = new List<string>();

            foreach (var isbn in isbns)
            {
                var material = controllers.materialController.GetAvailableByISBN(isbn, true);

                if (material.Count() > 0)
                {
                    materials.Add(material.First());
                    controllers.materialController.ReserveMaterial(material.First());
                }
                else
                {
                    unavailable.Add(isbn);
                }                
            }

            if (unavailable.Count == isbns.Count)
            {
                result = 0;
            }

            if (member != null && result != 0)
            {
                Loan loan = new Loan()
                {
                    StartDate = DateTime.Now,
                    MemberSSN = member.SSN
                };

                if (_loanRepository.Insert(loan))
                {
                    loan = _loanRepository.GetNewestLoan();

                    foreach (var material in materials)
                    {
                        if (!controllers.materialLoanController.CreateMaterialLoan(loan, material)) result = -1;
                    }
                }
                else
                {
                    result = -1;
                }
            }

            return result;
        }

        public int? GetCurrentNoOfMaterialsBySSN(string SSN)
        {
            return _loanRepository.MaterialCountBySSN(SSN);
        }
    }
}
