using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EggsRessourceGUI : MonoBehaviour
{

    public TextMeshProUGUI uiEggText;

    void OnGUI(){
        uiEggText.text = GameDataManager.instance.eggs.ToString();
    }
}


