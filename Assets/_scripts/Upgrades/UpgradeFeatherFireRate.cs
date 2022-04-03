using UnityEngine;

public class UpgradeFeatherFireRate : Upgrade
{
    public override void ApplyEffect()
    {
        GameDataManager.instance.spawnFeatherWaitingTime /= 2;
    }

}
