using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryMangerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;


    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
         
    }

    private void Start()
    {
        DeliveryMangar.Instance.OnRecipeSpawned += DeliveryManger_OnRecipeSpawned;
        DeliveryMangar.Instance.OnRecipeCompleted += DeliveryManger_OnRecipeCompleted;

        UpdateVisual();

    }

    private void DeliveryManger_OnRecipeCompleted(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void DeliveryManger_OnRecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == recipeTemplate) continue;
            Destroy(child.gameObject);
        }

       foreach(RecipeSO recipeSO in DeliveryMangar.Instance.GetWaitingRecipeSOList())
        {
           Transform recipeTransform =  Instantiate(recipeTemplate, container);
            recipeTransform.gameObject.SetActive (true);
            recipeTransform.GetComponent<DeliveryMangerSingleUI>().setRecipeSO(recipeSO);
        }
    }
}
