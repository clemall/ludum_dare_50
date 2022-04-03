using UnityEngine;

public class UpgradeMetalFeather : Upgrade
{
    public override void ApplyEffect()
    {
        GameDataManager.instance.bulletDamage += 400;
        GameDataManager.instance.unlockMetalFeather = true;
    }

}
