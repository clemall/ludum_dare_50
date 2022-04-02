using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEggsManager : MonoBehaviour
{

    public Collider2D SpawnEggsArea;
    public GameObject Egg;

    private static SpawnEggsManager _instance;
    public static SpawnEggsManager instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<SpawnEggsManager>();
            return _instance;
        }
    }

    void Start()
    {
        StartCoroutine("SpawningEggs");
    }

    // void Update()
    // {
    //     if (GameManager.instance.stopGame)
    //     {
    //         StopCoroutine("SpawningEggs");
    //         return;
    //     }
    // }

    IEnumerator SpawningEggs (){
		while(true)
		{
			yield return  new WaitForSeconds(GetWaitingTime());
            if (!GameManager.instance.isGameStopped)
            {
                SpawnEgg();
            }
		}
	}

    void SpawnEgg()
    {
            Vector3 spawnPosition = RandomPointInBounds(SpawnEggsArea.bounds);
            spawnPosition.z = -1f;

            GameObject go = Instantiate(Egg, spawnPosition,  Quaternion.identity) as GameObject;
            go.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-50, 50));
            go.transform.SetParent(transform);
    }


    float GetWaitingTime()
    {
        return GameDataManager.instance.spawnEggsWaitingTime;
    }

    public static Vector3 RandomPointInBounds(Bounds bounds) {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

}
