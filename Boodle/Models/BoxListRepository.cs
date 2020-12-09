using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Boodle.Models
{
    public class BoxListRepository : IBoxListRepository
    {
        private readonly IDbConnection _conn;

        public BoxListRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<BoxList> GetAllLists()
        {
            return _conn.Query<BoxList>("SELECT * FROM Lists;");
        }

        public BoxList GetBoxList(int id)
        {
            return _conn.QuerySingle<BoxList>("SELECT * FROM Lists WHERE ListsID = @id",
                new { id = id });

        }
    }
}
