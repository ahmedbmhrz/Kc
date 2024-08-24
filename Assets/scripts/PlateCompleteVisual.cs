using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{

    [Serializable]
    public struct KitchenObjectSO_GameObjcet
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObjectSO_GameObjcet> KitchenObjectSOGameObjcetsList;


    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
        foreach (KitchenObjectSO_GameObjcet kitchenObjectSOGameObjcet in KitchenObjectSOGameObjcetsList)
        {
                kitchenObjectSOGameObjcet.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (KitchenObjectSO_GameObjcet kitchenObjectSOGameObjcet in  KitchenObjectSOGameObjcetsList)
        {
            if(kitchenObjectSOGameObjcet.kitchenObjectSO == e.kitchenObjectSO)
            {
                kitchenObjectSOGameObjcet.gameObject.SetActive(true);
            }
        }
    }
}
