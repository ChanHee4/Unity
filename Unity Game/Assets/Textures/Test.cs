using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private List<GameObject> Images = new List<GameObject>();
    private List<GameObject> Buttons = new List<GameObject>();
    private List<Image> ButtonImages = new List<Image>();
    private float cooldown;

    private void Start()
    {
        GameObject SkillsObj = GameObject.Find("Skills");

        for (int i = 0; i < SkillsObj.transform.childCount; ++i)
            Images.Add(SkillsObj.transform.GetChild(i).gameObject);

        for (int i = 0; i < 1; ++i)
            Buttons.Add(Images[i].transform.GetChild(0).gameObject);

        for (int i = 0; i < Buttons.Count; ++i)
            ButtonImages.Add(Buttons[i].GetComponent<Image>());

        cooldown = 0.0f;
    }


    public void PushButton1()
    {
        ButtonImages[0].fillAmount = 0;
        Buttons[0].GetComponent<Button>().enabled = false;

        StartCoroutine(PushButton1_Coroutine());
    }

    IEnumerator PushButton1_Coroutine()
    {
        float cool = cooldown;

        while (ButtonImages[0].fillAmount != 1)
        {
            ButtonImages[0].fillAmount += Time.deltaTime * cool;
            yield return null;
        }

        Buttons[0].GetComponent<Button>().enabled = true;
    }

    public void Testcase1()
    {
        cooldown = 0.5f;
        ControllerManager.GetInstance().BulletSpeed += 0.025f;
    }


    public void PushButton2()
    {
        ButtonImages[1].fillAmount = 0;
        Buttons[1].GetComponent<Button>().enabled = false;

        StartCoroutine(PushButton2_Coroutine());
    }

    IEnumerator PushButton2_Coroutine()
    {
        float cool = cooldown;

        while (ButtonImages[1].fillAmount != 1)
        {
            ButtonImages[1].fillAmount += Time.deltaTime * cool;
            yield return null;
        }

        Buttons[1].GetComponent<Button>().enabled = true;
    }

    public void Testcase2()
    {
        cooldown = 0.5f;
        ControllerManager.GetInstance().BulletSpeed += 0.025f;
    }


    public void PushButton3()
    {
        ButtonImages[2].fillAmount = 0;
        Buttons[2].GetComponent<Button>().enabled = false;

        StartCoroutine(PushButton3_Coroutine());
    }

    IEnumerator PushButton3_Coroutine()
    {
        float cool = cooldown;

        while (ButtonImages[2].fillAmount != 1)
        {
            ButtonImages[2].fillAmount += Time.deltaTime * cool;
            yield return null;
        }

        Buttons[2].GetComponent<Button>().enabled = true;
    }

    public void Testcase3()
    {
        cooldown = 0.5f;
        ControllerManager.GetInstance().BulletSpeed += 0.025f;
    }

    public void PushButton4()
    {
        ButtonImages[3].fillAmount = 0;
        Buttons[3].GetComponent<Button>().enabled = false;

        StartCoroutine(PushButton4_Coroutine());
    }

    IEnumerator PushButton4_Coroutine()
    {
        float cool = cooldown;

        while (ButtonImages[3].fillAmount != 1)
        {
            ButtonImages[3].fillAmount += Time.deltaTime * cool;
            yield return null;
        }

        Buttons[3].GetComponent<Button>().enabled = true;
    }

    public void Testcase4()
    {
        cooldown = 0.5f;
        ControllerManager.GetInstance().BulletSpeed += 0.025f;
    }

    public void PushButton5()
    {
        ButtonImages[4].fillAmount = 0;
        Buttons[4].GetComponent<Button>().enabled = false;

        StartCoroutine(PushButton5_Coroutine());
    }

    IEnumerator PushButton5_Coroutine()
    {
        float cool = cooldown;

        while (ButtonImages[4].fillAmount != 1)
        {
            ButtonImages[4].fillAmount += Time.deltaTime * cool;
            yield return null;
        }

        Buttons[4].GetComponent<Button>().enabled = true;
    }

    public void Testcase5()
    {
        cooldown = 0.5f;
        ControllerManager.GetInstance().BulletSpeed += 0.025f;
    }
}