using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject ERI;
    [SerializeField] private GameObject BLOCKS;

    [SerializeField] private GameObject BottonPlay;
    [SerializeField] private GameObject BottonOptions;

    private void Start()
    {
      // LeanTween.
    }

    public void Play()
    {

        StartCoroutine(PlayWhithDelay());
                
    }

    IEnumerator PlayWhithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
