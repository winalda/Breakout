using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	private int level = 0;

	public Text livesText;
	public Text LevelText;

	public GameObject gameOver;
	public GameObject youWon;
	public GameObject paddle;


	public static GM instance = null;

	public GameObject clonePaddle;

	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);
	
		Setup ();
	}

	public void Setup()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
		/*Cuando Instantiate puede cambiar un poco los valores por lo que regresa Transform
		  Pero hay que tomar en cuenta que el Instatiate se muestra de la siguiente manera 
		  Instantiate(GameObjectab,Position,Rotation) Podemos recuperar el valor de la potition de 0,0,0 con 
		  transform.position y la rotacion del valor 0,0,0 con Quaternion.identity*/
		
		//Instantiate (bricksPrefab, new Vector3(1.6f,-2,-1), Quaternion.identity);
		Application.LoadLevelAdditive("Level1");
		LevelText.text = "Level = " + (level + 1); 
	}

	void CheckGameOver()
	{
		Debug.Log ("Bricks = " + bricks);
		if (bricks < 1) {

			clonePaddle.GetComponent<Paddle>().ball.transform.position = new Vector3(0,-3,0);
			clonePaddle.GetComponent<Paddle> ().ball.SetActive (false);
			DestroyObject (clonePaddle);
			Invoke ("SetupPaddle", resetDelay);
			bricks = 20;

			if (level == 1) {
				Application.LoadLevelAdditive ("Level2");
				lives++;
				level++;
			} else if(level == 2){
				Application.LoadLevelAdditive ("Level3");
				lives++;
				level++;
		    }else{
				youWon.SetActive (true);
				Time.timeScale = .25f;
				Invoke ("Reset", resetDelay);
			}

			LevelText.text = "Level = " + (level + 1);
			livesText.text = "Lives = " + lives;
		}

		if (lives < 1) {
			gameOver.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
	}

	void Reset()
	{
		Time.timeScale = 1f;
		//Que hace SceneManager.LoadScena
		SceneManager.LoadScene (Application.loadedLevel);
	} 

	public void LoseLife(){
		lives--;
		livesText.text = "Lives = " + lives;

		Destroy (clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver ();
	}

	void SetupPaddle()
	{
		clonePaddle = Instantiate (paddle, transform.position,Quaternion.identity) as GameObject;
	}

	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver ();
	}
}
