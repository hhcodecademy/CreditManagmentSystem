using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models
{
    public class Branch:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Guid MerchantId { get; set; }
        public Merchant Merchant { get; set; }
    }
}
