﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models
{
    public class Merchant:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TerminalNo { get; set; }
    }
}
