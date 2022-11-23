using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void ChangeToGameState() {
        StateManager.Instance.ChangeState(States.Game);
    }

    public void QuitApplication() {
        Application.Quit();
    }
}
