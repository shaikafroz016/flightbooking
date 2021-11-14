﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Case_study.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public string Airplane { get; set; }
        public DateTime departure { get; set; }
        public string type { get; set; }
        public int price { get; set; }
    }
}