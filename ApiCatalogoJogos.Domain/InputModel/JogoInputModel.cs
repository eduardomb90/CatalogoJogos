using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Domain.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 a 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da produtora deve conter entre 3 a 100 caracteres")]
        public string Produtora { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "O preço deve ser de no mínimo R$ 1,00 e no máximo R$ 1000,00")]
        public double Preco { get; set; }
    }
}
