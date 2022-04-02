using UnityEngine;

public class GameDataManager : MonoBehaviour
{

    public int eggs = 0;
    public float spawnEggsWaitingTime = 2f;
    public float spawnEnemiesWaitingTime = 0.1f;

    public float enemyMovementSpeed = 1f;
    public float enemyLife = 100f;

    public float bulletDamage = 100f;
    public float bulletBasicMovementSpeed = 3f;
    public float bulletLifeTime = 2f;

    public float spawnFeatherWaitingTime = 1f;




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
