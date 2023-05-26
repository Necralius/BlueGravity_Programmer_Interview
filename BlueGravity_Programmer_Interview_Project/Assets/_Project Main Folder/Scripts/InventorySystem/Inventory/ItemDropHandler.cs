using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NekraliusDevelopmentStudio
{
    public class ItemDropHandler : MonoBehaviour, IDropHandler
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //ItemDropHandler - (0.2)
        //State: Functional
        //This code represents an item drop action handler.

        public void OnDrop(PointerEventData eventData)//This method detects when the user get the mouse button up in the object area.
        {
            if (!GetComponentInParent<Model_Slot>().hasItem) //First the system verifies if the slot is empty.
            {
                /*If it is empty, the system will get the correct item type to the correct slot type, Example Head_Items only can be attatched to HeadSlots and common
                 * slots.
                 * NOTE:Also the items that are HeadItems and SuitItems only be equiped in the body in his equivalent slots.
                 */

                if (GetComponentInParent<Model_HeadSlot>())
                {
                    Model_Item newItem = eventData.pointerDrag.GetComponent<ItemDragHandler>().currentSlot.GetItem();
                    if (newItem is Model_HeadItem) GetComponentInParent<Model_HeadSlot>().AddClothItem((Model_HeadItem)eventData.pointerDrag.GetComponent<ItemDragHandler>().currentSlot.RemoveItem());
                }
                else if (GetComponentInParent<Model_SuitSlot>())
                {
                    Model_Item newItem = eventData.pointerDrag.GetComponent<ItemDragHandler>().currentSlot.GetItem();
                    if (newItem is Model_SuitItem) GetComponentInParent<Model_SuitSlot>().AddClothItem((Model_SuitItem)eventData.pointerDrag.GetComponent<ItemDragHandler>().currentSlot.RemoveItem());
                }
                else if (GetComponentInParent<Model_Slot>() is ModelShopSlot)
                {
                    //This method verifies if the slot dropped is and shop slot, and execute the necessary updates and values passes.
                    GetComponentInParent<Model_Slot>().AddItem(eventData.pointerDrag.GetComponent<ItemDragHandler>().currentSlot.RemoveItem());
                    ShopSystem.Instace.ItemModified();
                }
                else if (GetComponentInParent<Model_Slot>())
                {
                    //If the slot is of an commum type (Model_Slot) the item is normaly added to the slot.
                    GetComponentInParent<Model_Slot>().AddItem(eventData.pointerDrag.GetComponent<ItemDragHandler>().currentSlot.RemoveItem());
                }
                else return;
            }
        }
    }
}