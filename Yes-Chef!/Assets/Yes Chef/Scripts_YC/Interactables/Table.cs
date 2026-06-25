using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField]
    private ChefInventory chefInventory;

    [SerializeField]
    private int maxCapacity = 1;
    private int currentCount = 0;

    public List<IngredientData> choppedVegetables = new();
    public List<GameObject> choppedVegetablesPrefabs = new();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("P"))
            return;

        if (choppedVegetables.Count > 0)
        {
            if (chefInventory.AddIngredient(choppedVegetables[0]))
            {
                Destroy(choppedVegetablesPrefabs[0]);

                choppedVegetables.RemoveAt(0);
                choppedVegetablesPrefabs.RemoveAt(0);
                currentCount--;
            }        
            return;

        }

        if (currentCount >= maxCapacity)
            return;

        for (int i = 0; i < chefInventory.heldIngredients.Count; i++)
        {
            if (chefInventory.heldIngredients[i].placeWhere == BaseIngredientType.ForTable)
            {
                Vector3 spawnPos = transform.position + new Vector3(choppedVegetablesPrefabs.Count * 0.5f, 0f, 0f);

                Instantiate(chefInventory.heldIngredients[i].worldPrefab, spawnPos, Quaternion.identity);
                currentCount++;

                chefInventory.RemoveIngredient(i);


                break;
            }
        }
    }
 
}
