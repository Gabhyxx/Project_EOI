using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsToMainMenu : MonoBehaviour
{
    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");   
    }
}
