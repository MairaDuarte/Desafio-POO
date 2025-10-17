using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Desafio_POO.Models
{
    public class Apartamento : Imovel 
    {
        
       private List<Dictionary<string, string>> TodosOsApartamentosCadastradasParaAlugar = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> TodosOsApartamentosAlugadas = new List<Dictionary<string, string>>();

        public void cadastroDeApartamento()
        {
            

            Dictionary<string, string> cadastroDeApartamento = new Dictionary<string, string>();
            Console.WriteLine("Digite o Id da casa");
            cadastroDeApartamento["Id"] = Console.ReadLine();
            Console.WriteLine("Digite o Nome do proprietario");
            cadastroDeApartamento["Proprietario"] = Console.ReadLine();
            Console.WriteLine("Digite o Telefone para contato do proprietario");
            cadastroDeApartamento["Contato"] = Console.ReadLine();
             Console.WriteLine("Digite o endereço do apartamento");
            cadastroDeApartamento["endereço"] = Console.ReadLine();
             Console.WriteLine("Digite o numero do apartamento");
            cadastroDeApartamento["numero"] = Console.ReadLine();
            TodosOsApartamentosCadastradasParaAlugar.Add(cadastroDeApartamento);

        
            Console.WriteLine("\nApartamento cadastrada com sucesso!");

        }

        public override double CalcularAluguel(double valor)
        {
            float tempo;
            Console.WriteLine("Digite os dias em que você alugou o apartamento");
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

        // public override void ContatoProprietario()
        // {
        //     bool nao= true;
        //     while (nao)
        //     {
        //         Console.WriteLine($"Você deseja entrar em contato com o proprietario de um apartamento cadastrada ou alugada? Digite Cadastrada digite C e se for Alugada digite A");
        //         string resposta = Console.ReadLine();
        //         if (resposta == "C")
        //         {
        //             Console.WriteLine($"Digite o id do apartamento para conseguir o contato do proprietario");
        //             string id = Console.ReadLine();
        //             for (int i = 0; i < TodosOsApartamentosCadastradasParaAlugar.Count; i++)
        //             {

        //                 var apartamento = TodosOsApartamentosCadastradasParaAlugar[i];
        //                 if (id == apartamento["Id"])
        //                 {
        //                     Console.WriteLine($"O Nome do proprietario da apartamento é n°{i} : {apartamento["Proprietario"]}");
        //                     Console.WriteLine($"e seu contato é  : {apartamento["contato"]}");
        //                 }
        //                 else
        //                 {
        //                     Console.WriteLine("Não foi possivel encontrar id nos apartamentos que não foram cadastrados ");
        //                 }

        //             }
        //             nao = false;


        //         }
        //         else if (resposta == "A")
        //         {
        //             Console.WriteLine($"Digite o id do apartamento para conseguir o contato do proprietario");
        //             string id = Console.ReadLine();
        //             for (int i = 0; i < TodosOsApartamentosAlugadas.Count; i++)
        //             {

        //                 var apartamento = TodosOsApartamentosAlugadas[i];
        //                 if (id == apartamento["Id"])
        //                 {
        //                     Console.WriteLine($"O Nome do proprietario da apartamento é n°{i} : {apartamento["Proprietario"]}");
        //                     Console.WriteLine($"e seu contato é  : {apartamento["contato"]}");
        //                 }
        //                 else
        //                 {
        //                     Console.WriteLine("Não foi possivel encontrar id nos apartamentos que não foram cadastrados ");
        //                 }

        //             }
        //              nao = false;
        //         }
        //         else
        //         {
        //             Console.WriteLine("Não foi  possivel encontra, digite novamente!!");
        //         }
        //     }
        //}
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

            for (int i = 0; i < TodosOsApartamentosCadastradasParaAlugar.Count; i++)
            {
                var apartamento = TodosOsApartamentosCadastradasParaAlugar[i];
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
                Console.WriteLine("Não foi possível encontrar o id nos apartamentos cadastrados.");
            }

            nao = false;
        }
        else if (resposta == "A")
        {
            Console.WriteLine("Digite o id do apartamento:");
            string id = Console.ReadLine();
            bool encontrado = false;

            for (int i = 0; i < TodosOsApartamentosAlugadas.Count; i++)
            {
                var apartamento = TodosOsApartamentosAlugadas[i];
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
                Console.WriteLine("Não foi possível encontrar o id nos apartamentos alugados.");
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
            Console.WriteLine("Digite qual apartamento você deseja ver se está alugado");
            string idDigitado = Console.ReadLine();
            for (int i = 0; i < TodosOsApartamentosAlugadas.Count; i++)
            {
                var casa = TodosOsApartamentosAlugadas[i];
                if (idDigitado == casa["Id"])
                {
                    Console.WriteLine("O apartamento já está alugada");
                    return true;
                }

            }
            Console.WriteLine("O apartamento não está alugada");
            return false;

        }
            
         public virtual void  QueroVerOsApartamentosNoCatalagoParaAlugar()
        {
            int n = 0;
            Console.WriteLine($"Os ID dos apartamento disponiveis são ");
            foreach(var casa in TodosOsApartamentosCadastradasParaAlugar)
            {
                
                n++;
                Console.WriteLine($"O id da n°{n} : {casa["Id"]}");
            }

        }
        public  void QueroAlugarOsApartamentos()
        {
            Console.WriteLine($"Qual apartamento você deseja alugar?");
            string IdDaCasaDigitado = Console.ReadLine();
            for (int i = 0; i < TodosOsApartamentosCadastradasParaAlugar.Count; i++)
            {
                var casa = TodosOsApartamentosCadastradasParaAlugar[i]; // aí vai pegar o dicionário da casa atual
                if (IdDaCasaDigitado == casa["Id"])
                {
                    Console.WriteLine("O id digitado esta no catalogo de apartamento para alugar");
                    TodosOsApartamentosAlugadas.Add(TodosOsApartamentosCadastradasParaAlugar[i]);
                    Console.WriteLine("Foi alugado com sucesos");
                    TodosOsApartamentosCadastradasParaAlugar.RemoveAt(i);
                    break;

                }
                else
                {
                    Console.WriteLine("O id digitado não foi encontrado no catalogo para alugar");
                }
            
                   
            }
            
        }

        public  void  QueroCancelarAlugelDosApartamentos()
        {
            Console.WriteLine($"Qual apartamento você deseja cancelar o alguel?");
            string IdDaCasaDigitado = Console.ReadLine();

            for (int i = 0; i < TodosOsApartamentosAlugadas.Count; i++)
            {
                var casa = TodosOsApartamentosAlugadas[i];
                if (IdDaCasaDigitado == casa["id"])
                {
                    Console.WriteLine("Confirmação que apartamento do id digitado esta alugada, é possivel cancelar o aluguel");
                    TodosOsApartamentosAlugadas.RemoveAt(i);
                    Console.WriteLine("Foi  cancelado o aluguel com sucesos");
                    TodosOsApartamentosCadastradasParaAlugar.Add(TodosOsApartamentosAlugadas[i]);
                }
                else
                {
                    Console.WriteLine("O id digitado não foi encontrado no catalogo para alugar");

                }
                
            }
        }
     }
}
