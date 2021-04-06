using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text gameOver;
    public Button restart;
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.enabled = false;
        restart.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            Destroy(GameObject.Find("Player"));
            gameOver.enabled = true;
            restart.gameObject.SetActive(true);
        }
    }

    public void restartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
