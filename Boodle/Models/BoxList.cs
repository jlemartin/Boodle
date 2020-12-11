using System;
using System.Collections.Generic;

namespace Boodle.Models
{
    public class BoxList
    {
        public BoxList()
        {
        }

        public int ListsID { get; set; }
        public string Name { get; set; }
        public int BoxNumber { get; set; }
        public int BoxesFilled { get; set; }
        public int BoxesAvailable { get; set; }
        public int Shipped { get; set; }
        public int ContactID { get; set; }
        public IEnumerable<Boodler> Boodlers { get; set; }
        public string SignupDate { get; set; }

    }
}
