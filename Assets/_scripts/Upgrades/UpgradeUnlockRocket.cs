using UnityEngine;
using System;
public class UpgradeUnlockRocket : Upgrade
{

    public static event Action OnUnlockRocket;
    public override void ApplyEffect()
    {
        GameDataManager.instance.unlockRocket = true;

        OnUnlockRocket?.Invoke();
    }
}
