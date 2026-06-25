using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [SerializeField] private ChefInventory inventory;

    [SerializeField] private Image hand1;
    [SerializeField] private Image hand2;

    private void Awake()
    {
        Instance = this;
    }

    public void Refresh()
    {
        UpdateSlot(hand1, 0);
        UpdateSlot(hand2, 1);
    }

    private void UpdateSlot(Image slot, int index)
    {
        if (index < inventory.heldIngredients.Count)
        {
            slot.enabled = true;
            slot.sprite = inventory.heldIngredients[index].icon;
        }
        else
        {
            slot.enabled = false;
        }
    }
}