﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiLayer.Concreate
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
        public string adminRole { get; set; }
    }
}
