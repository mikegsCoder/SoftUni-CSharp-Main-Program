﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.ViewModels.ProductViewModels
{
    public class AllProductsViewModel
    {
        public string Username { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
