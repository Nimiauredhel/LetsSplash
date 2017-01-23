using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour 
{
	public GameObject credits;

	public void StartGame(int gameType)
	{
		StaticData.currentGameType = (StaticData.gameType)gameType;
		SceneManager.LoadScene (1, LoadSceneMode.Single);
	}

	public void ToggleCredits(bool active)
	{
		credits.SetActive (active);
	}
}
