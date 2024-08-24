using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    private IKitchenOtjectParent kitchenObtjectParent;
    public KitchenObjectSO GetKitchenObjectSO() 
    { 
        return kitchenObjectSO; 
    }

    public void SetKitchenObjectParent(IKitchenOtjectParent kitchenOtjectParent)
    {
        if(this.kitchenObtjectParent != null)
        {
            this.kitchenObtjectParent.ClearKitchenObject();
        }
        this.kitchenObtjectParent = kitchenOtjectParent;

        if(kitchenOtjectParent.HasKitchenObject() )
        {
            Debug.LogError("kitchenOtjectParent Alreadt has a kithesObject");
        }

        kitchenOtjectParent.SetKitchenObject(this);

        transform.parent = kitchenOtjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public IKitchenOtjectParent GetKitchenOtjectParent()
    {
        return kitchenObtjectParent;
    }

    public void DestroySelf()
    {
        kitchenObtjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject)
    {
        if(this is PlateKitchenObject)
        {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        }
        else 
        {
            plateKitchenObject = null;
            return false;
        }
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenOtjectParent kitchenOtjectParent)
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        
        kitchenObject.SetKitchenObjectParent(kitchenOtjectParent);

        return kitchenObject; 
    }
}
