using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAnimation : MonoBehaviour 
{

	public Animator[] animators;

	public string[] animationTriggers;

	public GameObject[] goalObjects;

	private enum goalState
	{
		left,
		right,
		center
	}

	private goalState currentGoalState = goalState.left;

	public void DoTheThing()
	{
		StartCoroutine (MoveGoalposts ());
	}

	//note: this was a triumph
	private IEnumerator MoveGoalposts()
	{
		int stupidVarName = 0;

		for (int i = 0; i < goalObjects.Length; i++)
		{
			goalObjects [i].SetActive (false);
		}

		/*nintendo*/switch (currentGoalState)
		{
		case goalState.left:
			currentGoalState = goalState.right;
			PlayAnimations (animationTriggers[0]);
			stupidVarName = 1;
			break;
		case goalState.right:
			currentGoalState = goalState.center;
			PlayAnimations (animationTriggers[1]);
			stupidVarName = 2;
			break;
		case goalState.center:
			currentGoalState = goalState.left;
			PlayAnimations (animationTriggers[2]);
			stupidVarName = 0;
			break;
		}

		yield return new WaitForSeconds (1.5f);

		goalObjects [stupidVarName].SetActive (true);
	}

	private void PlayAnimations(string trigger)
	{
		for (int i = 0; i < animators.Length; i++)
		{
			animators [i].SetTrigger (trigger);
		}
	}
}
