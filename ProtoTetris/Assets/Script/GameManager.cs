using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Score;

    public static int LineScore;

    public static int DifficultyLevel = 0;

    public static float FallingTime = 0.8f;


    public static void UpdateScore()
    {
        Score += 1000;
    }

    public static void UpdateLine() 
    { 
     
        LineScore += 1;
     
    }

    

    public static void IncreaseLevel()
    {
        switch (LineScore)
        {
            case 10:
                DifficultyLevel = 1;
                Debug.Log("La dificultad aumento a Nivel 1");
                break;
            case 20:
                DifficultyLevel = 2;
                Debug.Log("La dificultad aumento a Nivel 2");
                break;
            case 30:
                DifficultyLevel = 3;
                Debug.Log("La dificultad aumento a Nivel 3");
                break;
            case 40:
                DifficultyLevel = 4;
                Debug.Log("La dificultad aumento a Nivel 4");
                break;
            case 50:
                DifficultyLevel = 5;
                Debug.Log("La dificultad aumento a Nivel 5");
                break;
            case 60:
                DifficultyLevel = 6;
                Debug.Log("La dificultad aumento a Nivel 6");
                break;
            case 70:
                DifficultyLevel = 7;
                Debug.Log("La dificultad aumento a Nivel 7");
                break;
            case 80:
                DifficultyLevel = 8;
                Debug.Log("La dificultad aumento a Nivel 8");
                break;
            case 90:
                DifficultyLevel = 9;
                Debug.Log("La dificultad aumento a Nivel 9");
                break;
            case 100:
                DifficultyLevel = 10;
                Debug.Log("La dificultad aumento a Nivel 10");
                break;
            case 110:
                DifficultyLevel = 11;
                Debug.Log("La dificultad aumento a Nivel 11");
                break;
            case 120:
                DifficultyLevel = 12;
                Debug.Log("La dificultad aumento a Nivel 12");
                break;
            case 130:
                DifficultyLevel = 13;
                Debug.Log("La dificultad aumento a Nivel 13");
                break;
            case 140:
                DifficultyLevel = 14;
                Debug.Log("La dificultad aumento a Nivel 14");
                break;
            case 150:
                DifficultyLevel = 15;
                Debug.Log("La dificultad aumento a Nivel 15");
                break;
            case 160:
                DifficultyLevel = 16;
                Debug.Log("La dificultad aumento a Nivel 16");
                break;
            case 170:
                DifficultyLevel = 17;
                Debug.Log("La dificultad aumento a Nivel 17");
                break;
            case 180:
                DifficultyLevel = 18;
                Debug.Log("La dificultad aumento a Nivel 18");
                break;
            case 190:
                DifficultyLevel = 19;
                Debug.Log("La dificultad aumento a Nivel 19");
                break;
            case 200:
                DifficultyLevel = 20;
                Debug.Log("La dificultad aumento a Nivel 20");
                break;
            case 210:
                DifficultyLevel = 21;
                Debug.Log("La dificultad aumento a Nivel 21");
                break;
            case 220:
                DifficultyLevel = 22;
                Debug.Log("La dificultad aumento a Nivel 22");
                break;
            case 230:
                DifficultyLevel = 23;
                Debug.Log("La dificultad aumento a Nivel 23");
                break;
            case 240:
                DifficultyLevel = 24;
                Debug.Log("La dificultad aumento a Nivel 24");
                break;
            case 250:
                DifficultyLevel = 25;
                Debug.Log("La dificultad aumento a Nivel 25");
                break;
            case 260:
                DifficultyLevel = 26;
                Debug.Log("La dificultad aumento a Nivel 26");
                break;
            case 270:
                DifficultyLevel = 27;
                Debug.Log("La dificultad aumento a Nivel 27");
                break;
            case 280:
                DifficultyLevel = 28;
                Debug.Log("La dificultad aumento a Nivel 28");
                break;
            case 290:
                DifficultyLevel = 29;
                Debug.Log("La dificultad aumento a Nivel 29");
                break;
        }
    }

    public static void IncreaseDifficulty()
    {
        switch (DifficultyLevel)
        {
            case 1:
                FallingTime = 0.8f;
                break;
            case 2:
                FallingTime = 0.8f;
                break;
            case 3:
                FallingTime = 0.8f;
                break;
            case 4:
                FallingTime = 0.8f;
                break;
            case 5:
                FallingTime = 0.8f;
                break;
            case 6:
                FallingTime = 0.7f;
                break;
            case 7:
                FallingTime = 0.6f;
                break;
            case 8:
                FallingTime = 0.5f;
                break;
            case 9:
                FallingTime = 0.4f;
                break;
            case 10:
                FallingTime = 0.4f;
                break;
            case 13:
                FallingTime = 0.3f;
                break;
            case 16:
                FallingTime = 0.3f;
                break;
            case 19:
                FallingTime = 0.3f;
                break;
            case 29:
                FallingTime = 0.2f;
                break;
        }
    }
}
