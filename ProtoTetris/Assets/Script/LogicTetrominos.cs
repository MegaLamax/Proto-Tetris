using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LogicTetrominos : MonoBehaviour
{
    public GameManager GameManager;

    float PastTime = 0;
    float DragTime = 0;
    float ManualMove = 0.25f;
    float TimeMove = 0.1f;

    //Aca se declara el tamaño de la zona donde estaran los tetronimos.
    public static int High = 30;
    public static int Width = 10;

    public static int DifficultyLevel = 0;

    public Vector3 PointRotation;//punto de rotacion de las piezas.

    private static Transform[,] grid = new Transform[Width, High]; //Array de la zona para los tetronimos.

    void Start()
    {

    }

    void Update()
    {

        ControlTetronimo();
        //GameManager.IncreaseLevel();
        //GameManager.IncreaseDifficulty();

    }

    void ControlTetronimo()
    {    
      
        DragTime += Time.deltaTime;


        //aca configuramos el imput de Izquierda y derecha, y ademas determinamos los limites para las piezas.
        if (DragTime >= TimeMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {

                Move(-1, 0);
                DragTime = 0;

                if (!Limits())
                {

                    NotMove(-1, 0);

                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Move(1, 0);
                DragTime = 0;

                if (!Limits())
                {

                    NotMove(1, 0);

                }
            }
            
        }

        //Este es el Input para que cuando apretamos la flecha de abajo la pieza caiga mas rapido.

        if (Time.time - PastTime > (Input.GetKey(KeyCode.DownArrow) ? ManualMove / 20 : (Input.GetKey(KeyCode.Space) ? ManualMove / 20 : GameManager.FallingTime)))
        {
            transform.position += new Vector3(0, -1);

            if (!Limits())
            {
                NotMove(0, -1);

                AddGrid();
                CheckLine();

                this.enabled = false;

                //Aca le decimos al objeto llamado SpawnerLogic que genere las piezas.
                Invoke("Spawner", 0.5f);
            }

            PastTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Quaternion[] childRotations = new Quaternion[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                childRotations[i] = child.rotation;
            }

            transform.RotateAround(transform.TransformPoint(PointRotation), new Vector3(0, 0, 1), -90);

            if (!Limits())
            {
                transform.RotateAround(transform.TransformPoint(PointRotation), new Vector3(0, 0, 1), 90);
            }

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.rotation = childRotations[i];
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            Quaternion[] childRotations = new Quaternion[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                childRotations[i] = child.rotation;
            }

            transform.RotateAround(transform.TransformPoint(PointRotation), new Vector3(0, 0, 1), 90);

            if (!Limits())
            {
                transform.RotateAround(transform.TransformPoint(PointRotation), new Vector3(0, 0, 1), -90);
            }

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.rotation = childRotations[i];
            }
        }
    }

    void Move(int x, int y)
    {
        transform.position += new Vector3(x, y);
    }

    void NotMove(int a, int b)
    {
        transform.position -= new Vector3(a, b);
    }

    void Spawner()
    {
        FindObjectOfType<SpawnerLogic>().NewTetromino();
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
            if (grid[IntegralX, IntegralY] != null)
            {
                return false;
            }
        }

        return true;
    }

    public void AddGrid()
    {
        foreach (Transform Son in transform)
        {
            int IntegralX = Mathf.RoundToInt(Son.transform.position.x);
            int IntegralY = Mathf.RoundToInt(Son.transform.position.y);

            grid[IntegralX, IntegralY] = Son;

            if (IntegralY>=19) //esto indica cuando perdes.
            {
                
                DifficultyLevel = 0;
                GameManager.FallingTime = 0.8f;

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

        GameManager.UpdateScore();
        GameManager.UpdateLine();

       

        return true;
    }

    void DeletLine(int a)
    {
        for (int t = 0; t < Width; t++)
        {
            Destroy(grid[t,a].gameObject);
            grid[t,a] = null;
        }
       // Debug.Log("Borrando linea");
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
       // Debug.Log("Bajando linea");
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(PointRotation,0.1f);
    }


}
