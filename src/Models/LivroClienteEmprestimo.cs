﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EMPRESTIMO.LIVROS.Models
{
    [Table("LIVRO_CLIENTE_EMPRESTIMO")]
    public partial class LivroClienteEmprestimo
    {
        [Key]
        [Column("ID", TypeName = "NUMBER(38)")]
        public int Id { get; set; }
        [Column("LCELDCLIENTE", TypeName = "NUMBER(38)")]
        public int Lceldcliente { get; set; }
        [Column("LCELDLIVRO", TypeName = "NUMBER(38)")]
        public int Lceldlivro { get; set; }
        [Column("LCEDATAEMPRESTIMP", TypeName = "DATE")]
        public DateTime Lcedataemprestimp { get; set; }
        [Column("LCEDATAENTREGA", TypeName = "DATE")]
        public DateTime Lcedataentrega { get; set; }
        [Required]
        [Column("LCEENTREGUE")]
        [StringLength(1)]
        [Unicode(false)]
        public string Lceentregue { get; set; }
    }
}