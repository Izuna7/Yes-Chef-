using UnityEngine;

public class ChoppedCarrot : MonoBehaviour
{
    private Table table;
    [SerializeField]
    private IngredientData choppedCarrot;
   
    void Start()
    {
        table = FindFirstObjectByType<Table>();

        table.choppedVegetables.Add(choppedCarrot);
        table.choppedVegetablesPrefabs.Add(gameObject);
    }

   
    void Update()
    {
        
    }
}
