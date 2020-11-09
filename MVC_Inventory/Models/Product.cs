﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInformation.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "int(10)")]
        public int Quantity { get; set; }

        [Column(TypeName = "char(1)")]
        public int Discontinued { get; set; }
    }
}