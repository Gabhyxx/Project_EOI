using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject tutorialDash;
    public GameObject tutorialArmyChange;
    public GameObject tutorialFlashlight;

    public bool dash = false;
    public bool armyChange = false;
    public bool flashlight = false;

    // Update is called once per frame
    void Update()
    {
        if (!dash && Movement.instance.transform.position.x > -228 && Movement.instance.transform.position.x < -220)
        {
            dash = true;
            tutorialDash.SetActive(true);
            StartCoroutine(Wait());
        }
        if (!armyChange && Movement.instance.transform.position.x > -280 && Movement.instance.transform.position.x < -270)
        {
            armyChange = true;
            tutorialArmyChange.SetActive(true);
            StartCoroutine(Wait());
        }
        if (!flashlight && Movement.instance.transform.position.x > -100 && Movement.instance.transform.position.x < -90)
        {
            flashlight = true;
            tutorialFlashlight.SetActive(true);
            StartCoroutine(Wait());
        }

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        if (tutorialDash.activeSelf) tutorialDash.SetActive(false);
        if (tutorialArmyChange.activeSelf) tutorialArmyChange.SetActive(false);
        if (tutorialFlashlight.activeSelf) tutorialFlashlight.SetActive(false);
    }
}
