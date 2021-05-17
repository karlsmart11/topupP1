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
            bool result = true;
            try
            {
                _titleRepository.Insert(title);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public bool checkISBN(string input)
        {
            bool res = true;

            try
            {
                _titleRepository.GetByISBN(input);
            }
            catch (Exception)
            {
                res = false;
            }            

            return res;
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
