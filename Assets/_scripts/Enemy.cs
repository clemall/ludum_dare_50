using UnityEngine;


public class Enemy : MonoBehaviour
{

    public GameObject deathAnimnation;
    public float life;
    private Rigidbody2D rb;

    private bool isDead = false;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.instance.isGameStopped)
        {
            return;
        }

        // Vector3 pos = new Vector3(- GameDataManager.instance.enemyMovementSpeed * Time.deltaTime,
        //                           0,
        //                           0);
        //
        // transform.Translate(pos, Space.World);

    }

    void FixedUpdate()
    {
        if (GameManager.instance.isGameStopped)
        {
            return;
        }
        Vector2 velocity = new Vector2(- GameDataManager.instance.enemyMovementSpeed, 0);
        rb.MovePosition(rb.position +  velocity * Time.fixedDeltaTime);
    }


    public void AddDamage(float damage)
    {
        if (isDead)
        {
            return;
        }

        life -= damage;

        rb.AddForce(new Vector2(GameDataManager.instance.enemyForcePushedBack, 0));

        if (life <= 0)
        {
            isDead = true;
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
