using GTLSystem.Model;
using GTLSystem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Controller
{
    class TitleController
    {
        TitleRepository titleRepository = new TitleRepository();

        public bool RegisterTitle(Title title)
        {
            bool result = true;
            try
            {
                titleRepository.Insert(title);
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
                titleRepository.GetByISBN(input);
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
                res = titleRepository.GetByISBN(ISBN);
            }
            catch (Exception)
            {
                res = null;                
            }

            return res;
        }
    }
}
