using UnityEngine;

public class UpgradeEggsValue : Upgrade
{
    public override void ApplyEffect()
    {
        GameDataManager.instance.eggValue *= 2;
    }

}
