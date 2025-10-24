using RedPanda.Project.Scripts.Interfaces;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.Scripts.UI
{
    public class CurrencyWidget : MonoBehaviour, IInitializable
    {
        [SerializeField] private TMP_Text _currencyValueText;

        public void Init()
        {
        }

        private void Refresh()
        {
            _currencyValueText.text = Game.User.Currency.ToString();
        }
    }
}
