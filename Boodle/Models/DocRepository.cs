using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Boodle.Models
{
    public class DocRepository : IDocRepository
    {
        private readonly IDbConnection _conn;

        public DocRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Doc> GetAllDocuments()
        {
            return _conn.Query<Doc>("SELECT * FROM Docs;");
        }

    }
}
