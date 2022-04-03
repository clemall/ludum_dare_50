using UnityEngine;

public class UpgradeFeatherRange : Upgrade
{
    public override void ApplyEffect()
    {
        GameDataManager.instance.bulletLifeTime *= 2;
    }

}
