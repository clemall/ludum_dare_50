using UnityEngine;

public class UpgradeLaserDamage : Upgrade
{
    public override void ApplyEffect()
    {
        GameDataManager.instance.laserDamage *= 2;
    }

    public override bool SetInteractable()
    {
        bool result = base.SetInteractable();

        return result && GameDataManager.instance.unlockLaser;
    }

}
