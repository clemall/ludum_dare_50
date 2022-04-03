using UnityEngine;

public class UpgradesManager : MonoBehaviour
{




    private static UpgradesManager _instance;
    public static UpgradesManager instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<UpgradesManager>();
            return _instance;
        }
    }
}
