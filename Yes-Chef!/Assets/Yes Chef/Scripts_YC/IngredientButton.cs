using UnityEngine;

public class IngredientButton : MonoBehaviour
{
    [SerializeField] private IngredientData ingredient;
    [SerializeField] private ChefInventory chefInventory;

   public void ClickIngredient()
    {
        chefInventory.AddIngredient(ingredient);
    }
}