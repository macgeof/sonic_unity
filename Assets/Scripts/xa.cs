using UnityEngine;
using System.Collections;

public class xa : MonoBehaviour 
{
	
	public static Player1 player1;
	
	public static bool gameOver = false;
	
	// set to false if game is configured for CTF
	public static bool letsPlayKeepaway = true; 
	
	// layers
	public const int Team1Goal = 9;
	public const int Team2Goal = 10;
	
	void Start()
	{
		// cache these so they can be accessed by other scripts
		player1 = GameObject.Find("Player1").GetComponent<Player1>();
	}
}
