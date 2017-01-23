using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TouchWaves : MonoBehaviour, IPointerClickHandler
{
	public float waveCooldown;
	public GameObject wavePrefab;
	public int numberOfWavesInPoolHahaGetIt;

	private bool waveActive;
	private WaitForSeconds waveWait;
	private GameObject[] poolOfWaves;
	private int currentWave = 0;

	private void Awake()
	{
		waveWait = new WaitForSeconds (waveCooldown);

		poolOfWaves = new GameObject[numberOfWavesInPoolHahaGetIt];
		for (int i = 0; i < numberOfWavesInPoolHahaGetIt; i++)
		{
			poolOfWaves [i] = Instantiate (wavePrefab);
			poolOfWaves [i].SetActive (false);
		}
	}

	public void OnPointerClick(PointerEventData data)
	{
		if (currentWave >= numberOfWavesInPoolHahaGetIt - 1)
		{
			currentWave = 0;
		} 
		else
		{
			currentWave++;
		}

		if (!waveActive) //and maybe a distance related condition as well
		{
			StartCoroutine (MakeWave (poolOfWaves[currentWave], Camera.main.ScreenToWorldPoint(data.position)));
		}
	}

	private IEnumerator MakeWave(GameObject wave, Vector2 wavePosition)
	{
		waveActive = true;

		//print ("doing wavey stuff at " + wavePosition);
		wave.transform.position = wavePosition;
		wave.SetActive (false);
		wave.SetActive (true);

		yield return waveWait;
		waveActive = false;

	}

	public void BackToMenu()
	{
		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}
}
