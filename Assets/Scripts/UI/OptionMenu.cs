using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.WSA;

public class OptionMenu : MonoBehaviour
{
    public static OptionMenu instance;

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
    [SerializeField] AudioMixer mixer;
    public AudioSource clickAudio;

    [Header("Sprites de Opciones")]
    [SerializeField] Texture[] music_spr;
    [SerializeField] Texture[] sound_spr;
    [SerializeField] Texture[] sensivility_spr;
    public RawImage actualMusicImage;
    public RawImage actualSoundImage;
    public RawImage actualSensivilityImage;


    void Awake()
    {
        instance = this;
        Time.timeScale = 1;
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
        if (buttonPressed)
        {
            clickAudio.Play();
        }

        if (buttonPressed == musicDownButton)
        {

            if (musicVol > 0)
            {
                musicVol --;
                mixer.SetFloat("volumeMusic", (musicVol - 5) * 4);
                if (musicVol == 0)
                {
                    mixer.SetFloat("volumeMusic", -80);
                }

                actualMusicImage.texture = music_spr[musicVol];
            }
        }
        if (buttonPressed == musicUpButton)
        {
            if (musicVol < 10)
            {
                musicVol ++ ;
                mixer.SetFloat("volumeMusic", (musicVol-5)*4);
                actualMusicImage.texture = music_spr[musicVol];
            }
        }

        if (buttonPressed == soundDownButton)
        {
            if (soundVol > 0)
            {
                soundVol--;
                mixer.SetFloat("volumeSfx", (soundVol - 5) * 4);
                if (soundVol == 0)
                {
                    mixer.SetFloat("volumeSfx", -80);
                }

                actualSoundImage.texture = sound_spr[soundVol];
            }

        }
        if (buttonPressed == soundUpButton)
        {
            if (soundVol < 10)
            {
                soundVol++;
                mixer.SetFloat("volumeSfx", (soundVol - 5) * 4);
                actualSoundImage.texture = sound_spr[soundVol];
            }
        }

        if (buttonPressed == sensivilityDownButton)
        {
            if (sensivility > 100)
            {
                sensivility -= 5;
                actualSensivilityImage.texture = sensivility_spr[sensivility / 5 - 20];
                Movement.instance.mouseSensitivity = sensivility;
            }
        }
        if (buttonPressed == sensivilityUpButton)
        {
            if (sensivility < 150)
            {
                sensivility += 5;
                actualSensivilityImage.texture = sensivility_spr[sensivility / 5 - 20];
                Movement.instance.mouseSensitivity = sensivility;
            }
        }
        if (buttonPressed == returnGameButton)
        {
            optionsScreen.SetActive(false);
            menuScreen.SetActive(true);
            
        }

    }

}
