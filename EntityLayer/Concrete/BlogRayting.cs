using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogRayting
    {
        public int BlogRaytingID { get; set; }

        public int BlogID { get; set; }

        public int BlogTotalscore { get; set; } //toplam puanu

        public int BlogRaytingCount { get; set; }
    }
}
