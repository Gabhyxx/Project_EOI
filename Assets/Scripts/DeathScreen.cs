using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject hud;

    // Start is called before the first frame update
    void Start()
    {
        deathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Player>().health<=0)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        deathScreen.SetActive(true);
        GetComponent<Movement>().enabled = false;
        GetComponent<Pause>().enabled = false;
        Invoke("ToMainMenu", 5);
    }

    private void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
