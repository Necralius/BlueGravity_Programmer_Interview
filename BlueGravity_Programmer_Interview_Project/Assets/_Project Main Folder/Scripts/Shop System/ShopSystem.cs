using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NekraliusDevelopmentStudio
{
    public class ShopSystem : MonoBehaviour
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //ShopSystem - (0.2)
        //State: Funcitonal
        //This code represents Shop System class that controll an the shop behavior and UI systems.

        #region - Singleton Pattern -
        //This structures represents an simple singleton pattern implementation
        public static ShopSystem Instace;
        private void Awake() => Instace = this;
        #endregion

        #region - Shop Data Holder -
        public ModelShop shopModel;
        private List<ShopItem> shopItemList = new List<ShopItem>();
        [SerializeField] private List<Model_Slot> SellableItems;
        #endregion

        #region - Shop UI Elements
        public Transform shopListContent;
        public GameObject shopListViewPrefab;
        public TextMeshProUGUI shopName;
        public TextMeshProUGUI sellTotalValue;
        #endregion

        //============================Methods============================//

        #region - BuiltIn Methods -
        private void Start() //-> Called in the game start
        {
            if (shopModel == null) return;
            shopItemList.AddRange(shopModel.itemList);
            UpdateShopUI();
        }
        #endregion

        #region - UI Update System -
        public void UpdateShopUI() //This method updates the complete shop UI, mainly the buyables item list.
        {
            shopName.text = shopModel.shopName;

            foreach (Transform trans in shopListContent) Destroy(trans.gameObject);
            foreach (ShopItem item in shopItemList)
            {
                ShopItemView itemView = Instantiate(shopListViewPrefab, shopListContent.transform).GetComponent<ShopItemView>();
                itemView.item = item;
                itemView.UpdateUI();
            }
            CountSellItems();
        }
        public void SetAndUpdateShop(ModelShop shopModelAdd)
        {
            /* Method that receives an shop model and set to the currentShop, used only in the inspectio via unity event from interaction systems,
             * the method is used this way, so the UI can be renewed every time that the player interact with an difrent shop.
             */

            shopItemList.Clear();
            shopModel = shopModelAdd;

            this.shopModel = shopModelAdd;
            shopItemList.AddRange(shopModelAdd.itemList);
            UpdateShopUI();
        }
        #endregion

        #region - Item Interactions and Callbacks -
        public void ItemBuyed(ShopItem item)//Callback called every time that an item is buyed.
        {
            shopItemList.Remove(item);
            UpdateShopUI();
        }
        public void ItemModified() => CountSellItems();//Callback called every time that an item is modified in the shop buy slots.
        private int CountSellItems() //This method calculates and shows the total value that the player will get if he sell all the items in the shop slots.
        {
            int totalValue = 0;
            foreach(Model_Slot slot in SellableItems) if (slot.hasItem) totalValue += slot.GetItem().ItemSellCost;

            sellTotalValue.text = string.Format("Sell Value:{0}", totalValue);
            return totalValue;
        }
        public void SellItems()//this method sell all the items in the shop slots, and gives the sell price sum to the player total money.
        {
            int value = CountSellItems();

            foreach(Model_Slot slot in SellableItems) slot.RemoveItem();
            PlayerSystems.Instance.currentMoney += value;
        }
        #endregion
    }
}