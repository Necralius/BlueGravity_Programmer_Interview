using NekraliusDevelopmentStudio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NekraliusDevelopmentStudio
{
    public class Model_ClothSlot : Model_Slot
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //Model_ClothSlot - (0.1)
        //State: Functional
        //This code represents an cloth slot model that carries a especific add behavior. 

        #region - Custom Cloth Item Add -
        public virtual void AddClothItem(Model_ClothItem item) { } //This method carrys and cloth item add, so this way adding and not implemented void that exists with the purpose to be implemented in future classes.
        #endregion
    }
}