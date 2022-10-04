using System;
using System.ComponentModel.DataAnnotations;
using API_Folha.Validations;

namespace API.Models
{
    public class Funcionario
    {
        [Key()]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório!")] /*
        [StringLength(
            11,
            MinimumLength = 11,
            ErrorMessage = "O campo CPF deve conter 11 caracteres!"
        )] */
        //[CpfEmUso]
        public string Cpf { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;

    }
}