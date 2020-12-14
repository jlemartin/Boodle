using System;
using System.Collections.Generic;

namespace Boodle.Models
{
    public class Signup
    {

        public Signup()
        {
            States = StateArray.States;
        }

        public int SignupsID { get; set; }
        public int UsersID { get; set; }
        public int ListsID { get; set; }
        public string Creation { get; set; }
        public string ShipDate { get; set; }

        public string BoxListName { get; set; }
        public string FullName { get; set; }
        public int PerBoodlerInList { get; set; }
        public string ShipState { get; set; }
        //public IEnumerable<String> States { get; set; }

        public List<(string Abbreviation, string Name)> States { get; set; }


    }
}
