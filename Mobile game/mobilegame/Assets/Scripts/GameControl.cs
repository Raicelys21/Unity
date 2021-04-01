using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
	public GameObject[] asteroid;
	public Vector3 spawnValues;
	public int asteroidCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	[Header("Score")]
	public int score;
	public Text scoreText;

	[Header("Winner")]
	public GameObject winner;
	private bool winnerbool;

	[Header("GameOver")]
	public GameObject gameovertext;
	private bool gameoverbool;

	void Start()
	{
		score = 490;
		UpdateScore();
		StartCoroutine(SpawnWaves());

		winnerbool = false;
		winner.gameObject.SetActive(false);
		gameovertext.SetActive(false);
		gameoverbool = false;

		InvokeRepeating("sub", 10, 10);
	}

	void Update()
	{
		if (winnerbool == true) // Si gana pueda oprimir la pantalla y reiniciar el juego
		{
			Time.timeScale = 0;
		}

		if (gameoverbool == true) // Si pierde pueda oprimir la pantalla y reiniciar el juego
		{
			Time.timeScale = 0; 
		}
	}

	public void RestarttheGame()
	{
		SceneManager.LoadScene("SampleScene");
	}

	IEnumerator SpawnWaves() // Introducir asteroides de forma aleatoria
	{
		yield return new WaitForSeconds(startWait);
        while (true)
        {
			for (int i = 0; i < asteroidCount; i++)
			{
				GameObject ast = asteroid[Random.Range(0,asteroid.Length)];
				Vector3 spawnPosition = new Vector3(Random.Range(-7.7f, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(ast, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
			
	}
	public void AddScore(int value) // Actualizar score
    {
		score += value;
		UpdateScore();

	}
	private void sub()
	{
		score -= 5;
		UpdateScore();
	}
	void UpdateScore()
    {
		scoreText.text = "Score: " + score; //Imprimir el texto

		if (score >= 500) // Si es igual a 500 que gane
		{
			winner.SetActive(true);
			winnerbool = true;
			Time.timeScale = 0;
		}
		else if (score <= 0) //Si es igual a 0 que pierda
		{
			gameovertext.SetActive(true);
			gameoverbool = true;
			Time.timeScale = 0;
		}
	}
}
