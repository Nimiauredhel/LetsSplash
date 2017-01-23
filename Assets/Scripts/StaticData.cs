using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData
{

	public enum gameType
	{
		solo = 1,
		duo = 2,
		trio = 3
	}

	public static gameType currentGameType = gameType.trio;

}
