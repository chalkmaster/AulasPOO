using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var itens = Carro.Buscar();
                var itens = Cliente.Buscar();

                Console.Write("Informe o filtro: ");
                string filtro = Console.ReadLine();

                var resultado = itens.Filtrar(filtro);
                foreach (var item in resultado)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
