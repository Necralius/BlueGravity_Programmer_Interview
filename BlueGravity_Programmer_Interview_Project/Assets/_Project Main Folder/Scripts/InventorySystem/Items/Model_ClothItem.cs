using UnityEngine;

namespace NekraliusDevelopmentStudio
{ 
    public class Model_ClothItem : Model_Item
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //Model_ClothItem - (0.1)
        //State: Functional
        //This code represents an simple cloth item, that carries an unique information from the cloth item type.

        [Header("Paper Doll Data")]
        public int paperDollLayerID = 0; //-> This integer tells what papedoll layer the item is related to.
    }
}