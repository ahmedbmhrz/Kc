using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // threr is no kitchenobject 
            if (player.HasKitchenObject())
            {
                //player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }else
            {
                //player not carrying anything
            }
        } else
        {
            //there is a kitchenobject 
            if (player.HasKitchenObject())
            {
                //player is carrying something
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {//player is holding Plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                    GetKitchenObject().DestroySelf();

                    }
                }
                else
                {
                        //player is not carrying plate but something else
                        if(GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        //Counter is holding a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) ;
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            } else
            {
                //player not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }  
}
