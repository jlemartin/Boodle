using System;
using System.Collections.Generic;
namespace Boodle.Models
{
    public interface ISignupRepository
    {
        public IEnumerable<Signup> GetAllSignups();
        public Signup GetSignup(int id);
        public void MakeBoxListSignup(int user, int list, string dateStamp, int quantity);
        public IEnumerable<Signup> GetSignupsByList(int id);
        public IEnumerable<Signup> GetSignupsByBoodler(int id);
        public IEnumerable<Signup> GetSignupsByBoodlerGrouped(int id);
        public void UpdateShipDate(int id, string dateStamp, string shipState);
        public void UpdateMultipleShipments(int usersid, string dateStamp, string shipState);
        public IEnumerable<Signup> GetSignupsByBoodlerNotShipped(int id);

    }
}
