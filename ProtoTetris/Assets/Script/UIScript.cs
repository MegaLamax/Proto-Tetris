using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;


public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;


    void Update()
    {

        ScoreText.text = "" + GameManager.Score;

    }

}
