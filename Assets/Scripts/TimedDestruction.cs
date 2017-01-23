using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestruction : MonoBehaviour 
{

	public float delay;

	public void Countdown()
	{
		Invoke ("Destroy", delay);
	}

	private void Destroy()
	{
		GameObject.Destroy (gameObject);
	}

}
