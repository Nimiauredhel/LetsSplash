using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour 
{
	public float animationSpeedModifier;
	public float minimalAnimationSpeed;

	public float maximumVelocity;

	private Animator myAnimator;
	private Rigidbody2D myRB;

	private Vector2 lastVelocity;

	private void Awake()
	{
		myAnimator = GetComponent<Animator> ();
		myRB = GetComponent<Rigidbody2D> ();
	}

	private void Update()
	{
		myAnimator.speed = minimalAnimationSpeed + myRB.velocity.magnitude * animationSpeedModifier;

		if (myRB.velocity.magnitude > maximumVelocity)
		{
			myRB.velocity = lastVelocity;
		}
		lastVelocity = myRB.velocity;
	}
}
