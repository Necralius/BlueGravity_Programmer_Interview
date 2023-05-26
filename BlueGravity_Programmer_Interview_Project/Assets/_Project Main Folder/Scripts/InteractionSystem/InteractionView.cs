using TMPro;
using UnityEngine;

namespace NekraliusDevelopmentStudio
{
    public class InteractionView : MonoBehaviour
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //InteractionView - (0.2)
        //State: Functional
        //This code represents an interaction UI controller that updates all the interaction active UI.

        #region - Singleton Pattern -
        //This structures represents an simple singleton pattern implementation
        public static InteractionView Instance;
        private void Awake() => Instance = this;
        #endregion

        #region - View UI Data -
        public TextMeshPro buttonText;
        public bool isOnInteractable = false;
        #endregion

        #region - UI Update -
        public void SetUpInteraction(Interactable interactableAsset)
        {
            //This method updates the interaction UI, seting the correct text, and changing his position to the interaction position.
            buttonText.text = string.Format("Press E Key {0} ", interactableAsset.interactionDetail);
            buttonText.transform.position = interactableAsset.interactionTextSpawn.position;
        }
        public void UpdateUI_State(bool state) { buttonText.gameObject.SetActive(state); isOnInteractable = state; }//This method manages the UI current state
        #endregion
    }
}