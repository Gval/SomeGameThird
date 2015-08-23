using UnityEngine;
using System.Collections;

public class DistanceEvaluator : Condition  {

	public override bool CompareObject()
	{
		switch (whatToDoSir)
		{
			case "Fight":
				return CompareObjectFight();
					break;
			case "DeadFoes":
			return CompareObjectDeadFoes();
					break;
			case "DeadFriends":
			return	CompareObjectDeadFriends();
					break;
			case "Foes":
			return	CompareObjectFoes();
					break;
			case "Friends":
			return	CompareObjectFriends();
					break;
		default :
			return false;
				break;
		}
	}

	public override bool CompareObjectFight()
	{
		//if(soldierPawn.FindEnemyDirection)
		return false;
	}
	
	public override bool CompareObjectFriends(){
		return false;
	}
	
	public override bool CompareObjectDeadFriends(){
		return false;
	}
	
	public override bool CompareObjectDeadFoes(){
		return false;
	}
	
	public override bool CompareObjectFoes(){

		if (soldierPawn.findStrongestDirection (soldierPawn.enemyDirection) > 10) {
			Debug.Log ("Yeah");
			return true;
		}
		return false;
	}
}
