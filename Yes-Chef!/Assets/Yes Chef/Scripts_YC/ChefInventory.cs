using System.Collections.Generic;
using UnityEngine;

public class ChefInventory : MonoBehaviour
{
    public const int MaxHands = 2;

    public List<IngredientData> heldIngredients = new();

    public bool AddIngredient(IngredientData ingredient)
    {
        if (heldIngredients.Count >= MaxHands)
            return false;

        heldIngredients.Add(ingredient);

        InventoryUI.Instance.Refresh();
        return true;
    }

    public void RemoveIngredient(int index)
    {
        if (index < 0 || index >= heldIngredients.Count)
            return;

        heldIngredients.RemoveAt(index);

        InventoryUI.Instance.Refresh();
    }

    public void RemoveIngredientByData(IngredientData ingredient)
    {
        heldIngredients.Remove(ingredient);
        InventoryUI.Instance.Refresh();
    }
}