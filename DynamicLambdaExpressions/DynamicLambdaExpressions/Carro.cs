using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLambdaExpressions
{
    public class Carro
    {
        public int Codigo { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}",
                Codigo, Placa, Ano, Modelo);
        }

        public static IEnumerable<Carro> Buscar()
        {
            return new[] {
                new Carro() { Codigo = 1, Placa = "AAA1111", Ano = 2012, Modelo = "Uno" },
                new Carro() { Codigo = 2, Placa = "AAA2222", Ano = 2010, Modelo = "Gol" },
                new Carro() { Codigo = 3, Placa = "BBB3333", Ano = 2011, Modelo = "Palio" },
                new Carro() { Codigo = 4, Placa = "CCC1111", Ano = 2012, Modelo = "Fiesta" },
                new Carro() { Codigo = 5, Placa = "DDD1111", Ano = 2009, Modelo = "Ferrari" },
            }; 
        }
    }
}
