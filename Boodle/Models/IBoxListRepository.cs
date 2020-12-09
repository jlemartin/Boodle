using System;
using System.Collections.Generic;

namespace Boodle.Models
{
    public interface IBoxListRepository
    {
        public IEnumerable<BoxList> GetAllLists();
        public BoxList GetBoxList(int id);
    }
}
