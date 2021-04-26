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
    }
}
