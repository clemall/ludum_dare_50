using UnityEngine;

public class UpgradeRocketDamage : Upgrade
{
    public override void ApplyEffect()
    {
        GameDataManager.instance.rocketDamage *= 2;
    }

    public override bool SetInteractable()
    {
        bool result = base.SetInteractable();

        return result && GameDataManager.instance.unlockRocket;
    }

}
