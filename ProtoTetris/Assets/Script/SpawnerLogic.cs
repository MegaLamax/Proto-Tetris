using System.Collections.Generic;
using UnityEngine;

public class SpawnerLogic : MonoBehaviour
{
    

    public GameObject[] Tetrominos;

    private List<int> Bag;

    void Start()
    {
        
        Bag = new List<int>();

        NewTetromino();

    }

    public void NewTetromino()
    {
        int LastIndex = -1;

        int RandomIndex;
        do
        {
            RandomIndex = Random.Range(0, Tetrominos.Length);

        } while (Bag.Contains(RandomIndex) || RandomIndex == LastIndex);

        GameObject RandomTetronimo = Tetrominos[RandomIndex];
        Instantiate(RandomTetronimo,transform.position,Quaternion.identity);
        Bag.Add(RandomIndex);

        
        if (Bag.Count == Tetrominos.Length)
        {
            Debug.Log("Bolsa llena, se vacia.");

            Bag.Clear(); 
        }
    }
}  

