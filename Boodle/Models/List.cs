using System;
namespace Boodle.Models
{
    public class List
    {
        public List()
        {
        }

        public int ListsID { get; set; }
        public string Name { get; set; }
        public int BoxNumber { get; set; }
        public int Shipped { get; set; }
        public int ContactID { get; set; }

    }
}
