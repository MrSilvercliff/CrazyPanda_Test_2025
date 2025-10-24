using System.Collections.Generic;

namespace RedPanda.Project
{
    public sealed class ShopModel
    {
        public IReadOnlyList<OfferModel> Offers { get; }
        public IReadOnlyDictionary<OfferType, IReadOnlyList<OfferModel>> OffersByOfferType { get; }

        public ShopModel()
        {
            var offerConfigs = new List<OfferConfig>()
            {
                new ("offer_chest_common", "Common chest", OfferType.Chest, OfferRarity.Common, 10),
                new ("offer_chest_rare", "Rare chest", OfferType.Chest, OfferRarity.Rare, 30, 2),
                new ("offer_chest_epic", "Epic chest", OfferType.Chest, OfferRarity.Epic, 100, 1),
                new ("offer_inapp_common_15", "Сommon inapp", OfferType.InApp, OfferRarity.Common, 15),
                new ("offer_inapp_common_2", "Сommon inapp", OfferType.InApp, OfferRarity.Common, 25, 2),
                new ("offer_inapp_rare", "Rare inapp", OfferType.InApp, OfferRarity.Rare, 65, 1),
                new ("offer_spec_common_25", "Common spec", OfferType.Special, OfferRarity.Common, 25),
                new ("offer_spec_rare", "Rare spec", OfferType.Special, OfferRarity.Rare, 100, 2),
                new ("offer_spec_common_35", "Common spec", OfferType.Special, OfferRarity.Common, 35),
                new ("offer_spec_epic", "Epic spec", OfferType.Special, OfferRarity.Epic, 40, 1)
            };

            var offerModels = new List<OfferModel>();
            var offerModelsByOfferType = new Dictionary<OfferType, IReadOnlyList<OfferModel>>();

            foreach (var offerData in offerConfigs)
            {
                var offerType = offerData.Type;
                var offerModel = new OfferModel(offerData);
                offerModels.Add(offerModel);

                List<OfferModel> list;

                if (!offerModelsByOfferType.ContainsKey(offerType))
                { 
                    list = new List<OfferModel>();
                    offerModelsByOfferType[offerType] = list;
                }

                list = (List<OfferModel>)offerModelsByOfferType[offerType];
                list.Add(offerModel);
            }

            foreach (var offerModelList in offerModelsByOfferType.Values)
            {
                var list = (List<OfferModel>)offerModelList;
                list.Sort((a, b) => b.Config.Rarity.CompareTo(a.Config.Rarity));
            }
                

            Offers = offerModels;
            OffersByOfferType = offerModelsByOfferType;
        }
    }
}
