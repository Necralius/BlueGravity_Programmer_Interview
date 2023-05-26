using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NekraliusDevelopmentStudio
{
    public class Layer_PaperDoll : MonoBehaviour
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //Layer_PaperDoll - (0.1)
        //State: Functional
        //This code represents an paper doll system layer.

        public int paperDollID = 0; //-> The layer carrys an integer that works as an indentificator.

        #region - Layer Management -
        //The class carrys also methods to activate and deactivate the layer, basically representig an cloth equip and dequip action.
        public void Activate() => gameObject.SetActive(true);
        public void Deactivate() => gameObject.SetActive(false);
        #endregion
    }
}