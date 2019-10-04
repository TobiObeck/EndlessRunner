using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;
    public bool gameOver = false;

    public float scrollSpeed = -1.5f;

    private int score = 0;

	// Use this for initialization
	void Awake ()
    {
        if (!instance)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if( this.gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void BirdScored()
    {
        if(this.gameOver == true)
        {
            return;
        }
        else
        {
            this.score++;
            this.scoreText.text = "Score: " + this.score.ToString();
        }
    }

    public void BirdDied()
    {
        this.gameOverText.SetActive(true);
        this.gameOver = true;
    }
}
