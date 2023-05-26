using UnityEngine;

namespace NekraliusDevelopmentStudio
{
    [CreateAssetMenu(fileName = "New Shop Item", menuName = "Blue Gravity/Item/New Shop Item")]
    public class ShopItem : ScriptableObject
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //ShopItem - (0.2)
        //State: Functional
        //This code represents an shop item model that holds and item model, and different item icons for better representation in the shop UI.

        [Header("Item Aspects")]
        public Sprite[] itemIcons;
        public Model_Item itemHolded;
    }
}