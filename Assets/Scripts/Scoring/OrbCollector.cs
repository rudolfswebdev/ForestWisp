using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbCollector : MonoBehaviour
{
    public GameObject[] orbs;
    public Sprite orbSlotImage;
    public Sprite orbImage;
    public GameObject panel;
    public static OrbCollector instance;
    public GameObject wispsRequiredText;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        wispsRequiredText.SetActive(false);

        foreach (GameObject orb in orbs)
        {
            orb.GetComponentInChildren<Image>().sprite = orbSlotImage;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (panel.activeSelf)
            {
                panel.SetActive(false) ;
            }
            else
            {
                panel.SetActive(true) ;
            }
        }
    }

    public void AddWisp()
    {
        for(int i = 0; i < orbs.Length; i++)
        {
            if(orbs[i].GetComponentInChildren<Image>().sprite == orbSlotImage)
            {
                orbs[i].GetComponentInChildren<Image>().sprite = orbImage;
                return;
            }
        }
    }
    public void RemoveWisp()
    {
        for (int i = orbs.Length-1; i > -1; i--)
        {
            if (orbs[i].GetComponentInChildren<Image>().sprite == orbImage)
            {
                orbs[i].GetComponentInChildren<Image>().sprite = orbSlotImage;
                return;
            }
        }
    }

    public void DisplayWispsRequired()
    {
        if (!wispsRequiredText.activeSelf)
        {
            wispsRequiredText.SetActive(true);
            StartCoroutine(WispsRequired());
        }
    }

    public IEnumerator WispsRequired()
    {
        yield return new WaitForSeconds(2);
        wispsRequiredText.SetActive(false);

    }


}
