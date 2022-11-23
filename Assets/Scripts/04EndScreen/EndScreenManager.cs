using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitToReturnToMenu());
    }

    private IEnumerator WaitToReturnToMenu() 
    {
        yield return new WaitForSeconds(5f);
        StateManager.Instance.ChangeState(States.Menu);
    }
}
