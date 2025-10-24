using RedPanda.Project.Scripts.Game;
using RedPanda.Project.Scripts.Interfaces;
using RedPanda.Project.Scripts.UI.Events;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.Scripts.UI
{
    public class CurrencyWidget : MonoBehaviour, IInitializable
    {
        [SerializeField] private TMP_Text _currencyValueText;

        private void OnEnable()
        {
            GameController.EventBus.Subscribe<CurrencyChangeEvent>(OnCurrencyChangeEvent);
        }

        private void OnDisable()
        {
            GameController.EventBus.UnSubscribe<CurrencyChangeEvent>(OnCurrencyChangeEvent);
        }

        public void Init()
        {
            Refresh();
        }

        private void Refresh()
        {
            _currencyValueText.text = GameController.User.Currency.ToString();
        }

        private async Task OnCurrencyChangeEvent(CurrencyChangeEvent evnt)
        {
            Refresh();
        }
    }
}
