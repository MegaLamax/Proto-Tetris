using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LogicTetrominos : MonoBehaviour
{
    private float PastTime;
    public float FallingTime = 0.8f; //Velocidad de la caida

    //Aca se declara el tamaño de la zona donde estaran lo tetronimos
    public static int High = 30;
    public static int Width = 10;

    public static int Score = 0;
   
    public static int DifficultyLevel = 0;

    public Vector3 PointRotation;//punto de rotacion de las piezas

    private static Transform[,] grid = new Transform[Width, High]; //Array de la zona para los tetronimos

    void Start()
    {

    }

    void Update()
    {
        //aca configuramos el imput de Izquierda y derecha, y ademas determinamos los limites para las piezas
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0);

            if (!Limits())
            {
                transform.position -= new Vector3(-1, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0);

            if (!Limits())
            {
                transform.position -= new Vector3(1, 0);
            }
        }
        //Este es el Input para que cuando apretamos la flecha de abajo la pieza caiga mas rapido
        if (Time.time - PastTime > (Input.GetKey(KeyCode.DownArrow) ? FallingTime/20: FallingTime))
        {
            transform.position += new Vector3(0, -1);

            if (!Limits())
            {
                transform.position -= new Vector3(0, -1);

                AddGrid();
                CheckLine();

                this.enabled = false;

                FindObjectOfType<SpawnerLogic>().NewTetromino();
            }

            PastTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(PointRotation),new Vector3 (0, 0,1), -90);
            if (!Limits())
            {
                transform.RotateAround(transform.TransformPoint(PointRotation), new Vector3(0, 0, 1), 90);
            }
        }

        IncreaseLevel();
        IncreaseDifficulty();
        

    }

    //Aca seteamos los limites para que las piezas no se salgan de la zona de juego
    bool Limits()
    {
        foreach(Transform Son in transform)
        {
            int IntegralX = Mathf.RoundToInt(Son.transform.position.x);
            int IntegralY = Mathf.RoundToInt(Son.transform.position.y);

            if(IntegralX < 0 || IntegralX >= Width || IntegralY < 0 || IntegralY >= High)
            {
                return false;
            }
            if (grid[IntegralX, IntegralY]!= null)
            {
                return false;
            }
        }

        return true;
    }

    void AddGrid()
    {
        foreach (Transform Son in transform)
        {
            int IntegralX = Mathf.RoundToInt(Son.transform.position.x);
            int IntegralY = Mathf.RoundToInt(Son.transform.position.y);

            grid[IntegralX, IntegralY] = Son;

            if (IntegralY>=19)
            {
                Score = 0;
                DifficultyLevel = 0;
                FallingTime = 0.8f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void CheckLine()
    {
        for(int a = High -1; a >= 0; a--)
        {
            if (Line(a))
            {
                DeletLine(a);
                LineDown(a);
                
            }
        }
    }

    bool Line(int a)
    {
        for (int t = 0; t < Width; t++)
        {
            if (grid[t,a] == null)
            {
                return false;
            }
        }
        UpdateScore();

        Debug.Log(Score);

        Debug.Log("Hay linea");

        return true;
    }

    void DeletLine(int a)
    {
        for (int t = 0; t < Width; t++)
        {
            Destroy(grid[t,a].gameObject);
            grid[t,a] = null;
        }
        Debug.Log("Borrando linea");
    }

    void LineDown(int a)
    {
        for (int p = a; p < High; p++)
        {
            for (int t = 0; t < Width; t++)
            {
                if (grid[t,p] != null)
                {
                    grid[t, p -1] = grid[t,p];
                    grid[t, p] = null;
                    grid[t, p -1].transform.position -= new Vector3(0, 1);
                }
            }
        }
        Debug.Log("Bajando linea");
    }


    void IncreaseLevel()
    {
        switch(Score)
        {
            case 1000:
                DifficultyLevel = 1;
                Debug.Log("La dificultad aumento a Nivel 1");
                break;
            case 2000:
                DifficultyLevel = 2;
                Debug.Log("La dificultad aumento a Nivel 2");
                break;
            case 3000:
                DifficultyLevel = 3;
                Debug.Log("La dificultad aumento a Nivel 3");
                break;
            case 3500:
                DifficultyLevel = 4;
                Debug.Log("La dificultad aumento a Nivel 3");
                break;
            case 4000:
                DifficultyLevel = 5;
                Debug.Log("La dificultad aumento a Nivel 3");
                break;
            case 4500:
                DifficultyLevel = 6;
                Debug.Log("La dificultad aumento a Nivel 3");
                break;
            case 5000:
                DifficultyLevel = 7;
                Debug.Log("La dificultad aumento a Nivel 3");
                break;
        }
    }

    void IncreaseDifficulty()
    {
        switch(DifficultyLevel)
        {
            case 1:
                FallingTime = 0.7f;
                break;
            case 2:
                FallingTime = 0.6f;
                break;
            case 3:
                FallingTime = 0.5f;
                break;
            case 4:
                FallingTime = 0.4f;
                break;
            case 5:
                FallingTime = 0.3f;
                break;
            case 6:
                FallingTime = 0.2f;
                break;
            case 7:
                FallingTime = 0.1f;
                break;
        }
    }

    public void UpdateScore()
    {
        Score += 100;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(PointRotation,0.1f);
    }


}
