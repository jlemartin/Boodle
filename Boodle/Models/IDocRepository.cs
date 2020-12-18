using System;
using System.Collections.Generic;

namespace Boodle.Models
{
    public interface IDocRepository
    {
        public IEnumerable<Doc> GetAllDocuments();
    }
}
