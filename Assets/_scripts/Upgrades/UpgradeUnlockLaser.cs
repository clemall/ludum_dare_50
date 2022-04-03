using UnityEngine;
using System;
public class UpgradeUnlockLaser : Upgrade
{

    public static event Action OnUnlockLaser;
    public override void ApplyEffect()
    {
        GameDataManager.instance.unlockLaser = true;

        OnUnlockLaser?.Invoke();
    }
}
