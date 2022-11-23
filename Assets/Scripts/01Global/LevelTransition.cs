using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    public static LevelTransition Instance;
    private Animator transition;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this);
        }

        GameObject blackImage = transform.GetChild(0).gameObject;
        blackImage.SetActive(true);
        
        transition = GetComponentInChildren<Animator>();
    }

    public void TransitionFromScene(States scene) {
        StartCoroutine(UnloadSceneWithTransition(scene));
    }

    private IEnumerator UnloadSceneWithTransition(States scene) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);

        MySceneManager.Instance.UnloadScene(scene);
    }
}
