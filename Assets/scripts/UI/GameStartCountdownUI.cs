using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;



    private void Start()
    {
        KitchenGameMangar.Instance.OnStateChanged += KitchenGameMangar_OnStateChanged;

        Hide();
    }

    private void KitchenGameMangar_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameMangar.Instance.IsCountdownToStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Update()
    {
        countdownText.text = Mathf.Ceil(KitchenGameMangar.Instance.GetCountdownToStartTimer()).ToString();
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
