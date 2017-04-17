using UnityEngine;
using System.Collections;
using ws.winx.unity.statemachine;


namespace ws.winx.survivorai{
	public class PatrolState :ws.winx.statemachine.StateMachineBehaviour// IEnemyState 
{
	public StatePatternEnemy enemy;

	//[StatePropertyDrawer()]
	//public State state;
	//private readonly StatePatternEnemy enemy;
	private int nextWayPoint;
	
//	public PatrolState (StatePatternEnemy statePatternEnemy)
//	{
//		enemy = statePatternEnemy;
//	}
	
//	public void UpdateState()
//	{
//		Look ();
//		Patrol ();
//	}
	public void Update()
	{
		if(!Look ())
		Patrol ();
	}
	
	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
			ToAlertState ();
	}
//	
//	public void ToPatrolState()
//	{
//		Debug.Log ("Can't transition to same state");
//	}
	
	public void ToAlertState()
	{
		//enemy.currentState = enemy.alertState;

		EventDispatcher.Instance.PatrolToAlertConditionEvent.Invoke (this.gameObject);
		//this.enabled = false;
	}
	
	public void ToChaseState()
	{
		//enemy.currentState = enemy.chaseState;

		EventDispatcher.Instance.PatrolToChaseConditionEvent.Invoke (this.gameObject);
		//this.enabled = false;
	}



	
//	private void Look()
//	{
//		RaycastHit hit;
//		if (Physics.Raycast (enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag ("Player")) {
//			enemy.chaseTarget = hit.transform;
//			ToChaseState();
//		}
//	}


	private bool Look()
	{
		RaycastHit hit;
		if (Physics.Raycast (enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag ("Player")) {
			enemy.chaseTarget = hit.transform;
			ToChaseState();
			return true;
		}

		return false;
	}
	
	void Patrol ()
	{
		enemy.meshRendererFlag.material.color = Color.green;
		enemy.navMeshAgent.destination = enemy.wayPoints [nextWayPoint].position;
		enemy.navMeshAgent.Resume ();
		
		if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending) {
			nextWayPoint =(nextWayPoint + 1) % enemy.wayPoints.Length;
			
		}
		
		
	}
}
}