using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalPessoas.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double CPF { get; set; }
        public string UF { get; set; }

        [DataType(DataType.Date)] //para n exigir hora
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime DataNascimento { get; set; }

        public Pessoa() { }

        public Pessoa(int id, string nome, long cPF, string uF, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            UF = uF;
            DataNascimento = dataNascimento;
        }
    }
}
