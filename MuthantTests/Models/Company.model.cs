﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MystiqueMapperTests.Models
{
    internal class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Address> Addresses { get; set; }
        public bool Active { get; set; }
    }
}
