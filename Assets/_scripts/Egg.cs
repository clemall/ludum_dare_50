using UnityEngine;

public class Egg : MonoBehaviour
{

    public void OnMouseDown()
    {
        GameDataManager.instance.eggs += 1;
        Destroy(gameObject);
    }
}
