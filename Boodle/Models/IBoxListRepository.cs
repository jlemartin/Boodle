using System;
using System.Collections.Generic;

namespace Boodle.Models
{
    public interface IBoxListRepository
    {
        public IEnumerable<BoxList> GetAllLists();
        public BoxList GetBoxList(int id);
        public IEnumerable<Boodler> GetAllBoodlers();
        public int GetFilledBoxCount(int id);
        public int GetShippedBoxCount(int id);
        public void UpdateListShipped(int id);
        public string GetListContactName(int id);

    }
}
