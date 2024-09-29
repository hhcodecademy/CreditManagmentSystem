using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.DTOS
{
    public class CategoryDto:BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
