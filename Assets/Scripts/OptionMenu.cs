using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.WSA;

public class OptionMenu : MonoBehaviour
{
    public Button musicDownButton;
    public Button musicUpButton;
    public Button soundDownButton;
    public Button soundUpButton;
    public Button sensivilityDownButton;
    public Button sensivilityUpButton;

    public Button returnGameButton;
    public GameObject menuScreen;
    public GameObject optionsScreen;

    public int musicVol;
    public int soundVol;
    public int sensivility;


    [Header("Sonidos de menu")]
    [SerializeField] AudioSource menuMusic;
    [SerializeField] AudioSource snd_opcion;
    [SerializeField] AudioSource snd_seleccion;

    [Header("Sprites de Opciones")]
    [SerializeField] Sprite musica_on;
    [SerializeField] Sprite musica_off;
    [SerializeField] Sprite sonido_on;
    [SerializeField] Sprite sonido_off;
    [SerializeField] Sprite volver_on;
    [SerializeField] Sprite volver_off;
    [SerializeField] Sprite vol_on;
    [SerializeField] Sprite vol_off;
    [SerializeField] SpriteRenderer[] musica_spr;
    [SerializeField] SpriteRenderer[] sonido_spr;

    GameObject[] sonidos;

    private void Start()
    {
        sonidos = GameObject.FindGameObjectsWithTag("Sonidos");
        
    }

    private void OnEnable()
    {

        musicDownButton.onClick.AddListener(() => ButtonCallBack(musicDownButton));
        musicUpButton.onClick.AddListener(() => ButtonCallBack(musicUpButton));

        soundDownButton.onClick.AddListener(() => ButtonCallBack(soundDownButton));
        soundUpButton.onClick.AddListener(() => ButtonCallBack(soundUpButton));

        sensivilityDownButton.onClick.AddListener(() => ButtonCallBack(sensivilityDownButton));
        sensivilityUpButton.onClick.AddListener(() => ButtonCallBack(sensivilityUpButton));

        returnGameButton.onClick.AddListener(() => ButtonCallBack(returnGameButton));
    }
    private void ButtonCallBack(Button buttonPressed)
    {

        if (buttonPressed == musicDownButton)
        {
            if (musicVol > 0)
            {
                musicVol--;
                menuMusic.volume = musicVol / 10f;
            }
        }
        if (buttonPressed == musicUpButton)
        {
            if (musicVol < 10)
            {
                musicVol++;
                menuMusic.volume = musicVol / 10f;
            }
        }

        if (buttonPressed == soundDownButton)
        {
            if (soundVol > 0)
            {
                soundVol--;
                foreach (GameObject sonido in sonidos)
                {
                    sonido.GetComponent<AudioSource>().volume = soundVol / 10f;
                }
            }

        }
        if (buttonPressed == soundUpButton)
        {
            if (soundVol < 10)
            {
                soundVol++;
                foreach (GameObject sonido in sonidos)
                {
                    sonido.GetComponent<AudioSource>().volume = soundVol / 10f;
                }
            }
        }

        if (buttonPressed == sensivilityDownButton)
        {
            if (sensivility > 0)
            {
                sensivility--;
            }
        }
        if (buttonPressed == sensivilityUpButton)
        {
            if (sensivility < 10)
            {
                sensivility++;
            }
        }
        if (buttonPressed == returnGameButton)
        {
            optionsScreen.SetActive(false);
            menuScreen.SetActive(true);
        }

    }

}
