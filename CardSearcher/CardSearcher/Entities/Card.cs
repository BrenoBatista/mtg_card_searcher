using System;
using System.Collections.Generic;

namespace CardSearcher.Entities
{
    public class MagicCardResponse
    {
        public List<MagicCard> Cards { get; set; }
    }

    public class MagicCardResponseSingle
    {
        public MagicCard Single { get; set; }
    }

    public class MagicCard
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Rarity { get; set; }
        public string Set { get; set; }
        public string SetName { get; set; }
        public string ManaCost { get; set; }
        public string ImageUrl { get; set; }
        public string Text { get; set; }
        public string Flavor { get; set; }
    }
}
