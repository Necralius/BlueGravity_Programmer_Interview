using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NekraliusDevelopmentStudio
{
    public class InventoryController : MonoBehaviour
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //InventoryController - (0.4)
        //State: Functional
        //This code represents the general inventory controller, is responsible for adding and removing items, and open and close the complete inventory.

        #region - Singleton Pattern -
        public static InventoryController Instance;
        private void Awake() => Instance = this;
        #endregion

        #region - Inventory Data -
        [Header("Slots Data")]
        public List<Model_Slot> slots;

        [Header("Inventory Object")]
        public GameObject inventoryObject;
        public bool inventoryIsOpen = false;

        [Header("Sound FX")]
        public AudioClip inventoryOpen;
        public AudioClip inventoryClose;
        #endregion

        //============================Methods============================//

        #region - BuiltIn Methods -
        private void Update() //-> Called at every frame update
        {
            SystemInput();
            UpdateInventoryUI();
        }
        #endregion

        #region - Item Management -
        public bool AddItem<T>(T item) where T : Model_Item
        {
            //This methods receive an generic type that inherit from Model_Item, that represent the item base class model, after the receive the method verifies if exists empty slots, and if exists, the item is added to the inventory.
            //NOTE: I am using generics for make an open model that can receive any type of item to be added, needing only that this item inherit from Model_Item.

            foreach (var slot in slots)
            {
                if (slot.hasItem) continue;
                else
                {
                    slot.AddItem(item);
                    UpdateInventoryUI();
                    return true;
                }
            }
            Debug.Log("Invetory is full!");
            return false;
        }
        public void RemoveItem(Model_Slot slot) //This method remove the item from an especific slot passed as argument.
        {
            slot.RemoveItem();
            UpdateInventoryUI();
        }
        #endregion

        #region - Inventory Open/Close -
        private void SystemInput() //This method handle the inventory open and close system.
        {
            if (InputManager.Instance.inventoryActed)
            {
                if (inventoryIsOpen) GameManager.Instance.PlaySound(inventoryOpen);
                else GameManager.Instance.PlaySound(inventoryClose);
                inventoryIsOpen = !inventoryIsOpen;
                inventoryObject.SetActive(inventoryIsOpen);
            }
        }
        #endregion

        #region - UI Update -
        public void UpdateInventoryUI() => slots.ForEach(slot => slot.UpdateUI());
        //This method run by all slots, and update his UIs one by one, is used basically in every item change ou inventory change.
        #endregion
    }
}