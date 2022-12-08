using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    Scene Scene;

    private void Update()
    {
        Scene = SceneManager.GetActiveScene();
    }

    void OnTriggerEnter(Collider other)
    {
        if(Scene == SceneManager.GetSceneByBuildIndex(2))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
