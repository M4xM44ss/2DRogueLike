using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;   
	private BoardManager boardScript;
	private int level = 3;
	public int playerFoodPoints = 100;
	[HideInInspector] public bool playersTurn = true;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
		Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);
		boardScript = GetComponent<BoardManager>();
		InitGame();
	}
	void InitGame()
	{
		boardScript.SetupScene(level);
	}

	public void GameOver()
	{
		enabled = false;
	}
		
	void Update()
	{
	}
}