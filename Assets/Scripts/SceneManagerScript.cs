using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene(int scene_index)
    {
        SceneManager.LoadScene(scene_index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
