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
            if (_titleRepository.Insert(title))
            {
                return true;
            }
            else
            {
                return false;
            }
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
            Title res;

            try
            {
                res = _titleRepository.GetByISBN(ISBN);
            }
            catch (Exception)
            {
                res = null;                
            }

            return res;
        }
    }
}
