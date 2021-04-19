using GTLSystem.Model;
using GTLSystem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Controller
{
    class MemberController
    {
        private MemberRepository memberRepository = new MemberRepository();

        public bool CheckSSN(string SSN)
        {
            bool status = true;

            if (memberRepository.GetBySSN(SSN) == null)
            {
                status = false;
            }

            return status;
        }
    }
}
