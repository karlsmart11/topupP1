using GTLSystem.IRepository;
using GTLSystem.Model;
using GTLSystem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Controller
{
    public class MemberController
    {
        private IMemberRepository memberRepository;

        public MemberController(IMemberRepository memberRepo)
        {
            memberRepository = memberRepo;
        }

        public bool CheckSSN(string SSN)
        {
            bool status = true;

            if (memberRepository.GetBySSN(SSN) == null)
            {
                status = false;
            }

            return status;
        }

        public bool GetAllMembers()
        {
            bool status = true;

            if (memberRepository.GetAllMembers() == null)
            {
                status = false;
            }
            return status;
        }
    }
}
