using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeDeliveredText;

    private void Start()
    {
        KitchenGameMangar.Instance.OnStateChanged += KitchenGameMangar_OnStateChanged;

        Hide();
    }

    private void KitchenGameMangar_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameMangar.Instance.IsGameOver())
        {
            Show();

            recipeDeliveredText.text = DeliveryMangar.Instance.GetSucceessfulRecipeAmount().ToString();
        }
        else
        {
            Hide();
        }
    }



    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
