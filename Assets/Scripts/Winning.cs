using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winning : MonoBehaviour 
{

	public RectTransform winnerPanel;
	private int[] winnerInts;
	public string[] winnerNames;
	public GameObject winMessagePrefab;
	public GameObject[] winnerNameSprites;
	public GameObject wonSprite, alsoSprite, againSprite, andSprite, excSprite, coneWonSprite;
	public GoalAnimation goalAnimationThing;

	private bool active = false;

	public AudioSource[] winnerNameClips;
	public AudioSource wonClip, alsoClip, againClip, andClip, excClip, coneWonClip;

	private void Awake()
	{
		winnerInts = new int[] { 0, 0, 0 };
		active = true;
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (!active)
			return;

		if (coll.CompareTag ("Boat"))
		{
			StartCoroutine (Win (coll.gameObject));
		}
		if (coll.CompareTag ("Cone"))
		{
			ConeWin ();
		}
	}

	private IEnumerator Win(GameObject winnerGo)
	{
		active = false;
		goalAnimationThing.DoTheThing ();

		for (int i = 0; i < winnerNames.Length; i++)
		{
			if (winnerGo.name == winnerNames [i])
			{
				GameObject go = Instantiate (winMessagePrefab);
				go.transform.SetParent (winnerPanel, false);

				Instantiate (winnerNameSprites[i]).transform.SetParent (go.transform, false);
				winnerNameClips [i].pitch = Random.Range (0.9f, 1.1f);
				winnerNameClips [i].Play ();

				yield return new WaitForSeconds (0.7f);
				if (othersWon (i))
				{
					Instantiate (alsoSprite).transform.SetParent (go.transform, false);
					alsoClip.pitch = Random.Range (0.9f, 1.1f);
					alsoClip.Play ();
					yield return new WaitForSeconds (0.7f);
				}
					
				Instantiate (wonSprite).transform.SetParent (go.transform, false);
				wonClip.pitch = Random.Range (0.9f, 1.1f);
				wonClip.Play ();
				yield return new WaitForSeconds (0.7f);
				if (winnerInts [i] > 0)
				{
					Instantiate (againSprite).transform.SetParent (go.transform, false);
					againClip.pitch = Random.Range (0.9f, 1.1f);
					againClip.Play ();
					yield return new WaitForSeconds (1.2f);

					for (int j = 1; j < winnerInts[i]; j++)
					{
						Instantiate (andSprite).transform.SetParent (go.transform, false);
						andClip.pitch = Random.Range (0.9f, 1.1f);
						andClip.Play ();
						yield return new WaitForSeconds (0.7f);

						Instantiate (againSprite).transform.SetParent (go.transform, false);
						againClip.pitch = Random.Range (0.9f, 1.1f);
						againClip.Play ();
						yield return new WaitForSeconds (0.7f);
					}
				}

				Instantiate (excSprite).transform.SetParent (go.transform, false);
				excClip.pitch = Random.Range (0.9f, 1.1f);
				excClip.Play ();
				yield return new WaitForSeconds (0.7f);

				winnerInts [i]++;

				go.GetComponent<TimedDestruction> ().Countdown ();

				break;
			}
		}

		yield return new WaitForSeconds (0.5f);
		active = true;
	}

	private void ConeWin()
	{
		GameObject go = Instantiate (winMessagePrefab);
		go.transform.SetParent (winnerPanel, false);

		Instantiate (coneWonSprite).transform.SetParent (go.transform, false);

		coneWonClip.pitch = Random.Range (0.9f, 1.1f);
		coneWonClip.Play ();

		go.GetComponent<TimedDestruction> ().Countdown ();
	}

	private bool othersWon(int winnerNum)
	{
		for (int i = 0; i < winnerInts.Length; i++)
		{
			if (i != winnerNum && winnerInts[i] > 0)
			{
				return true;
			}
		}
		return false;
	}
}

/*public class WinThingiesManager
{
	private static Winning leftGoal;
	private static Winning rightGoal;

	public static void RegisterGoal(Winning goal, int direction)
	{
		if (direction < 0)
		{
			leftGoal = goal;
		} 
		else
		{
			rightGoal = goal;
		}
	}

	public static void ChangeGoal(int direction)
	{
		if (direction < 0)
		{
			if (leftGoal)
				leftGoal.SetActiveGoal (true);
			if (rightGoal)
				rightGoal.SetActiveGoal (false);
		} 
		else
		{
			if (leftGoal)
				leftGoal.SetActiveGoal (false);
			if (rightGoal)
				rightGoal.SetActiveGoal (true);
		}
	}
}*/
