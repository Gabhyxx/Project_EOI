using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button newGameButton;
    public Button loadGameButton;
    public Button exitGameButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        newGameButton.onClick.AddListener(() => ButtonCallBack(newGameButton));
        loadGameButton.onClick.AddListener(() => ButtonCallBack(loadGameButton));
        exitGameButton.onClick.AddListener(() => ButtonCallBack(exitGameButton));
    }
    private void ButtonCallBack(Button buttonPressed)
    {
        if (buttonPressed == newGameButton)
        {
            SceneManager.LoadScene("MallLevel", LoadSceneMode.Single);
        }
        if (buttonPressed == loadGameButton)
        {
            SceneManager.LoadScene("MallLevel", LoadSceneMode.Single);
        }
        if (buttonPressed == exitGameButton)
        {
            Application.Quit();
        }
    }
}
