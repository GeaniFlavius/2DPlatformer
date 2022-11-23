using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Image healthBar;
    public Sprite[] healthBarStates;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this);
        }
    }


    public void ShowHealthElement(bool show) {
        healthBar.gameObject.SetActive(false);
    }

    public void UpdateHealthElement(int value) 
    {
        if(value > healthBarStates.Length) 
        {
            return;
        }

        healthBar.sprite = healthBarStates[value];
    }
}
