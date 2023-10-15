using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject optionsScreen;
    public GameObject hud;
    public Button resumeButton;
    public Button mainMenuButton;

    public AudioSource clickAudio;
    void Start()
    {
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseGame(); 
        }
    }
    private void PauseGame()
    {
        if (!pauseScreen.activeSelf && Time.timeScale == 1)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            hud.SetActive(false);
        } else if (pauseScreen.activeSelf && Time.timeScale == 0 && !optionsScreen.activeSelf)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            hud.SetActive(true);
        }
    }
    private void OnEnable()
    {
        resumeButton.onClick.AddListener(() => ButtonCallBack(resumeButton));
        mainMenuButton.onClick.AddListener(() => ButtonCallBack(mainMenuButton));
    }



    private void ButtonCallBack(Button buttonPressed)
    {
        if (buttonPressed)
        {
            clickAudio.Play();
        }

        if (buttonPressed == resumeButton)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            hud.SetActive(true);
        }

        if (buttonPressed == mainMenuButton)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}
