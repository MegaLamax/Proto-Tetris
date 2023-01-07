using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLogic : MonoBehaviour
{
    public GameObject[] Tetrominos;

    void Start()
    {
        NewTetromino();
    }

    void Update()
    {
       
    }
    public void NewTetromino()
    {
        //Debug.Break();
        Instantiate(Tetrominos[Random.Range(0, Tetrominos.Length)], transform.position, Quaternion.identity);

    }

}  

