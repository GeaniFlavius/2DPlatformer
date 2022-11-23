using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;

    private StateMachine<States> stateMachine;
    
    #region unity methods
    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this);
        }

        stateMachine = new StateMachine<States>(this);
    }
    private void Start() {
        stateMachine.ChangeState(States.Menu);
    }
    #endregion


    
    #region Change State
    public void ChangeState(States state) {
        stateMachine.ChangeState(state);
    }
    #endregion


    
    #region Menu State
    private void Menu_Enter() {
        print("entered menu");
        MySceneManager.Instance.LoadScene(States.Menu);
    }
    private void Menu_Exit() {
        print("exited menu");
        LevelTransition.Instance.TransitionFromScene(States.Menu);
    }
    #endregion


    
    #region Game State 
    private void Game_Enter() {
        print("entered game");
        MySceneManager.Instance.LoadScene(States.Game);
    }
    private void Game_Exit() {
        print("exited game");
        LevelTransition.Instance.TransitionFromScene(States.Game);
    }
    #endregion



    #region End Screen State 
    private void EndScreen_Enter() {
        print("entered endscreen state");
        MySceneManager.Instance.LoadScene(States.EndScreen);
    }
    private void EndScreen_Exit() {
        print("exited endscreen state");
        LevelTransition.Instance.TransitionFromScene(States.EndScreen);
    }
    #endregion



    #region Dead State 
    private void Dead_Enter() {
        print("entered dead state");
    }
    private void Dead_Exit() {
        print("exited dead state");
    }
    #endregion



    #region haru State for testing
    private void Haru_Enter() {
        print("entered haru state");
    }
    private void Haru_Exit() {
        print("exited haru state");
    }
    #endregion
}
