using System.Collections.Generic;

namespace RedPanda.Project
{
    public sealed class ShopModel
    {
        public IReadOnlyList<OfferModel> Offers { get; }

        public ShopModel()
        {
            var offerConfigs = new List<OfferConfig>()
            {
                new ("Common chest", OfferType.Chest, OfferRarity.Common, 10),
                new ("Rare chest", OfferType.Chest, OfferRarity.Rare, 30, 2),
                new ("Epic chest", OfferType.Chest, OfferRarity.Epic, 100, 1),
                new ("Сommon inapp", OfferType.InApp, OfferRarity.Common, 15),
                new ("Сommon inapp", OfferType.InApp, OfferRarity.Common, 25, 2),
                new ("Rare inapp", OfferType.InApp, OfferRarity.Rare, 65, 1),
                new ("Common spec", OfferType.Special, OfferRarity.Common, 25),
                new ("Rare spec", OfferType.Special, OfferRarity.Rare, 100, 2),
                new ("Common spec", OfferType.Special, OfferRarity.Common, 35),
                new ("Epic spec", OfferType.Special, OfferRarity.Epic, 40, 1)
            };

            var offerModels = new List<OfferModel>();

            foreach (var offerData in offerConfigs)
            {
                offerModels.Add(new OfferModel(offerData));
            }

            Offers = offerModels;
        }
    }
}
