using UnityEngine;

public class CookedMeat : MonoBehaviour
{
    private Stove stove;
    [SerializeField]
    private IngredientData cookedMeat;

    void Start()
    {
        stove = FindFirstObjectByType<Stove>();

        stove.cookedMeat.Add(cookedMeat);
        stove.cookedMeatPrefabs.Add(gameObject);
    }

}
