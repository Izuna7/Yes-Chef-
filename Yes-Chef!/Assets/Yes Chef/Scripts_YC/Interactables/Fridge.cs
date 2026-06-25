using UnityEngine;
using UnityEngine.UI;

public class Fridge : MonoBehaviour
{
    [SerializeField]
    private Image FridgeUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("P"))
        {
            FridgeUI.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("P"))
        {
            FridgeUI.gameObject.SetActive(false);
        }
    }
}
