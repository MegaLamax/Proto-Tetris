using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    void Start()
    {
        
    }

    
    void Update()
    {
        ScoreText.text = "Score: " + GameManager.Score;
    }
}
