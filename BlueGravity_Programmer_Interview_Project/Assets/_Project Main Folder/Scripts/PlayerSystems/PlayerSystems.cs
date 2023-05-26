using NekraliusDevelopmentStudio;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSystems : MonoBehaviour
{
    //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
    //InputManager - (0.3)
    //State: Functional
    //This code represents a player aspects systems, like a hunger system, economy system and its default behaviors, also updating this informations on the game UI.

    #region - Singleton Pattern -
    public static PlayerSystems Instance;
    private void Awake() => Instance = this;
    #endregion

    #region - Survival -
    [Header("Hunger Data")]
    public float hungerValue;
    public float maxHunger;
    public float hungerLossTax;
    #endregion

    #region - Finantial -
    [Header("Economy Data")]
    public int currentMoney;
    #endregion

    #region - UI Data -
    [Header("UI Data")]
    public Slider hungerSlider;
    public TextMeshProUGUI moneyText;
    #endregion

    //============================Methods============================//

    #region - BuiltIn Methods -
    private void Start() //-> Called in the game start
    {
        //The below statements are setting the default values on the UI sliders.
        hungerValue = maxHunger;
        hungerSlider.maxValue = maxHunger;
    }
    public void Update() //-> Called at every frame update
    {
        SurvivalBehaviorSystem();
        UpdateUI();
    }
    #endregion

    #region - UI Update -
    private void UpdateUI()//This method updates the player aspects UI.
    {
        hungerSlider.value = hungerValue;
        moneyText.text = string.Format("Total Money: " + currentMoney);
    }
    #endregion

    #region - Survival Behavior Methods -
    private void SurvivalBehaviorSystem() //This method execute the survival behavior sets, like hunger tax loss beteween time to simulate an actual hunger.
    {
        if (hungerValue <= 0) hungerValue = 0;
        else hungerValue -= hungerLossTax / 100;
    }
    public void EatFood(Model_Item item) //This methods add food nutritional value to the hunger.
    {
        float hungerValue = 0;
        Model_FoodItem itemFood = (Model_FoodItem)item;
        hungerValue = itemFood.eatValue;

        if (this.hungerValue + hungerValue >= maxHunger) hungerValue = maxHunger;
        else this.hungerValue += hungerValue;
    }
    #endregion
}