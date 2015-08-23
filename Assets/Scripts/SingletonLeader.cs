using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingletonLeader : MonoBehaviour {

	public List<GameObject> leaderPlayerList;

	public List<GameObject> leaderArmyENemyList;

	private static SingletonLeader instance;

	public static SingletonLeader Instance()
	{

		if (instance == null)
		{
			instance = new SingletonLeader();
		}

		return instance;

	}

	public Transform getNearestLeader(List<GameObject> listToEvaluate, Transform  myself)
	{
		Transform pos = null;
		float magnitude = 0;
		for (int i = 0; i < listToEvaluate.Count; i++) {
			if((myself.position - listToEvaluate[i].transform.position).magnitude < magnitude)
			{
				magnitude = (myself.position - listToEvaluate[i].transform.position).magnitude;
				pos = listToEvaluate[i].transform;
			}
		}
		if(pos != null)
		{
			return pos;
		}

		return null;
	}

	public Vector3 getBarcenterLeader(List<GameObject> listToEvaluate)
	{
		Vector3 pos = new Vector3(0,0,0);

		for (int i = 0; i < listToEvaluate.Count; i++) {
			pos += listToEvaluate[i].transform.position;
		}

		pos = pos / listToEvaluate.Count;

		return pos;
	}

	public Transform getRandomLeader(List<GameObject> listToEvaluate)
	{
		return null;
	}

	public Transform getLowestNumberSquad()
	{
		return null;
	}

}
