using System;
using System.Threading.Tasks;
using CardSearcher.Entities;
using CardSearcher.Entities.Services;

namespace CardSearcher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();

            int larguraConsole = Console.WindowWidth;
            string[] mensagens =
            {
            "======================================================================",
            "             \U0001f9d9‍  Bem-vindo ao Magic Card Finder! 🃏 ",
            "======================================================================",
            "Este programa ajuda você a encontrar cartas de Magic: The Gathering.",
            "Para continuar tecle enter."
            };

            foreach (string mensagem in mensagens)
            {
                int espacoEsquerda = (larguraConsole - mensagem.Length) / 2;
                Console.WriteLine(mensagem.PadLeft(mensagem.Length + espacoEsquerda));
            }
            Console.ReadKey();
            Console.Clear();
            Console.Write("\n\nEscolha uma opção e tecle enter.\n1 - Buscar pelo universe id.\n2 - Buscar pelo nome da carta.\n");
            char opcao = Console.ReadKey().KeyChar;
            Console.Clear();

            CardServices cardServices = new CardServices();

            switch (opcao)
            {
                case '1':
                    Console.Write("Digite o código da carta: ");
                    string cardId = Console.ReadLine();

                    MagicCardResponseSingle magicCardResponse = await cardServices.GetCardByIdAsync(cardId);

                    if (magicCardResponse == null)
                    {
                        Console.WriteLine("Carta não encontrada.");
                    }
                    else
                    {
                        MagicCard cardsin = magicCardResponse.Card;
                        Console.WriteLine($"Nome: {cardsin.Name}");
                        Console.WriteLine($"Tipo: {cardsin.Type}");
                        Console.WriteLine($"Custo de Mana: {cardsin.ManaCost}");
                        Console.WriteLine($"Texto: {cardsin.Text}");
                        Console.WriteLine($"Imagem: {cardsin.ImageUrl}");
                    }



                        break;

                case '2':
                    Console.Write("Digite o nome da carta: ");
                    string cardName = Console.ReadLine();

                    MagicCardResponse cardResponse = await cardServices.GetCardByNameAsync(cardName);
                    Console.Clear();
                    Console.WriteLine($"Número de resultados: {cardResponse.Cards.Count}\n\n");

                    if ((cardResponse?.Cards) == null || cardResponse.Cards.Count <= 0)
                    {
                        Console.WriteLine("Carta não encontrada.");
                    }
                    else
                    {

                        
                        foreach (MagicCard card in cardResponse.Cards)
                        {
                            Console.WriteLine($"Nome: {card.Name}");
                            Console.WriteLine($"Tipo: {card.Type}");
                            Console.WriteLine($"Custo de Mana: {card.ManaCost}");
                            Console.WriteLine($"Texto: {card.Text}");
                            Console.WriteLine($"Set: {card.Set}");
                            Console.WriteLine($"Flavor: {card.Flavor}");
                            Console.WriteLine($"Imagem: {card.ImageUrl}\n\n");
                        }
                    }
                    break;
            }

        }

    }

}
