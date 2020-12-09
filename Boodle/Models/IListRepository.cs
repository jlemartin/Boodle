using System;
using System.Collections.Generic;

namespace Boodle.Models
{
    public interface IListRepository
    {
        public IEnumerable<List> GetAllLists();
    }
}
