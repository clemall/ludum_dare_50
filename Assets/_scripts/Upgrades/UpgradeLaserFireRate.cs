using UnityEngine;

public class UpgradeLaserFireRate : Upgrade
{
    public override void ApplyEffect()
    {
        GameDataManager.instance.spawnLaserWaitingTime /= 2;
    }

    public override bool SetInteractable()
    {
        bool result = base.SetInteractable();

        return result && GameDataManager.instance.unlockLaser;
    }

}
