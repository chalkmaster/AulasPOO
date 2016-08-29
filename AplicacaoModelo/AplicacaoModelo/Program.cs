using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacaoModelo.Core.DomainObjects;

namespace AplicacaoModelo
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            user.Name = Console.ReadLine();
            user.Email = "maycon@gmail.com";
            user.Password = "soufoda";

            Console.WriteLine("Nome: " + user.Name);
            Console.WriteLine("Email: " + user.Email);
            Console.WriteLine("Senha: ****");

            Console.ReadLine();
        }
    }
}
