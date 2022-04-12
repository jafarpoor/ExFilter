﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiltersPro.Models
{
    public class ProductViewModelcs
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
