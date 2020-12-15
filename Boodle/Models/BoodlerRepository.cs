using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Boodle.Models
{
    public class BoodlerRepository : IBoodlerRepository
    {
        private readonly IDbConnection _conn;

        public BoodlerRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Boodler> GetAllBoodlers()
        {
            return _conn.Query<Boodler>("SELECT * FROM Users;");
        }

        public Boodler GetBoodler(int id)
        {
            return _conn.QuerySingle<Boodler>("SELECT * FROM Users WHERE UsersID = @id",
                new { id = id });

        }

        public IEnumerable<Boodler> GetBoxListContacts()
        {
            return _conn.Query<Boodler>("SELECT L.ContactID AS UsersID, U.FullName, L.ListsID, L.Name AS ListName " +
                "FROM Lists AS L INNER JOIN Users AS U ON L.ContactID = U.UsersID;");
        }
    }
}
