using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour, IUpgrade
{

    public int cost = 0;
    private Button btn;

    void OnEnable()
    {
        btn = gameObject.GetComponent<Button>();

        Egg.OnPickupEgg += UpdateState;

        GameDataManager.instance.upgrades.Add(this);

        btn.interactable = SetInteractable();
    }

    private void OnDisable()
    {
        Egg.OnPickupEgg -= UpdateState;
    }

    public virtual void ApplyEffect() {}

    public void Buy()
    {
        if (GameDataManager.instance.eggs >= cost)
        {
            GameDataManager.instance.amountOfUpgradeBought += 1;
            GameDataManager.instance.eggs -= cost;

            ApplyEffect();

            // update states of all upgrades
            for (int i = GameDataManager.instance.upgrades.Count - 1; i >= 0; i--)
            {
                GameDataManager.instance.upgrades[i].UpdateState();
            }

            // disable upgrade
            gameObject.SetActive(false);
        }
    }

    public virtual bool SetInteractable()
    {
        return GameDataManager.instance.eggs >= cost;
    }

    void UpdateState()
    {
        if (GameManager.instance.isGameStopped)
        {
            return;
        }

        btn.interactable = SetInteractable();



    }
}
