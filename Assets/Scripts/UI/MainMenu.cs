using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.WSA;

public class MainMenu : MonoBehaviour
{
    public Button newGameButton;
    public Button loadGameButton;
    public Button optionGameButton;
    public Button exitGameButton;
    public GameObject menuScreen;
    public GameObject optionsScreen;
    public GameObject player;

    public AudioSource clickAudio;

    private void OnEnable()
    {
        newGameButton.onClick.AddListener(() => ButtonCallBack(newGameButton));
        loadGameButton.onClick.AddListener(() => ButtonCallBack(loadGameButton));
        optionGameButton.onClick.AddListener(() => ButtonCallBack(optionGameButton));
        exitGameButton.onClick.AddListener(() => ButtonCallBack(exitGameButton));
    }
    private void ButtonCallBack(Button buttonPressed)
    {
        if (buttonPressed)
        {
            clickAudio.Play();
        }

        if (buttonPressed == newGameButton)
        {
            SceneManager.LoadScene("LevelDemo", LoadSceneMode.Single);
            Player.isLoad = false;
        }
        if (buttonPressed == loadGameButton)
        {
            SceneManager.LoadScene("LevelDemo", LoadSceneMode.Single);
            Player.isLoad = true;
        }
        if (buttonPressed == optionGameButton)
        {
            menuScreen.SetActive(false);
            optionsScreen.SetActive(true);
        }
        if (buttonPressed == exitGameButton)
        {
            UnityEngine.Application.Quit();
        }
    }
}
