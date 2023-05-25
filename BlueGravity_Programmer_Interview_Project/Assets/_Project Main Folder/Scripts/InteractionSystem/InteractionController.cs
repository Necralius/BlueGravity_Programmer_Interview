using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NekraliusDevelopmentStudio
{
    public class InteractionController : MonoBehaviour
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //InteractionController - (0.1)
        //State: - (Needs Refactoring, Needs Coments, Needs Improvement)
        //This code represents (Code functionality or code meaning)

        #region - Singleton Pattern -
        public static InteractionController Instance;
        private void Awake() => Instance = this;
        #endregion

        public TextMeshPro buttonText;
        public bool isOnInteractable = false;

        public void SetUpKey(Interactable interactableAsset)
        {
            buttonText.text = string.Format("Press E Key {0} ", interactableAsset.interactionDetail);
            buttonText.transform.position = interactableAsset.interactionTextSpawn.position;
        }
        public void UpdateUI_State(bool state) { buttonText.gameObject.SetActive(state); isOnInteractable = state; }
    }
}