using UnityEngine;
using System.Collections;
using ws.winx.unity.statemachine;


namespace ws.winx.survivorai{
public class GameManger : MonoBehaviour {


	public GameObject ZombiPrefab;

	void Awake(){
		
		GameObject zombi=Object.Instantiate (ZombiPrefab);
		zombi.transform.position = zombi.GetComponent<StatePatternEnemy> ().wayPoints [2].position;
		
		zombi=Object.Instantiate (ZombiPrefab);
		zombi.transform.position = zombi.GetComponent<StatePatternEnemy> ().wayPoints [1].position;
	}

	
}
}
