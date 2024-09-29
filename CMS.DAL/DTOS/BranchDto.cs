using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.DTOS
{
    public class BranchDto : BaseDto
    {
        [Display(Name ="Ad")]
   
        public string Name { get; set; }
        [StringLength(maximumLength: 5)]
        public string Description { get; set; }
        public string Address { get; set; }
        public Guid MerchantId { get; set; }
    }
}
