using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesManager : MonoBehaviour
{

    public bool STOP = false;

    public Collider2D SpawnEnemiesArea;
    public List<GameObject> Enemies;

    private static SpawnEnemiesManager _instance;
    public static SpawnEnemiesManager instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<SpawnEnemiesManager>();
            return _instance;
        }
    }

    void Start()
    {
        StartCoroutine("SpawningEnemies");
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

    IEnumerator SpawningEnemies (){
		while(true)
		{
			yield return  new WaitForSeconds(GetWaitingTime());
            if (!GameManager.instance.isGameStopped && !STOP)
            {
                SpawnEnemie();
            }
		}
	}

    void SpawnEnemie()
    {
            Vector3 spawnPosition = RandomPointInBounds(SpawnEnemiesArea.bounds);
            spawnPosition.z = -1f;

            GameObject pickedEnemy = Enemies[Random.Range(0, Enemies.Count)];
            GameObject go = Instantiate(pickedEnemy, spawnPosition,  Quaternion.identity) as GameObject;
            go.transform.SetParent(transform);

            Enemy enemy = go.GetComponent<Enemy>();
            enemy.life = GameDataManager.instance.enemyLife;
            GameDataManager.instance.enemies.Add(enemy);
    }


    float GetWaitingTime()
    {
        float min = GameDataManager.instance.spawnEnemiesWaitingTime * .8f;
        float max = GameDataManager.instance.spawnEnemiesWaitingTime * 1.2f;
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
			yield return  new WaitForSeconds(6f);
            if (!GameManager.instance.isGameStopped && !STOP)
            {
                //  increase life and spawn rate
                GameDataManager.instance.spawnEnemiesWaitingTime *= GameDataManager.instance.spawnEnemiesWaitingTimeFactor;
                GameDataManager.instance.enemyLife += Random.Range(GameDataManager.instance.enemyLifeFactor, GameDataManager.instance.enemyLifeFactor * 3f);
            }
		}
	}

}
