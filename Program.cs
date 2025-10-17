// See https://aka.ms/new-console-template for more information

using System;
using System.Formats.Asn1;
using System.Runtime.CompilerServices;
using Desafio_POO.Models;

Casa casa1 = new Casa();
Apartamento apartamento1 = new Apartamento();

Console.WriteLine("Menu:" +
                 "Você esta interressado(a) nos apartamentos? Se sim aperte 1  \n" +
                 "Ou Você esta interressada(a) nas casas? Se sim aperte 2");

string DecisãoCasaOuApartamento = Console.ReadLine();
if (DecisãoCasaOuApartamento == "1")
{
    bool continuar = true;
    while (continuar)
    {
        Console.WriteLine("Menu:\n" +
                         "Digite 1 se você deseja cadastrar um apartamento\n" +
                         "Digite 2 se você deseja ver os apartamentos disponiveis\n" +
                         "Difite 3 se voce deseja ver se o apartametno esta alugado\n" +
                         "Digite 4 se você deseja alugar um apartamento\n" +
                         "Digite 5 se você deseja cancelar um aluguel\n" +
                         "Digite 6 se você deseja calcular o aluguel por período\n" +
                         "Digite 7 para entrar em contato com o Proprietario\n" +
                         "Digite 8 para encerrar o programa.");

        string DecisãoMenuApartamento = Console.ReadLine();


        if (DecisãoMenuApartamento == "1")
        {
            apartamento1.cadastroDeApartamento();
        }
        else if (DecisãoMenuApartamento == "2")
        {
            apartamento1.QueroVerOsApartamentosNoCatalagoParaAlugar();
        }
        else if(DecisãoMenuApartamento == "3")
        {
            apartamento1.EstaAlugado();
        }
        else if (DecisãoMenuApartamento == "4")
        {
            apartamento1.QueroAlugarOsApartamentos();
        }
        else if (DecisãoMenuApartamento == "5")
        {
            apartamento1.QueroCancelarAlugelDosApartamentos();
        }
        else if (DecisãoMenuApartamento == "6")
        {
            apartamento1.CalcularAluguel(3000.00);
        }
        else if (DecisãoMenuApartamento == "7")
        {
            apartamento1.ContatoProprietario();
        }
        else if (DecisãoMenuApartamento == "8")
        {
            Console.WriteLine("Programa encerrado");
            continuar = false;
            break;
        }
        else
        {
            Console.WriteLine("O numero que você digitou não foi encontrado!!! Digite novamente,por favor.");
        }



    }



}
else if (DecisãoCasaOuApartamento == "2")
{
    bool continuar = true;
    while (continuar)
    {
        Console.WriteLine("Menu:" +
                            "Digite 1 se você deseja cadastrar uma casa\n" +
                            "Digite 2 se Você deseja ver as casas disponiveis\n" +
                            "Difite 3 se voce deseja ver se o apartametno esta alugado\n" +
                            "Digite 4 se você deseja alugar uma casas\n" +
                            "Digite 5 se você deseja cancelar um aluguel\n" +
                            "Digite 6 se você deseja calcular o aluguel por um período\n" +
                            "Digite 7 para entrar em contato com o Proprietario\n" +
                            "Digite 8 para encerrar o programa");

        string DecisãoMenuCasas = Console.ReadLine();

        if( DecisãoMenuCasas== "1")
        {
            casa1.CadastrDeCasa();
        }
        else if (DecisãoMenuCasas == "2")
        {
            casa1.QueroVerAsCasasNoCatalagoParaAlugar();
        }
        else if (DecisãoMenuCasas == "3")
        {
            casa1.EstaAlugado();
        }
        else if (DecisãoMenuCasas == "4")
        {
            casa1.QueroAlugarCasa();
        }
        else if (DecisãoMenuCasas == "5")
        {
            casa1.QueroCancelarAlugelDaCasa();
        }
        else if (DecisãoMenuCasas == "6")
        {
            casa1.CalcularAluguel(9000.00);
        }
        else if (DecisãoMenuCasas == "7")
        {
            casa1.ContatoProprietario();
        }
        else if (DecisãoMenuCasas == "8")
        {
            Console.WriteLine("Programa encerrado");
            continuar = false;
            break;
        }
        else
        {
            Console.WriteLine("O numero que você dgitou não foi encontrado!!! Digite novamente,por favor.");
        }

    }

}
else
{
    Console.WriteLine("Voce digitou algo que não é 1 para apartamento ou 2 para casa");
}

