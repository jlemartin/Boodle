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
    }
}
