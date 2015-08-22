using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyArmy : MonoBehaviour {

	[SerializeField]
	public int  number = 250;

	[SerializeField]
	public List<GameObject> soldierList;

	public List<SoldierController> soldierComponentList;

	[SerializeField]
	public GameObject prefab;

	void Start () {
		Spawn ();
	}
	
	void Spawn() {
		
		for (int i = 0; i < number; i++) {
			float num = Random.Range(0, 125);
			Vector3 pos = RandomCircle(this.transform.localPosition, num);
			soldierList.Add(Instantiate(prefab, pos, this.transform.localRotation) as GameObject);
		}
		foreach(GameObject obj in soldierList)
		{
			SoldierController s = obj.GetComponent<SoldierController>();
			soldierComponentList.Add(s);
		}
	}
	
	Vector3 RandomCircle ( Vector3 center ,   float radius  ){
		float ang = Random.value * 360;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.y = center.y;
		pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		return pos;
	}
}
