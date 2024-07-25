﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EMPRESTIMO.LIVROS.Models
{
    [Table("CLIENTE")]
    public partial class Cliente
    {
        [Key]
        [Column("ID", TypeName = "NUMBER(38)")]
        public decimal Id { get; set; }
        [Required]
        [Column("CLICPF")]
        [StringLength(14)]
        [Unicode(false)]
        public string Clicpf { get; set; }
        [Required]
        [Column("CLINOME")]
        [StringLength(200)]
        [Unicode(false)]
        public string Clinome { get; set; }
        [Required]
        [Column("CLIENDERECO")]
        [StringLength(200)]
        [Unicode(false)]
        public string Cliendereco { get; set; }
        [Required]
        [Column("CLICIDADE")]
        [StringLength(100)]
        [Unicode(false)]
        public string Clicidade { get; set; }
        [Required]
        [Column("CLIBAIRRO")]
        [StringLength(100)]
        [Unicode(false)]
        public string Clibairro { get; set; }
        [Required]
        [Column("CLINUMERO")]
        [StringLength(50)]
        [Unicode(false)]
        public string Clinumero { get; set; }
        [Required]
        [Column("CLITELEFONECELULAR")]
        [StringLength(14)]
        [Unicode(false)]
        public string Clitelefonecelular { get; set; }
        [Required]
        [Column("CLITELEFONEFIXO")]
        [StringLength(13)]
        [Unicode(false)]
        public string Clitelefonefixo { get; set; }
    }
}