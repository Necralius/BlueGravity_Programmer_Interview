
namespace NekraliusDevelopmentStudio
{
    public class ModelShopSlot : Model_Slot
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //ModelShopSlot - (0.1)
        //State: Functional
        //This code represents an simple slot that inhirit from the main slot model, the purpose of this code is implement an especific method that callback everytime that an item in this type of slot is modified.

        public override void ItemModifiedCallback() //Callback called every time that an item is added or removed from an slot.
        {
            ShopSystem.Instace.UpdateShopUI();
            base.ItemModifiedCallback();
        }
    }
}