using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{

    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;


    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;


    private float spawnPlateTimer;
    private float spawnPlateTimeMax = 4f;
    private int platespawnedAmount;
    private int platespawnedAmountMax = 4;

    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;

        if(spawnPlateTimer > spawnPlateTimeMax)
        {
            spawnPlateTimer = 0f;

            if(platespawnedAmount < platespawnedAmountMax)
            {
                platespawnedAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            //Player is empty handed
            if(platespawnedAmount > 0)
            {
                //there it least one plate here
                platespawnedAmount--;

                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);


                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }

        }
    }


}
