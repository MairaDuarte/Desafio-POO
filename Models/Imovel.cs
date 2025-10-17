using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_POO.Models
{
    public abstract class Imovel : Proprietario
    {
        

        protected string Endereco { get; set; }
        protected string Numero { get; set; }
        protected bool Alugado { get; set; }
        protected Proprietario Proprietario { get; set; }
        protected string Id { get; set; }

        protected double Aluguel { get; set; }

        

        public abstract bool EstaAlugado();
        public virtual void ContatoProprietario()
        {
            Console.WriteLine($"O Nome do Proprietario é {Nome} e seu contato é {Telefone}");
           
        }
        public virtual double CalcularAluguel(double valor)
        {
            float tempo;
            bool ok = float.TryParse(Console.ReadLine(), out tempo);
            if (ok == true)
            {
                Aluguel = tempo * valor;
                Console.WriteLine($"O valor do repositorio é de {valor}");
               
            }
            else
            {
                Console.WriteLine("Não foi possivel calcular seu aluguel, o tempo colocado está incorreto");
            }
            
            return Aluguel;
        }

        
    }
}