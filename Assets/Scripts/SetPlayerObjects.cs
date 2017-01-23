using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerObjects : MonoBehaviour 
{

	private int playerObjectsNumber;
	public GameObject[] playerObjects;

	private void Awake()
	{
		playerObjectsNumber = (int)StaticData.currentGameType;
		//print (playerObjectsNumber);

		for (int i = 0; i < playerObjectsNumber; i++)
		{
			playerObjects [i].SetActive (true);
		}
	}

}
