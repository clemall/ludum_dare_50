using UnityEngine;


public class Enemy : MonoBehaviour
{

    public GameObject deathAnimnation;
    public float life;

    void Start()
    {
        life = GameDataManager.instance.enemyLife;
    }

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance.isGameStopped)
        {
            return;
        }

        string tag = other.gameObject.tag;
        if (tag == "Player")
        {
            RemovedAndAnimated(deathAnimnation);
            GameManager.instance.gameOver();
        }

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
    }

    private void RemovedAndAnimated(GameObject anim){
        Instantiate(anim, transform.position,  Quaternion.identity);

        Destroy(gameObject);
    }
}
