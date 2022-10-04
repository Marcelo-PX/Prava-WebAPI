using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class FolhaFuncionario
    {
        [Key()]
        public int Id { get; set; }

        [ForeignKey("Funcionario")]
        public int FuncionarioId { get; set; }

        [ForeignKey("FolhaPagamento")]
        public int FolhaPagamentoId { get; set; }  
        public Funcionario Funcionario { get; set; }
        public FolhaPagamento FolhaPagamento { get; set; }       
        public double ValorHora { get; set; }
        public double SalarioLiquido { get; set; }
        public int HorasTrabalhadas { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        
    }
}