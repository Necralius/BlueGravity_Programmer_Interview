using NekraliusDevelopmentStudio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NekraliusDevelopmentStudio
{
    [CreateAssetMenu(fileName = "New Food Item", menuName = "Blue Gravity/Item/New Food Item")]
    public class Model_FoodItem : Model_Item
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //Model_FoodItem - (0.1)
        //State: Functional
        //This code represents an simple food item, that carries an unique information from the food item type.

        public float eatValue; //-> This information tells the nutritional value of the current food.
    }
}