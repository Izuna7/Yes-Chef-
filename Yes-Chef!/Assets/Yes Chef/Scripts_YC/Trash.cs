using UnityEngine;
using UnityEngine.UI;

public class Trash : MonoBehaviour
{
    public Image TrashUI;

    [SerializeField] private ChefInventory chefInventory;

    [SerializeField] private Image trashImage1;
    [SerializeField] private Image trashImage2;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("P"))
            return;

        TrashUI.gameObject.SetActive(true);
        Refresh();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TrashUI.gameObject.SetActive(false);
    }

    public void Refresh()
    {
        UpdateSlot(trashImage1, 0);
        UpdateSlot(trashImage2, 1);
    }

    private void UpdateSlot(Image slot, int index)
    {
        if (index < chefInventory.heldIngredients.Count)
        {
            slot.enabled = true;
            slot.sprite = chefInventory.heldIngredients[index].icon;
        }
        else
        {
            slot.enabled = false;
        }
    }

    public void TrashOutFirst()
    {
        chefInventory.RemoveIngredient(0);
    }

    public void TrashOutSecond()
    {
        chefInventory.RemoveIngredient(1);
    }
}
