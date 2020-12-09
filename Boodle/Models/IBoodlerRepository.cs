using System;
using System.Collections.Generic;

namespace Boodle.Models
{
    public interface IBoodlerRepository
    {
        public IEnumerable<Boodler> GetAllBoodlers();
        public Boodler GetBoodler(int id);
    }
}
