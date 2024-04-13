using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextText : MonoBehaviour
{
    public GameObject CurrentMsg;
    public GameObject NextMsg;

    //Button is clicked to show next text
    public void ClickNext()
    {
        CurrentMsg.SetActive(false);
        NextMsg.SetActive(true);
    }
}
