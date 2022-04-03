using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance.isGameStopped)
        {
            return;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer ("enemy"))
        {
            GameManager.instance.gameOver();
        }

    }
}
