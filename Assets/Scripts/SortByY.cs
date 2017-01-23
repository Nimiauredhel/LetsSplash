using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortByY : MonoBehaviour 
{
	private SpriteRenderer mySprite;

	private void Awake()
	{
		mySprite = GetComponent<SpriteRenderer> ();
	}

	private void Update()
	{
		mySprite.sortingOrder = (int)(-transform.position.y * 100);
	}
}
