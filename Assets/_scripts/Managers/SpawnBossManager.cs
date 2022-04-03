using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossManager : MonoBehaviour
{

    public bool STOP = false;

    public Collider2D SpawnEnemiesArea;
    public List<GameObject> Enemies;

    private static SpawnBossManager _instance;
    public static SpawnBossManager instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<SpawnBossManager>();
            return _instance;
        }
    }

    void Start()
    {
        StartCoroutine("SpawningBoss");
        StartCoroutine("IncreaseDifficulty");
    }

    // void Update()
    // {
    //     if (GameManager.instance.stopGame)
    //     {
    //         StopCoroutine("SpawningEggs");
    //         return;
    //     }
    // }

    IEnumerator SpawningBoss (){
		while(true)
		{
			yield return  new WaitForSeconds(GetWaitingTime());
            if (!GameManager.instance.isGameStopped && !STOP)
            {
                SpawnBoss();
            }
		}
	}

    void SpawnBoss()
    {
            Vector3 spawnPosition = RandomPointInBounds(SpawnEnemiesArea.bounds);
            spawnPosition.z = -1f;

            GameObject pickedEnemy = Enemies[Random.Range(0, Enemies.Count)];
            GameObject go = Instantiate(pickedEnemy, spawnPosition,  Quaternion.identity) as GameObject;
            go.transform.SetParent(transform);

            Enemy boss = go.GetComponent<Enemy>();
            boss.life = GameDataManager.instance.bossLife;
            GameDataManager.instance.bosses.Add(boss);
    }


    float GetWaitingTime()
    {
        float min = GameDataManager.instance.spawnBossWaitingTime * .8f;
        float max = GameDataManager.instance.spawnBossWaitingTime * 1.2f;
        return Random.Range(min, max);
    }

    public static Vector3 RandomPointInBounds(Bounds bounds) {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    IEnumerator IncreaseDifficulty (){
		while(true)
		{
			yield return  new WaitForSeconds(20f);
            if (!GameManager.instance.isGameStopped && !STOP)
            {
                //  increase life
                GameDataManager.instance.bossLife += 400f;
            }
		}
	}

}
