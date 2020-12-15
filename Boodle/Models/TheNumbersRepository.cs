using System;
using System.Data;
using Dapper;

namespace Boodle.Models
{
    public class TheNumbersRepository : ITheNumbersRepository
    {
        private readonly IDbConnection _conn;

        public TheNumbersRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public TheNumbers GetTheNumbers()
        {
            _conn.Execute("UPDATE Stats SET BoxCount = (SELECT SUM(BoxNumber) FROM Lists) WHERE ID = 1;");
            _conn.Execute("UPDATE Stats SET BoxesSignedUp = (SELECT COUNT(SignupsID) FROM Signups) WHERE ID = 1;");
            _conn.Execute("UPDATE Stats SET BoxesShipped = (SELECT COUNT(SignupsID) FROM Signups WHERE NOT ShipDate = 'NULL') WHERE ID = 1;");

            var theNumbers = new TheNumbers();

            theNumbers.BoxCount = _conn.QuerySingle<int>("SELECT BoxCount FROM Stats;");
            theNumbers.BoxesSignedUp = _conn.QuerySingle<int>("SELECT BoxesSignedUp FROM Stats;");
            theNumbers.BoxesShipped = _conn.QuerySingle<int>("SELECT BoxesShipped FROM Stats;");

            return theNumbers;
        }
    }
}
