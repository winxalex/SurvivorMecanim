using UnityEngine;
using System.Collections;
using ws.winx.unity.statemachine;

namespace ws.winx.survivorai{
public class AlertState:ws.winx.statemachine.StateMachineBehaviour //IEnemy
{

		//public StatesInclusion inclus;
	public StatePatternEnemy enemy;
	//private readonly StatePatternEnemy enemy;
	private float searchTimer;
	
	//	public AlertState (StatePatternEnemy statePatternEnemy)
	//	{
	//		enemy = statePatternEnemy;
	//	}
	//	
	//	public void UpdateState()
	//	{
	//		Look ();
	//		Search ();
	//	}
	
	public void Update()
	{
		if(!Look ())
		Search ();
	}
	
	//	public void OnTriggerEnter (Collider other)
	//	{
	//		
	//	}
	//	
	public void ToPatrolState()
	{
		//enemy.currentState = enemy.patrolState;
		searchTimer = 0f;
		
		EventDispatcher.Instance.AlertToPatrolConditionEvent.Invoke (this.gameObject);
		//this.enabled = false;

	}
	//	
	//	public void ToAlertState()
	//	{
	//		Debug.Log ("Can't transition to same state");
	//	}
	//	
	public void ToChaseState()
	{
		//enemy.currentState = enemy.chaseState;
		
		searchTimer = 0f;
		EventDispatcher.Instance.AlertToChaseConditionEvent.Invoke (this.gameObject);

	}

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
	
//	private void Look()
//	{
//		RaycastHit hit;
//		if (Physics.Raycast (enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag ("Player")) {
//			enemy.chaseTarget = hit.transform;
//			ToChaseState();
//
//		}
//	}
	
	private void Search()
	{
		enemy.meshRendererFlag.material.color = Color.yellow;
		enemy.navMeshAgent.Stop ();
		enemy.transform.Rotate (0, enemy.searchingTurnSpeed * Time.deltaTime, 0);
		searchTimer += Time.deltaTime;
		
		if (searchTimer >= enemy.searchingDuration)
			ToPatrolState ();
	}
	
	
}
}