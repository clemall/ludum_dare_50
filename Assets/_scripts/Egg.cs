﻿using UnityEngine;
using System;

public class Egg : MonoBehaviour
{

    public static event Action OnPickupEgg;

    public void OnMouseDown()
    {
        PickEgg();
    }


    public void PickEgg()
    {
        GameDataManager.instance.eggs += GameDataManager.instance.eggValue;
        OnPickupEgg?.Invoke();
        Destroy(gameObject);
    }
}
