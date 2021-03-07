using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject
{
    class Toc
    {
        public string TocName { get; set; }
        public List<string> TicketName { get; set; }
    }

    class Station
    {
        public string Name
        {
            get; set;
        }

        public List<string> Shops
        {
            get; set;
        }

    }

}
