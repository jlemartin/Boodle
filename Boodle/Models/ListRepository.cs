using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Boodle.Models
{
    public class ListRepository : IListRepository
    {
        private readonly IDbConnection _conn;

        public ListRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<List> GetAllLists()
        {
            return _conn.Query<List>("SELECT * FROM Lists;");
        }
    }
}
