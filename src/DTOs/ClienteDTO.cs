using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EMPRESTIMO.LIVROS.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(11)]
        [Unicode(false)]
        [MinLength(11)]
        public string Clicpf { get; set; }
        [Required]
        [StringLength(200)]
        [Unicode(false)]
        public string Clinome { get; set; }
        [Required]
        [StringLength(200)]
        [Unicode(false)]
        public string Cliendereco { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string Clicidade { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string Clibairro { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Clinumero { get; set; }
        [Required]
        [StringLength(11)]
        [Unicode(false)]
        public string Clitelefonecelular { get; set; }
        [Required]
        [StringLength(10)]
        [Unicode(false)]
        public string Clitelefonefixo { get; set; }
    }
}