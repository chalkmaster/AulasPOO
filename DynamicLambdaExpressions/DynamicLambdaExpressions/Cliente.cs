using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLambdaExpressions
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2:d}, {3}",
                Codigo, Nome, DataNascimento, Ativo ? "[ativo]" : "[inativo]");
        }

        public static IQueryable<Cliente> Buscar()
        {
            return new[] {
                new Cliente() { Codigo = 1, Nome = "Joao", DataNascimento = DateTime.Now.AddYears(-25), Ativo = true },
                new Cliente() { Codigo = 2, Nome = "Maria", DataNascimento = DateTime.Now.AddYears(-41), Ativo = true },
                new Cliente() { Codigo = 3, Nome = "Jose", DataNascimento = DateTime.Now.AddYears(-29), Ativo = true },
                new Cliente() { Codigo = 4, Nome = "Pedro", DataNascimento = DateTime.Now.AddYears(-36), Ativo = false },
                new Cliente() { Codigo = 5, Nome = "Ana", DataNascimento = DateTime.Now.AddYears(-20), Ativo = true },
                new Cliente() { Codigo = 6, Nome = "Joana", DataNascimento = DateTime.Now.AddYears(-41), Ativo = true },
                new Cliente() { Codigo = 7, Nome = "Joaquim", DataNascimento = DateTime.Now.AddYears(-58), Ativo = false },
                new Cliente() { Codigo = 8, Nome = "Paulo", DataNascimento = DateTime.Now.AddYears(-21), Ativo = true },
                new Cliente() { Codigo = 9, Nome = "Mariana", DataNascimento = DateTime.Now.AddYears(-37), Ativo = false },
                new Cliente() { Codigo = 10, Nome = "Juliana", DataNascimento = DateTime.Now.AddYears(-52), Ativo = true },
            }.AsQueryable();
        }
    }
}
