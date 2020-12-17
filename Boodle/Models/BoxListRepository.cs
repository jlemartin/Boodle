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

        public IEnumerable<Boodler> GetAllBoodlers()
        {
            return _conn.Query<Boodler>("SELECT * FROM Users;");
        }

        public IEnumerable<BoxList> GetAllLists()
        {
            var yesText = "BOOM!!!";
            var notShipText = "Not yet";

            var boxLists = _conn.Query<BoxList>("SELECT * FROM Lists;");

            foreach (var list in boxLists)
            {
                list.BoxesFilled = GetFilledBoxCount(list.ListsID);
                list.BoxesAvailable = list.BoxNumber - list.BoxesFilled;

                list.BoxesShipped = GetShippedBoxCount(list.ListsID);
                if (list.BoxesShipped == list.BoxNumber)
                {
                    list.Shipped = 1;
                    UpdateListShipped(list.ListsID);
                }

                if (list.Shipped == 1)
                {
                    list.ShippedText = yesText;
                }
                else
                {
                    list.ShippedText = notShipText;
                }
            }

            return boxLists;
        }

        public BoxList GetBoxList(int id)
        {
            var yesText = "BOOM!!!";
            var notShipText = "Not yet";

            var aBoxList = _conn.QuerySingle<BoxList>("SELECT * FROM Lists WHERE ListsID = @id",
                new { id = id });

            aBoxList.BoxesFilled = GetFilledBoxCount(id);
            aBoxList.BoxesAvailable = aBoxList.BoxNumber - aBoxList.BoxesFilled;

            aBoxList.BoxesShipped = GetShippedBoxCount(id);
            if (aBoxList.BoxesShipped == aBoxList.BoxNumber)
            {
                aBoxList.Shipped = 1;
                UpdateListShipped(id);
            }


            var boodlersList = GetAllBoodlers();
            aBoxList.Boodlers = boodlersList;

            if (aBoxList.Shipped == 1)
            {
                aBoxList.ShippedText = yesText;
            }
            else
            {
                aBoxList.ShippedText = notShipText;
            }

            aBoxList.ContactName = GetListContactName(id);

            return aBoxList;
        }

        public int GetFilledBoxCount(int id)
        {
            var boxCount = _conn.QuerySingle<int>("SELECT COUNT(SignupsID) FROM Signups AS S " +
                "INNER JOIN Lists AS L ON S.ListsID = L.ListsID WHERE L.ListsID = @id",
                new { id = id });

            return boxCount;
        }

        public string GetListContactName(int id)
        {
            var contactName = _conn.QuerySingle<string>("SELECT U.FullName AS ContactName FROM Lists AS L " +
                "INNER JOIN Users AS U ON L.ContactID = U.UsersID WHERE L.ListsID = @id",
                new { id = id });

            return contactName;
        }

        public int GetShippedBoxCount(int id)
        {
            var shipCount = _conn.QuerySingle<int>("SELECT COUNT(SignupsID) FROM Signups AS S " +
                "INNER JOIN Lists AS L ON S.ListsID = L.ListsID WHERE NOT ShipDate = 'NULL' AND L.ListsID = @id",
                new { id = id });

            return shipCount;
        }

        public void UpdateListShipped(int id)
        {
            _conn.Execute("UPDATE Lists SET Shipped = 1 WHERE ListsID = @id;",
                new { id = id });
        }
    }
}
