﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public float turnDelay = .1f;
	public static GameManager instance = null;   
	private BoardManager boardScript;
	public int playerFoodPoints = 100;
	[HideInInspector] public bool playersTurn = true;

	private int level = 3;
	private List<Enemy> enemies;
	private bool enemiesMoving;

	// Use this for initialization
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
		Destroy(gameObject);    
		enemies = new List<Enemy>();
		DontDestroyOnLoad(gameObject);
		boardScript = GetComponent<BoardManager>();
		InitGame();
	}
	void InitGame()
	{
		enemies.Clear ();
		boardScript.SetupScene(level);
	}

	public void GameOver()
	{
		enabled = false;
	}
		
	void Update()
	{
		if (playersTurn || enemiesMoving)
			return;

		StartCoroutine (MoveEnemies ());
	}

	public void AddEnemyToList(Enemy Script)
	{
		enemies.Add (script);
	}
		
	IEnumerator MoveEnemies()
	{
		enemiesMoving = true;
		yield return new WaitForSeconds (turnDelay);
		if (enemies.Count == 0)
	{
		yield return new WaitForSeconds(turnDelay);
	}

		for (int i = 0; i < enemies.Count; i++) {
			enemies [i].MoveEnemy ();
		}
		yield return new WaitForSeconds(enemies[i].moveTime); 
	}
		playersTurn = true;
		enemiesMoving = false;
}