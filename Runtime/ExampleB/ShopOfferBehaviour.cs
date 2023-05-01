using Mirzipan.Bibliotheca.Identifiers;
using Mirzipan.Clues;
using Mirzipan.Heist.Processors;
using Reflex.Attributes;
using Sandbox.Heist.ExampleB.Commands;
using Sandbox.Heist.ExampleB.Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace Sandbox.Heist.ExampleB
{
    public class ShopOfferBehaviour : MonoBehaviour
    {
        [Header("Logic")]
        [SerializeField]
        private CompositeId _offerId;

        [Header("Visuals")]
        [SerializeField]
        private Image _offerImage;
        [SerializeField]
        private Text _offerText;
        [SerializeField]
        private Image _priceImage;
        [SerializeField]
        private Text _priceText;

        [Header("Interaction")]
        [SerializeField]
        private Button _button;
        
        [Inject]
        private IDefinitions _definitions;
        [Inject]
        private IClientProcessor _processor;

        #region Lifecycle

        [Inject]
        private void Init()
        {
            var def = _definitions.Get<ShopOfferDefinition>(_offerId);
            if (def == null)
            {
                return;
            }
            
            SetItem(def.Item, _offerImage, _offerText);
            SetItem(def.Price[0], _priceImage, _priceText);

            _button.onClick.AddListener(OnPurchase);
        }

        #endregion Lifecycle

        #region Private

        private void SetItem(InventoryItem item, Image iconImage, Text nameText)
        {
            var def = _definitions.Get<InventoryItemDefinition>(item.Id);
            if (def == null)
            {
                return;
            }

            iconImage.sprite = def.Icon;
            iconImage.color = def.Color;
            nameText.text = def.FullName;
        }

        #endregion Private

        #region Bindings

        private void OnPurchase()
        {
            _processor.Process(new PurchaseItem.Action(_offerId, 1));
        }

        #endregion Bindings
    }
}