using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public int lives = 1;
	public bool gameOver;
	public GameObject gameOverPanel;
	public bool wonGame;
	public GameObject wonGamePanel;
	public int numberOfDots;
	

    void Start()
    {
        numberOfDots = GameObject.FindGameObjectsWithTag("Pacdot").Length;
    }

   
    void Update()
    {
        
    }
	public void UpdateLives(int changeInLives)
	{
		lives += changeInLives;
		if (lives <= 0)
		{
			lives = 0;
			GameOver ();
		}
	}
	public void UpdateDots()
	{
		numberOfDots--;
		if (numberOfDots <= 0)
		{
			Won();
		}
	}
	void GameOver()
	{
		gameOver = true;
		Debug.Log ("Dead");
		gameOverPanel.SetActive (true);
	}
	void Won()
	{
		wonGame = true;
		Debug.Log ("Won");
		wonGamePanel.SetActive (true);
	}
	public void PlayAgain()
	{
		SceneManager.LoadScene("SampleScene");
	}
	
	public void Quit()
	{
		SceneManager.LoadScene("Menu Scene");
		Debug.Log ("Menu Scene");
	}
}
