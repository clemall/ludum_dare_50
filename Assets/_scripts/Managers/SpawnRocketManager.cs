using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocketManager : MonoBehaviour
{

    public GameObject rocket;
    public GameObject rocketLauncher;
    public GameObject rocketSpawnPosition;

    private static SpawnRocketManager _instance;
    public static SpawnRocketManager instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<SpawnRocketManager>();
            return _instance;
        }
    }

    void OnEnable()
    {
        UpgradeUnlockRocket.OnUnlockRocket += Initialize;
    }

    private void OnDisable()
    {
        UpgradeUnlockRocket.OnUnlockRocket -= Initialize;
    }

    void Initialize()
    {
        StartCoroutine("SpawningRocket");

        // display rocket launcher
        rocketLauncher.SetActive(true);
    }


    IEnumerator SpawningRocket (){
		while(true)
		{
			yield return  new WaitForSeconds(GetWaitingTime());
            if (!GameManager.instance.isGameStopped)
            {
                SpawnRocket();
            }
		}
	}

    void SpawnRocket()
    {
        Vector3 spawnPosition = new Vector3(rocketSpawnPosition.transform.position.x, rocketSpawnPosition.transform.position.y, -1f);


        GameObject go = Instantiate(rocket, spawnPosition,  Quaternion.identity) as GameObject;
        go.transform.SetParent(transform);
    }


    float GetWaitingTime()
    {
        return GameDataManager.instance.spawnRocketWaitingTime;
    }



}
