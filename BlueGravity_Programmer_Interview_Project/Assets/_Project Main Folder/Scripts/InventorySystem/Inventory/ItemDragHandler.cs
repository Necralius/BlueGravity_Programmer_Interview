using NekraliusDevelopmentStudio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerClickHandler
{
    //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
    //ItemDragHandler - (0.3)
    //State: Functional
    //This code represents an item drag handler that receive some BuiltIn unity mouse events interfaces that enables the use of the mouse as an very active input, this class handle the drag start, persistent drag and the drag end.

    Transform parentSave;
    public Image image => GetComponent<Image>();
    [HideInInspector] public Model_Slot currentSlot;

    private void OnEnable() //-> Method called when the item is seted to enable
    {
        currentSlot = GetComponentInParent<Model_Slot>();
    }
    public void OnBeginDrag(PointerEventData eventData) 
    {
        /*Method called when the mouse pointer starts an drag on this object, also as all mouse event interfaces, the method receive an argument that has a lot of 
         * information about the mouse pointer, what makes this very usefull.
         * NOTE: Note that the image raycast target is disable when the drag action starts, the system is maded this way because when an item is beteween the target 
         * slot to drop and the mouse pointer, the slot cannot be detected, thus making the drag and drop action between slots impossible.
         */

        image.raycastTarget = false;
        parentSave = transform.parent;
        transform.SetParent(transform.root);

        if (currentSlot.item is Model_ClothItem)
        {
            //This statement verifies if the item dragged is and cloth item, and if it is, the cloth item is unequiped from the player.
            Model_ClothItem clothItem = (Model_ClothItem)currentSlot.item;
            PaperDollSystem.Instance.DequipLayer(clothItem.paperDollLayerID);
        }
    }
    public void OnDrag(PointerEventData eventData) //Method called every frame that the pointer is beeing dragged in the object.
    {
        //This method sets the gameobject position to the mouse position, making and great drag visual feeling.
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData) //Method called every time that the mouse pointer ends and drag action in the object.
    {
        //In hte method the item will return to his original position and the raycastTarget property is turned again to true.
        image.raycastTarget = true;
        transform.SetParent(parentSave);
    }

    public void OnPointerClick(PointerEventData eventData) //This method detects an mouse click on the object
    {
        if ((int)(eventData.button) == 1) //This statement verifies witch mouse button has been trigged (Left(0), Right(1), Middle(2)). 
        {
            if (currentSlot.item is Model_FoodItem)
            {
                PlayerSystems.Instance.EatFood(currentSlot.RemoveItem()); 
                //This statement verifies if the holded item is an food, and if it is, clicking with the right button the player will consume the food and remove it from the inventory.
            }
        }
    }
}