using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Health Health {
        get {
            if(health == null) {
                health = GetComponent<Health>();
            }
            return health;
        }
    }
    private Health health;
    private PlayerController playerController;

    private void Start() {
       GetAllPlayerComponents();
    }

    public void Disable() {
        ShowPlayer(false);
        EnableControls(false);
    }
    
    public void Reset() {
        health.Reset();
    }

    public void Enable() {
        ShowPlayer(true);
        EnableControls(true);
    }

    private void ShowPlayer(bool show) {
        gameObject.SetActive(show);
    }

    private void EnableControls(bool enable) {
        playerController.enabled = enable;
    }

    private void GetAllPlayerComponents() {
        health = GetComponent<Health>();
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "EndGoal") 
        {
            GameManager.Instance.FinishedLevel();
        }
    }
}
