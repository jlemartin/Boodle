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
            return _conn.Query<Signup>("SELECT S.SignupsID, L.Name AS BoxListName, U.FullName, Creation, ShipDate, ShipState " +
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

        public IEnumerable<Signup> GetSignupsByBoodler(int id)
        {
            return _conn.Query<Signup>("SELECT S.SignupsID, L.Name AS BoxListName, U.UsersID, U.FullName, Creation, ShipDate " +
                "FROM Lists AS L INNER JOIN Signups AS S ON L.ListsID = S.ListsID " +
                "INNER JOIN Users AS U ON S.UsersID = U.UsersID WHERE U.UsersID = @id", new { id = id });

        }

        public IEnumerable<Signup> GetSignupsByBoodlerNotShipped(int id)
        {
            return _conn.Query<Signup>("SELECT S.SignupsID, L.Name AS BoxListName, U.UsersID, U.FullName, Creation, ShipDate " +
                "FROM Lists AS L INNER JOIN Signups AS S ON L.ListsID = S.ListsID " +
                "INNER JOIN Users AS U ON S.UsersID = U.UsersID WHERE ShipDate IS NULL AND U.UsersID = @id", new { id = id });
        }

        public IEnumerable<Signup> GetSignupsByList(int id)
        {
            //return _conn.Query<Signup>("SELECT S.SignupsID, L.Name AS BoxListName, U.FullName, Creation, ShipDate " +
            //    "FROM Lists AS L INNER JOIN Signups AS S ON L.ListsID = S.ListsID " +
            //    "INNER JOIN Users AS U ON S.UsersID = U.UsersID WHERE L.ListsID = @id", new { id = id });

            return _conn.Query<Signup>("SELECT DISTINCT L.Name AS BoxListName, U.FullName, U.UsersID, COUNT(S.SignupsID) AS PerBoodlerInList " +
                "FROM Lists AS L INNER JOIN Signups AS S ON L.ListsID = S.ListsID " +
                "INNER JOIN Users AS U ON S.UsersID = U.UsersID WHERE L.ListsID = @id GROUP BY U.FullName, U.UsersID",
                new { id = id });
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

        public void UpdateMultipleShipments(int usersid, string dateStamp, string shipState)
        {
            var repo = _conn.Query<Signup>("SELECT S.SignupsID, L.ListsID, U.UsersID " +
                "FROM Lists AS L INNER JOIN Signups AS S ON L.ListsID = S.ListsID " +
                "INNER JOIN Users AS U ON S.UsersID = U.UsersID WHERE ShipDate IS NULL AND U.UsersID = @id", new { id = usersid });

            foreach (var signup in repo)
            {
                UpdateShipDate(signup.SignupsID, dateStamp, shipState);
            }
        }

        public void UpdateShipDate(int id, string dateStamp, string shipState)
        {
            _conn.Execute("UPDATE Signups SET ShipDate = @dateStamp, ShipState = @shipState WHERE SignupsID = @id;",
                new { id = id, dateStamp = dateStamp, shipState = shipState });
        }
    }
}
