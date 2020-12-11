using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Boodle.Models
{
    public class SignupRepository : ISignupRepository
    {
        private readonly IDbConnection _conn;

        public SignupRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Signup> GetAllSignups()
        {
            return _conn.Query<Signup>("SELECT S.SignupsID, L.Name AS BoxListName, U.FullName, Creation, ShipDate " +
                "FROM Lists AS L INNER JOIN Signups AS S ON L.ListsID = S.ListsID " +
                "INNER JOIN Users AS U ON S.UsersID = U.UsersID;");
        }

        public Signup GetSignup(int id)
        {
            return _conn.QuerySingle<Signup>("SELECT S.SignupsID, L.Name AS BoxListName, U.FullName " +
                "FROM Lists AS L INNER JOIN Signups AS S ON L.ListsID = S.ListsID " +
                "INNER JOIN Users AS U ON S.UsersID = U.UsersID WHERE S.SignupsID = @id",
                new { id = id });
        }

        public IEnumerable<Signup> GetSignupsByList(int id)
        {
            return _conn.Query<Signup>("SELECT S.SignupsID, L.Name AS BoxListName, U.FullName, Creation, ShipDate " +
                "FROM Lists AS L INNER JOIN Signups AS S ON L.ListsID = S.ListsID " +
                "INNER JOIN Users AS U ON S.UsersID = U.UsersID WHERE L.ListsID = @id", new { id = id });
        }

        public void MakeBoxListSignup(int UsersID, int ListsID, string SignupDate, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                _conn.Execute("INSERT INTO Signups (UsersID, ListsID, Creation) " +
                    "VALUES (@UsersID, @ListsID, @dateString);",
                    new { UsersID = UsersID, ListsID = ListsID, dateString = SignupDate });
            }
        }
    }
}
