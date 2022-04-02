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
    }


    float GetWaitingTime()
    {
        return GameDataManager.instance.spawnEnemiesWaitingTime;
    }

    public static Vector3 RandomPointInBounds(Bounds bounds) {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

}
