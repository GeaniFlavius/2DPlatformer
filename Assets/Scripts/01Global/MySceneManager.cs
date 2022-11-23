using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance;



    #region unity methods
    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this);
        }
    }
    #endregion



    #region scene management
    public void LoadScene(States sceneIndex) {
        StartCoroutine(WaitToLoadScene(sceneIndex));
    }
    public void UnloadScene(States scene) {
        int sceneIndex = (int) scene;
        SceneManager.UnloadSceneAsync(sceneIndex);
    }

    private IEnumerator WaitToLoadScene(States sceneIndex) {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync((int)sceneIndex, LoadSceneMode.Additive);
    }
    #endregion

}
