using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour 
{

	public CapsuleCollider2D myCollider;
	public Vector2 initialSize;
	public float stepDuration;
	public float waveDuration;
	public float sizeMultiplierPerStep;
	public float waveForce;

	public Animator myAnim, mySplashAnim;

	private Coroutine waveRoutine;
	private WaitForSeconds stepWait;

	public AudioSource splishSound, splashSound;
	public SpriteRenderer splashRenderer;

	private List<Transform> boatsHit;

	private void Awake()
	{
		boatsHit = new List<Transform> ();
		stepWait = new WaitForSeconds (stepDuration);
	}

	private void OnEnable()
	{

		splashRenderer.flipX = (Random.Range (0, 2) == 1);
			
		mySplashAnim.SetTrigger ("Play");
		myAnim.SetTrigger ("Play");

		if (Random.Range (0, 2) == 1)
		{
			splishSound.pitch = Random.Range (1.2f, 1.5f);
			splishSound.Play ();
		} 
		else
		{
			splashSound.pitch = Random.Range (1.2f, 1.5f);
			splashSound.Play ();
		}

		boatsHit.Clear ();
		myCollider.size = initialSize;
		if (waveRoutine != null)
		{
			StopCoroutine (waveRoutine);
		}
		waveRoutine = StartCoroutine (DoWaveyStuff ());
	}

	private IEnumerator DoWaveyStuff()
	{
		float time = 0;
		while (time < waveDuration)
		{
			time += stepDuration;
			myCollider.size *= sizeMultiplierPerStep;
			yield return stepWait;
		}

		waveRoutine = null;
		gameObject.SetActive (false);
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		//Debug.Log ("TRIGGERED");

		if (coll.CompareTag("Boat") || coll.CompareTag("Cone"))
		{
			if (boatsHit.Count > 0 && boatsHit.Contains(coll.transform))
			{
				//print ("DOUBLE TAP");
				return;
			}

			boatsHit.Add (coll.transform);

			Vector2 heading = coll.transform.position - transform.position;
			float distance = heading.magnitude;
			Vector2 direction = heading / distance; // This is now the normalized direction.

			Vector2 force = direction * (waveForce / distance);
			//print ("Pushed at force of: " + force.magnitude + " and distance of " + distance);

			coll.attachedRigidbody.AddForce (force);
		}
	}


}
