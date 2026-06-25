using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Counter : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject counterUI;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private OrderSlotUI[] slots;
    [SerializeField] private ChefInventory chefInventory;
    [SerializeField] private GameManager_YC gameManager;
    private int score;

    private bool counting;
    private float timer;

    [Header("Order")]
    public List<IngredientData> possibleIngredients;

    public List<IngredientData> currentOrder = new();

    private void Start()
    {
        GenerateOrder();
       
    }

    private void Update()
    {
        if (!counting) return;
        
        timer += Time.deltaTime;
        timerText.text = timer.ToString("F0");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("P")) return;

        counterUI.gameObject.SetActive(true);

        for (int i = 0; i < chefInventory.heldIngredients.Count; i++)
        {
            DeliverIngredient(chefInventory.heldIngredients[i]);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("P")) return;

        counterUI.gameObject.SetActive(false);
    }

    public void GenerateOrder()
    {
        timer = 0;
        counting = true;
        currentOrder.Clear();
        score = 0;
      

        int ingredientCount = Random.value < 0.5f ? 2 : 3;

        for (int i = 0; i < ingredientCount; i++)
        {
            IngredientData randomIngredient =
                possibleIngredients[Random.Range(0, possibleIngredients.Count)];

            currentOrder.Add(randomIngredient);
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        // Disable all slots first
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].gameObject.SetActive(false);
        }

        // Enable only required slots
        for (int i = 0; i < currentOrder.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].Setup(currentOrder[i]);
        }
    }

    public bool DeliverIngredient(IngredientData ingredient)
    {
        for (int i = 0; i < currentOrder.Count; i++)
        {
            if (slots[i].Completed)
                continue;

            if (slots[i].Ingredient == ingredient)
            {
                slots[i].Complete();
                score += ingredient.ingredientScore;
                chefInventory.RemoveIngredientByData(ingredient);

                CheckOrderComplete();

                return true;
            }
        }

        return false;
    }

    private void CheckOrderComplete()
    {
        for (int i = 0; i < currentOrder.Count; i++)
        {
            if (!slots[i].Completed)
                return;
        }

        Debug.Log("Order Complete!");
        counting = false;
        int counterScore = score - Mathf.FloorToInt(timer);
        gameManager.AddGameScore(counterScore);
        timer = 0;

        timerText.text = 0.ToString();
        scoreText.text = counterScore.ToString("+0;-0;0");
        scoreText.gameObject.SetActive(true);
        Invoke(nameof(DisableUI), 1.5f);

        Invoke(nameof(GenerateOrder), 5);
    }

    void DisableUI()
    {
        scoreText.gameObject.SetActive(false);
        scoreText.text = 0.ToString();
    }

   
}