namespace RedPanda.Project
{
    public class OfferConfig
    {
        public OfferType Type { get; }
        public string Title { get; }
        public OfferRarity Rarity { get; }
        public int Cost { get; }
        public int BuyLimit { get; }
        public string IconId => $"sprite_{Type.ToString().ToLower()}_{Rarity.ToString().ToLower()}";

        public OfferConfig(string title, OfferType type, OfferRarity rarity, int cost, int buyLimit = int.MaxValue)
        {
            Title = title;
            Type = type;
            Rarity = rarity;
            Cost = cost;
            BuyLimit = buyLimit;
        }
    }

    public enum OfferRarity
    {
        Common = 1,
        Rare = 2,
        Epic = 3,
    }

    public enum OfferType
    {
        Chest,
        Special,
        InApp
    }
}