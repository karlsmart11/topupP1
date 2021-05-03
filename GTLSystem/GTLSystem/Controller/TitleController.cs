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
            bool res = false;

            var title = titleRepository.GetByISBN(input);

            if (title != null)
            {
                res = true;
            }

            return res;
        }

        public Title GetByISBN(string ISBN)
        {
            return titleRepository.GetByISBN(ISBN);
        }
    }
}
