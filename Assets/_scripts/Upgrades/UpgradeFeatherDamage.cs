using UnityEngine;

public class UpgradeFeatherDamage : Upgrade
{
    public override void ApplyEffect()
    {
        GameDataManager.instance.bulletDamage *= 2;
    }

}
