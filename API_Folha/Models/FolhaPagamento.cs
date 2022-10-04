using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class FolhaPagamento
    {
        
        [Key()]
        public int Id { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public string NomeFuncionario { get; set; }
        public string CpfFuncionario { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;

    }
}