using UnityEngine;

public class BulletBasicMovement : MonoBehaviour
{
    void Update()
    {
        if (GameManager.instance.isGameStopped)
        {
            return;
        }

        Vector3 pos = new Vector3(GameDataManager.instance.bulletBasicMovementSpeed * Time.deltaTime,
                                  0,
                                  0);

        transform.Translate(pos, Space.World);

    }
}
