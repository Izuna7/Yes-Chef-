using UnityEngine;
using UnityEngine.UI;

public class OrderSlotUI : MonoBehaviour
{
    public Image ingredientImage;
    [SerializeField] private Image tickImage;

    public IngredientData Ingredient { get; private set; }
    public bool Completed { get; private set; }

    public void Setup(IngredientData ingredient)
    {
        Ingredient = ingredient;

        ingredientImage.sprite = ingredient.icon;
        ingredientImage.preserveAspect = true;

        tickImage.gameObject.SetActive(false);

        Completed = false;
    }

    public void Complete()
    {
        Completed = true;
        tickImage.gameObject.SetActive(true);
    }
}