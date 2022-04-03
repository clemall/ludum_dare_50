using UnityEngine;

public class Rocket : MonoBehaviour
{

    public GameObject deathAnimnation;
    public float lifeTime;

    void Start()
    {
        lifeTime = GameDataManager.instance.rocketLifeTime;
    }

    void Update()
    {
        if (GameManager.instance.isGameStopped)
        {
            return;
        }

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            RemovedAndAnimated(deathAnimnation);
        }

        Vector3 pos = new Vector3(GameDataManager.instance.rocketMovementSpeed * Time.deltaTime,
                                  0,
                                  0);

        transform.Translate(pos, Space.World);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance.isGameStopped)
        {
            return;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer ("enemy"))
        {
		    for (int i = GameDataManager.instance.enemies.Count - 1; i >= 0; i--) {
			    Enemy e =  GameDataManager.instance.enemies[i];
			    // check the distance between the target and the proceed enemy
			    // if the distance is in range, boom!
			    if(Vector2.Distance(transform.position, e.transform.position) <= GameDataManager.instance.rocketArea){
				    e.AddDamage( GameDataManager.instance.rocketDamage);
			    }
		    }


            RemovedAndAnimated(deathAnimnation);
        }

    }

    private void RemovedAndAnimated(GameObject anim){
        Instantiate(anim, transform.position,  Quaternion.identity);

        Destroy(gameObject);
    }
}
