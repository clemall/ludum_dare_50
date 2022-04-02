using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject deathAnimnation;
    public float damage;
    public float lifeTime;

    void Start()
    {
        damage = GameDataManager.instance.bulletDamage;
        lifeTime = GameDataManager.instance.bulletLifeTime;
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

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance.isGameStopped)
        {
            return;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer ("enemy"))
        {
            RemovedAndAnimated(deathAnimnation);
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.AddDamage(damage);
        }

    }

    private void RemovedAndAnimated(GameObject anim){
        Instantiate(anim, transform.position,  Quaternion.identity);

        Destroy(gameObject);
    }
}
