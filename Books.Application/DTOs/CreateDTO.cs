﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.DTOs
{
    public class CreateDTO
    {
        public string? name { get; set; }

        public string? category { get; set; }

        public int price { get; set; }

        public string? description { get; set; }
    }
}