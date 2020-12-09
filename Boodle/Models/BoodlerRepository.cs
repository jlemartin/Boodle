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
    }
}
