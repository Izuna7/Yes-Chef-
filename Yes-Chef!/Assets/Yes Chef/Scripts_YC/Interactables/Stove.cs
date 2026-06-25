using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    [SerializeField]
    private ChefInventory chefInventory;
    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private int maxCapacity = 2;
    private int currentCount = 0;

    public List<IngredientData> cookedMeat = new();
    public List<GameObject> cookedMeatPrefabs = new();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("P"))
            return;


        if (cookedMeat.Count > 0)
        {
            if (chefInventory.AddIngredient(cookedMeat[0]))
            {
                Destroy(cookedMeatPrefabs[0]);

                cookedMeat.RemoveAt(0);
                cookedMeatPrefabs.RemoveAt(0);
                currentCount--;
            }

            return;
        }

        // Stove is full
        if (currentCount >= maxCapacity)
            return;


        for (int i = 0; i < chefInventory.heldIngredients.Count; i++)
        {
            if (chefInventory.heldIngredients[i].placeWhere == BaseIngredientType.ForStove)
            {
                Vector3 spawnPos =spawnPoint.transform.position + new Vector3(currentCount * 1.4f, 0.8f, 0f);

                GameObject meat = Instantiate(
                    chefInventory.heldIngredients[i].worldPrefab,
                    spawnPos,
                    Quaternion.identity
                );
                currentCount++;

                chefInventory.RemoveIngredient(i);

                break;
            }
        }
    }
}