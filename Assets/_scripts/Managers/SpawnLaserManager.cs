using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLaserManager : MonoBehaviour
{

    public GameObject Laser;
    public GameObject LaserEye;

    private static SpawnLaserManager _instance;
    public static SpawnLaserManager instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<SpawnLaserManager>();
            return _instance;
        }
    }

    void OnEnable()
    {
        UpgradeUnlockLaser.OnUnlockLaser += Initialize;
    }

    private void OnDisable()
    {
        UpgradeUnlockLaser.OnUnlockLaser -= Initialize;
    }

    void Initialize()
    {
        StartCoroutine("SpawningLaser");

        // display laser
        LaserEye.SetActive(true);
    }


    IEnumerator SpawningLaser (){
		while(true)
		{
			yield return  new WaitForSeconds(GetWaitingTime());
            if (!GameManager.instance.isGameStopped)
            {
                SpawnLaser();
            }
		}
	}

    void SpawnLaser()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, -1f);


        GameObject go = Instantiate(Laser, spawnPosition,  Quaternion.identity) as GameObject;
        go.transform.SetParent(transform);
    }


    float GetWaitingTime()
    {
        return GameDataManager.instance.spawnLaserWaitingTime;
    }



}
