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
    
    public void Start()
    {
        orbs[0].GetComponentInChildren<Image>().sprite = orbImage;
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

}
