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
        IMemberRepository _memberRepository;

        public MemberController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public bool CheckSSN(string SSN)
        {
            bool status = true;

            if (_memberRepository.GetBySSN(SSN) == null)
            {
                status = false;
            }

            return status;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _memberRepository.GetAllMembers();
        }

        public Member GetBySSN(string ssn)
        {
            return _memberRepository.GetBySSN(ssn);
        }
    }
}
