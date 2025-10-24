using RedPanda.Project.Scripts.EventBus;
using RedPanda.Project.Scripts.Model;
using UnityEngine;

namespace RedPanda.Project.Scripts.UI.Events
{
    public class OfferBuySuccessEvent : IEvent
    { 
        public OfferModel OfferModel { get; }

        public OfferBuySuccessEvent(OfferModel offerModel)
        { 
            OfferModel = offerModel;
        }
    }
}
