using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject hud;
    public Button resumeButton;
    public Button mainMenuButton;
    void Start()
    {
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !pauseScreen.activeSelf)
        {
            PauseGame();
        }
        else if ((Input.GetButtonDown("Cancel")) && pauseScreen.activeSelf)
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
        } else if (pauseScreen.activeSelf && Time.timeScale == 0)
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
    }

    private void ButtonCallBack(Button buttonPressed)
    {
        if (buttonPressed == resumeButton)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            hud.SetActive(true);
        }
    }
}
