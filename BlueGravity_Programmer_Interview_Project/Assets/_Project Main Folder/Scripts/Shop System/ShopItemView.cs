using NekraliusDevelopmentStudio;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
    //ShopItemView - (0.1)
    //State: - (Needs Refactoring, Needs Coments, Needs Improvement)
    //This code represents (Code functionality or code meaning)

    #region - Shop Item View UI Data -
    [Header("Shop Item View UI")]
    public Image itemImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemPrice;
    
    private Sprite selectedIcon;
    private int iconIndex = 0;
    #endregion
    
    #region - Item Data -
    public ShopItem item;
    public AudioClip itemBuySound;
    #endregion

    //============================Methods============================//

    #region - BuiltIn Methods -
    private void Start() //-> Called in the game start
    {
        selectedIcon = item.itemIcons[0];
        UpdateUI();
    }
    #endregion

    #region - UI Update -
    public void UpdateUI() //-> This method update all the shop item view, update the texts, images and etc...
    {
        itemImage.sprite = selectedIcon;
        itemName.text = item.itemHolded.ItemName;
        itemPrice.text = string.Format("Item Price: {0}", item.itemHolded.ItemBuyCost);
    }
    #endregion

    #region - UI Interaction -
    public void NextIcon() //-> This method walks between all the item icons showing them on the item icon, for a better item visualization.
    {
        iconIndex++;
        if (iconIndex > item.itemIcons.Length - 1) iconIndex = 0;

        selectedIcon = item.itemIcons[iconIndex];
        UpdateUI();
    }
    #endregion

    #region - Item Main Buy Action -
    public void BuyItem() //This method is executed when the player buys the item.
    {
        //When buyed, system verifies if the player has the needed money, if it has, the item is removed from the current slot, the player get the item and give the money away.
        if (PlayerSystems.Instance.currentMoney >= item.itemHolded.ItemBuyCost)
        {
            if (InventoryController.Instance.AddItem(item.itemHolded))
            {
                PlayerSystems.Instance.currentMoney -= item.itemHolded.ItemBuyCost;
                ShopSystem.Instace.ItemBuyed(this.item);
            }

            //ShopSystem.Instace.shopModel.RemoveShopItem(item.itemHolded); -> Activate this if the item buy action gonna change the scriptable shop model
            GameManager.Instance.PlaySound(itemBuySound);
            Destroy(gameObject);
        }
    }
    #endregion
}