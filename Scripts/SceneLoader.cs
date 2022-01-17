using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region Singleton
    public static SceneLoader sceneLoaderButton;

    private void Awake()
    {
        sceneLoaderButton = this;

        gameObject.SetActive(false);
    }
    #endregion

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
