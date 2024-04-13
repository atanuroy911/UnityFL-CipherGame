using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCaesarWord : MonoBehaviour
{
    public GameObject Word1;
    public GameObject Word2;
    public GameObject Word3;
    public GameObject Word4;

    // Start is called before the first frame update
    void Start()
    {
        Word1.GetComponent<CaesarEncoding>().TextActive = false;
        Word2.GetComponent<CaesarEncoding>().TextActive = false;
        Word3.GetComponent<CaesarEncoding>().TextActive = false;
        Word4.GetComponent<CaesarEncoding>().TextActive = false;
    }

    //Button is clicked to select word
    public void ClickWord1()
    {
        Word1.GetComponent<CaesarEncoding>().TextActive = true;
        Word2.GetComponent<CaesarEncoding>().TextActive = false;
        Word3.GetComponent<CaesarEncoding>().TextActive = false;
        Word4.GetComponent<CaesarEncoding>().TextActive = false;
    }

    //Button is clicked to select word
    public void ClickWord2()
    {
        Word1.GetComponent<CaesarEncoding>().TextActive = false;
        Word2.GetComponent<CaesarEncoding>().TextActive = true;
        Word3.GetComponent<CaesarEncoding>().TextActive = false;
        Word4.GetComponent<CaesarEncoding>().TextActive = false;
    }

    //Button is clicked to select word
    public void ClickWord3()
    {
        Word1.GetComponent<CaesarEncoding>().TextActive = false;
        Word2.GetComponent<CaesarEncoding>().TextActive = false;
        Word3.GetComponent<CaesarEncoding>().TextActive = true;
        Word4.GetComponent<CaesarEncoding>().TextActive = false;
    }

    //Button is clicked to select word
    public void ClickWord4()
    {
        Word1.GetComponent<CaesarEncoding>().TextActive = false;
        Word2.GetComponent<CaesarEncoding>().TextActive = false;
        Word3.GetComponent<CaesarEncoding>().TextActive = false;
        Word4.GetComponent<CaesarEncoding>().TextActive = true;
    }
}
