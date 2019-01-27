using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GoToIntroScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToCreditScene()
    {
        SceneManager.LoadScene(2);
    }
}
