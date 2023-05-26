using System.Collections.Generic;
using UnityEngine;

namespace NekraliusDevelopmentStudio
{
    [CreateAssetMenu(fileName = "New Shop Model", menuName = "Blue Gravity/Shop/New Shop Model")]
    public class ModelShop : ScriptableObject
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //ModelShop - (0.4)
        //State: Functional
        //This code represents an shop complete model that contain items to be selled and an simple name.

        public string shopName;
        public List<ShopItem> itemList;

        public void RemoveShopItem(Model_Item itemToRemove)
        {
            /* This method removes an item that is been buyed in the shop model. 
             * NOTE: The method is only used if the system has the need of remove the item from the scriptable shop model.
             */

            foreach (ShopItem shopItem in itemList)
            {
                if (shopItem.itemHolded.Equals(itemToRemove))
                {
                    itemList.Remove(shopItem);
                    break;
                }
            }
        }
    }
}