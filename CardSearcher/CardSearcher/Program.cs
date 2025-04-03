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
            CardServices cardServices = new CardServices();

            /*
            Console.Write("Digite o nome da carta: ");
            string cardName = Console.ReadLine();
            */



            //MagicCardResponse cardResponse = await cardServices.GetCardByNameAsync(cardName);
            string cardId = "a24bd0d0-0bca-5970-b12b-6587f7745561";
            MagicCardResponseSingle cardResponse = await cardServices.GetCardByIdAsync(cardId);
            MagicCard card = cardResponse.Card;
            Console.WriteLine(card.Name);
            Console.WriteLine($"Nome: {card.Name}");
            Console.WriteLine($"Tipo: {card.Type}");
            Console.WriteLine($"Custo de Mana: {card.ManaCost}");
            Console.WriteLine($"Texto: {card.Text}");
            Console.WriteLine($"Imagem: {card.ImageUrl}");
            //Console.WriteLine(cardResponse.Cards[0].Name);


            /*
            if (cardResponse?.Cards != null && cardResponse.Cards.Count > 0)
            {
                MagicCard card = cardResponse.Cards[0];
                Console.WriteLine($"Nome: {card.Name}");
                Console.WriteLine($"Tipo: {card.Type}");
                Console.WriteLine($"Custo de Mana: {card.ManaCost}");
                Console.WriteLine($"Texto: {card.Text}");
                Console.WriteLine($"Imagem: {card.ImageUrl}");
            }
            else
            {
                Console.WriteLine("Carta não encontrada.");
            }
            */
        }
    }
}
