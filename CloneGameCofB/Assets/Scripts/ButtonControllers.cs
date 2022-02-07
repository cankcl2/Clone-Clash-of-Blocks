using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonControllers : MonoBehaviour
{
    [ExecuteAlways]
    public void ReplayButton()
    {
        SceneManager.LoadScene("Level6");
    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
