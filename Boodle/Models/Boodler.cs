using System;
using System.Collections.Generic;

namespace Boodle.Models
{
    public class Boodler
    {
        public Boodler()
        {
            States = StateArray.States;
        }

        public int UsersID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string CreationDate { get; set; }
        public string ListsID { get; set; }
        public string ListName { get; set; }
        public string ShipDate { get; set; }
        public List<(string Abbreviation, string Name)> States { get; set; }

    }
}
