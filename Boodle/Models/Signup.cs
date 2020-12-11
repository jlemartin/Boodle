using System;
namespace Boodle.Models
{
    public class Signup
    {
        public Signup()
        {
        }

        public int SignupsID { get; set; }
        public int UsersID { get; set; }
        public int ListsID { get; set; }
        public string Creation { get; set; }
        public string ShipDate { get; set; }

        public string BoxListName { get; set; }
        public string FullName { get; set; }

    }
}
