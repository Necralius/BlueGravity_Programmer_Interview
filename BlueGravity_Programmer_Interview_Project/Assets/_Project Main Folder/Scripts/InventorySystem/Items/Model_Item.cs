using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NekraliusDevelopmentStudio
{
    [CreateAssetMenu(fileName ="New Item", menuName = "Blue Gravity/Item/New Item")]
    public class Model_Item : ScriptableObject
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //Model_Item - (0.1)
        //State: Functional
        //This code represents an base item model that carrys all the item base informations.

        public string ItemName;
        public Sprite ItemIcon;

        public int ItemSellCost;
        public int ItemBuyCost;
    }
}