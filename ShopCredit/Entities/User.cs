﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public required string Name { get; set; }

        public required string Password { get; set; }
    }
}
