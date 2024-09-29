using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid BranchId { get; set; }
        public Branch Branch { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
