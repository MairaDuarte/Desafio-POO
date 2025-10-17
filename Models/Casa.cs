using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Desafio_POO.Models
{
    public class Casa : Imovel
    {


        List<string> IdDaCasasParaAlugar = new List<string>();

        private List<Dictionary<string, string>> TodasAsCasasCadastradasParaAlugar = new List<Dictionary<string, string>>();
         private List<Dictionary<string, string>> TodasAsCasasAlugadas = new List<Dictionary<string, string>>();

        public void CadastrDeCasa()
        {
            

            Dictionary<string, string> cadastroDeCasa = new Dictionary<string, string>();
            Console.WriteLine("Digite o Id da casa");
            cadastroDeCasa["Id"] = Console.ReadLine();
            Console.WriteLine("Digite o Nome do proprietario");
            cadastroDeCasa["Proprietario"] = Console.ReadLine();
            Console.WriteLine("Digite o telefona para contato do proprietario");
            cadastroDeCasa["Contato de telefone"] = Console.ReadLine();
            TodasAsCasasCadastradasParaAlugar.Add(cadastroDeCasa);
        
            Console.WriteLine("\nCasa cadastrada com sucesso!");

        }
        public override double CalcularAluguel(double valor)
        {
            float tempo;
            Console.WriteLine("Digite os dias em que você alugou a casa");
            bool ok = float.TryParse(Console.ReadLine(), out tempo);
            if (ok == true)
            {
                Aluguel = tempo * valor;
                Console.WriteLine($"O valor do repositorio é de {Aluguel}");

            }
            else
            {
                Console.WriteLine("Não foi possivel calcular seu aluguel, o tempo colocado está incorreto");
            }

            return Aluguel;
        }

        public override void ContatoProprietario()  
        {
            bool nao = true;
            while (nao)
            {
            Console.WriteLine("Digite C para Cadastrada ou A para Alugada:");
            string resposta = Console.ReadLine();

            if (resposta == "C")
            {
                Console.WriteLine("Digite o id do apartamento:");
                string id = Console.ReadLine();
                bool encontrado = false;

                for (int i = 0; i < TodasAsCasasCadastradasParaAlugar.Count; i++)
                {
                    var apartamento = TodasAsCasasCadastradasParaAlugar[i];
                    if (id == apartamento["Id"])
                    {
                        Console.WriteLine($"O Nome do proprietario é n°{i} : {apartamento["Proprietario"]}");
                        Console.WriteLine($"E seu contato é : {apartamento["Contato"]}");
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("Não foi possível encontrar o id nos apartamentos cadastrados.");
                }

                nao = false;
            }
            else if (resposta == "A")
            {
                Console.WriteLine("Digite o id do apartamento:");
                string id = Console.ReadLine();
                 bool encontrado = false;

                for (int i = 0; i < TodasAsCasasAlugadas.Count; i++)
                {
                    var apartamento = TodasAsCasasAlugadas[i];
                    if (id == apartamento["Id"])
                    {
                        Console.WriteLine($"O Nome do proprietario é n°{i} : {apartamento["Proprietario"]}");
                        Console.WriteLine($"E seu contato é : {apartamento["Contato"]}");
                        encontrado = true;
                        break; // sai do for, achou o apartamento
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("Não foi possível encontrar o id das casas alugados.");
                }

                nao = false;
            }
            else
            {
                Console.WriteLine("Opção inválida, digite novamente!!");
            }
            }
        }
        
                
        public override bool EstaAlugado()
        {
            Console.WriteLine("Digite qual casa você deseja ver se está alugado");
            string idDigitado = Console.ReadLine();
            for (int i = 0; i < TodasAsCasasAlugadas.Count; i++)
            {
                var casa = TodasAsCasasAlugadas[i];
                if (idDigitado == casa["Id"])
                {
                    Console.WriteLine("A casa já está alugada");
                    return true;
                }

            }
            Console.WriteLine("A casa não está alugada");
            return false;

        }
            
        
        

        

        public virtual void QueroVerAsCasasNoCatalagoParaAlugar()
        {
            int n = 0;
            Console.WriteLine($"Os ID das casas disponiveis são ");
            foreach(var casa in TodasAsCasasCadastradasParaAlugar)
            {
               
                n++;
                Console.WriteLine($"O id da n°{n} : {casa["Id"]}");
            }

        }
        public  void QueroAlugarCasa()
        {
            Console.WriteLine($"Qual casa você deseja alugar?");
            string IdDaCasaDigitado = Console.ReadLine();
            for (int i = 0; i < TodasAsCasasCadastradasParaAlugar.Count; i++)
            {
                var casa = TodasAsCasasCadastradasParaAlugar[i]; // aí vai pegar o dicionário da casa atual
                if (IdDaCasaDigitado == casa["Id"])
                {
                    Console.WriteLine("O id digitado esta no catalogo de casa para alugar");
                    TodasAsCasasAlugadas.Add(TodasAsCasasCadastradasParaAlugar[i]);
                    Console.WriteLine("Foi alugado com sucesos");
                    TodasAsCasasCadastradasParaAlugar.RemoveAt(i);
                    break;

                }
                else
                {
                    Console.WriteLine("O id digitado não foi encontrado no catalogo para alugar");
                }
            
                   
            }
            
        }

        public  void  QueroCancelarAlugelDaCasa()
        {
            Console.WriteLine($"Qual casa você deseja cancelar o alguel?");
            string IdDaCasaDigitado = Console.ReadLine();
          
            for (int i = 0; i < TodasAsCasasAlugadas.Count; i++)
            {
                var casa = TodasAsCasasAlugadas[i];
                if (IdDaCasaDigitado == casa["Id"])
                {
                    Console.WriteLine("Confirmação que casa do id digitado esta alugada, é possivel cancelar o aluguel");
                    TodasAsCasasAlugadas.RemoveAt(i);
                    Console.WriteLine("Foi  cancelado o aluguel com sucesos");
                    TodasAsCasasCadastradasParaAlugar.Add(TodasAsCasasAlugadas[i]);
                }
                else
                {
                    Console.WriteLine("O id digitado não foi encontrado no catalogo para alugar");

                }
                
            }
        }
    }
}
