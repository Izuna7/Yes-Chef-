using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IngredientProcess : MonoBehaviour
{
    [SerializeField] private GameObject resultPrefab; // chopped carrot / cooked meat
    [SerializeField] private Image countdownUI;
    [SerializeField] private float duration = 1f;

    private void Start()
    {
        StartCoroutine(Process());
    }

    private IEnumerator Process()
    {
        float timer = 0f;
        countdownUI.fillAmount = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            countdownUI.fillAmount = timer / duration;
            yield return null;
        }

        countdownUI.fillAmount = 1f;

        Instantiate(
            resultPrefab,
            transform.position,
            transform.rotation);

        Destroy(gameObject);
    }
}
