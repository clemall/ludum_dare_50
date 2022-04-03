using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = GameDataManager.instance.enemies.Count - 1; i >= 0; i--)
        {
            GameDataManager.instance.enemies[i].AddDamage(GameDataManager.instance.laserDamage);
        }

        for (int j = GameDataManager.instance.bosses.Count - 1; j >= 0; j--)
        {
            GameDataManager.instance.bosses[j].AddDamage(GameDataManager.instance.laserDamage);
        }
    }

}
