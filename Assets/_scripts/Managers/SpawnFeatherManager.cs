using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFeatherManager : MonoBehaviour
{

    public Collider2D SpawnFeathersArea;
    public GameObject Feather;

    private static SpawnFeatherManager _instance;
    public static SpawnFeatherManager instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<SpawnFeatherManager>();
            return _instance;
        }
    }

    void Start()
    {
        StartCoroutine("SpawningFeathers");
    }

    // void Update()
    // {
    //     if (GameManager.instance.stopGame)
    //     {
    //         StopCoroutine("SpawningEggs");
    //         return;
    //     }
    // }

    IEnumerator SpawningFeathers (){
		while(true)
		{
			yield return  new WaitForSeconds(GetWaitingTime());
            if (!GameManager.instance.isGameStopped)
            {
                SpawnFeather();
            }
		}
	}

    void SpawnFeather()
    {
            Vector3 spawnPosition = RandomPointInBounds(SpawnFeathersArea.bounds);
            spawnPosition.z = -1f;

            GameObject go = Instantiate(Feather, spawnPosition,  Quaternion.identity) as GameObject;
            go.transform.rotation = Quaternion.Euler(0, 0, 90);
            go.transform.SetParent(transform);
    }


    float GetWaitingTime()
    {
        return GameDataManager.instance.spawnFeatherWaitingTime;
    }

    public static Vector3 RandomPointInBounds(Bounds bounds) {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

}
