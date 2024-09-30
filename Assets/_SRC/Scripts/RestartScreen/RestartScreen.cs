using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScreen : MonoBehaviour
{
    public GameObject restartScreen;
    public void Setup()
    {
        restartScreen.SetActive(true);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
