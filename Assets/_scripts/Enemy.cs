using UnityEngine;


public class Enemy : MonoBehaviour
{

    public GameObject deathAnimnation;
    public float life;


    void Update()
    {
        if (GameManager.instance.isGameStopped)
        {
            return;
        }

        Vector3 pos = new Vector3(- GameDataManager.instance.enemyMovementSpeed * Time.deltaTime,
                                  0,
                                  0);

        transform.Translate(pos, Space.World);

    }


    public void AddDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            TriggerDeath();
        }
    }

    void TriggerDeath()
    {
        RemovedAndAnimated(deathAnimnation);

        GameDataManager.instance.enemies.Remove(this);
    }

    private void RemovedAndAnimated(GameObject anim){
        Instantiate(anim, transform.position,  Quaternion.identity);

        Destroy(gameObject);
    }
}
