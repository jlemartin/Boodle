using System;
namespace Boodle.Models
{
    public class Doc
    {
        public Doc()
        {
        }

        public int ID { get; set; }
        public string DocName { get; set; }
        public string DocLocation { get; set; }
        public int Ordering { get; set; }

    }
}
