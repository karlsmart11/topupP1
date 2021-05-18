using GTLSystem.IRepository;
using GTLSystem.Model;
using GTLSystem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Controller
{
    public class TitleController
    {
        ITitleRepository _titleRepository;

        public TitleController(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public bool RegisterTitle(Title title)
        {
            return _titleRepository.Insert(title);
        }

        public bool checkISBN(string input)
        {
            if (_titleRepository.GetByISBN(input) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Title GetByISBN(string ISBN)
        {
            return _titleRepository.GetByISBN(ISBN);
        }
    }
}
