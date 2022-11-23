using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this);
        }
    }

    private void Start() {
        AddPlayerListeners();
        UpdateHealthOnUI();
    }

    private void AddPlayerListeners() {
        player.Health.hasDied += Restart;
        player.Health.updatedHealth += UpdateHealthOnUI;
        player.Health.updatedHealth += UpdateHealthOnUI;
    }

    private void Restart() {
        print("restarted");
        StartCoroutine(RestartProcess());
    }

    private IEnumerator RestartProcess() {
        ChangeToDeadState();
        yield return new WaitForSeconds(1f);
        ChangeToGameState();
    }

    private void ChangeToDeadState() {
        StateManager.Instance.ChangeState(States.Dead);
        player.Disable();
        player.Reset();
    }

    private void ChangeToGameState() {
        StateManager.Instance.ChangeState(States.Game);
        player.Enable();
    }

    private void ChangeToEndScreenState() 
    {
        StateManager.Instance.ChangeState(States.EndScreen);
        player.Disable();
        player.Reset();
    }

    // private void UpdateHealthOnUI() {
    //     UIManager.Instance.healthText.text = "HP: " + player.Health.HealthValue.ToString();
    // }
    private void UpdateHealthOnUI() {
        UIManager.Instance.UpdateHealthElement(player.Health.HealthValue);
    }

    public void FinishedLevel() 
    {
        ChangeToEndScreenState();
    }
}
