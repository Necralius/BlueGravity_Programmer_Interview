using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NekraliusDevelopmentStudio
{
    public class PaperDollSystem : MonoBehaviour
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //PaperDollSystem - (0.3)
        //State: Functional
        //This code represents an Paper Doll system manager, that controls all layers, activating the current items equiped and deactivating the others.

        #region - Singleton Pattern -
        public static PaperDollSystem Instance;
        private void Awake() => Instance = this;
        #endregion

        #region - Layers Data -
        public List<Layer_PaperDoll> paperDollLayers = new List<Layer_PaperDoll>();
        #endregion

        #region - Interaction Data -
        public AudioClip equipCloth;
        public AudioClip dequipCloth;
        #endregion

        //============================Methods============================//

        #region - Layer Activation and Management -
        public void SetUpLayer(int Layer_ID) //This methods use and integer to identify an activate the cloth layer.
        {
            foreach (Layer_PaperDoll layer in paperDollLayers)
            {
                if (layer.paperDollID == Layer_ID)
                {
                    layer.Activate();
                    GameManager.Instance.PlaySound(equipCloth);
                    break;
                }
            }
        }
        public void DequipLayer(int Layer_ID) //This methods use and integer to identify an deactivate the cloth layer.
        {
            foreach (Layer_PaperDoll layer in paperDollLayers)
            {
                if (layer.paperDollID == Layer_ID)
                {
                    GameManager.Instance.PlaySound(dequipCloth);
                    layer.Deactivate();
                    break;
                }
            }
        }
        #endregion
    }
}