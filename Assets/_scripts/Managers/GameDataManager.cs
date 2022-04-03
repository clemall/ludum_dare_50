using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    [Space(10)]
    [Header("Eggs")]
    public int eggs = 0;
    public int eggValue = 1;
    public float spawnEggsWaitingTime = 2f;

    [Space(10)]
    [Header("Enemies")]
    public float spawnEnemiesWaitingTime = 3f;
    public float enemyMovementSpeed = 1f;
    public float enemyLife = 100f;
    public float enemyLifeFactor = 10f;
    public float enemyForcePushedBack = 1000f;
    public float spawnEnemiesWaitingTimeFactor = 0.99f;
    public List<Enemy> enemies = new List<Enemy>();

    [Space(10)]
    [Header("Boss")]
    public float spawnBossWaitingTime = 20f;
    // public float bossMovementSpeed = 1f;
    public float bossLife = 600f;
    public List<Enemy> bosses = new List<Enemy>();

    [Space(10)]
    [Header("Bullet")]
    public float bulletDamage = 100f;
    public float bulletBasicMovementSpeed = 10f;
    public float bulletLifeTime = 0.5f;

    [Space(10)]
    [Header("Laser")]
    public float laserDamage = 400f;
    public float spawnLaserWaitingTime = 4f;

    [Space(10)]
    [Header("Feather")]
    public float spawnFeatherWaitingTime = 1.2f;

    [Space(10)]
    [Header("Rocket")]
    public float rocketDamage = 400f;
    public float rocketMovementSpeed = 16f;
    public float rocketArea = 5f;
    public float rocketLifeTime = 3f;
    public float spawnRocketWaitingTime = 2f;


    [Space(10)]
    [Header("Upgrades")]
    public int amountOfUpgradeBought = 0;
    public bool unlockMetalFeather = false;
    public bool unlockLaser = false;
    public bool unlockRocket = false;
    public List<Upgrade> upgrades = new List<Upgrade>();


    // [Space(10)]
    // [Header("Golden egg")]
    // public float spawnGoldenEggWaitingTimeMin = 20f;


    private static GameDataManager _instance;
    public static GameDataManager instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<GameDataManager>();
            return _instance;
        }
    }

}
