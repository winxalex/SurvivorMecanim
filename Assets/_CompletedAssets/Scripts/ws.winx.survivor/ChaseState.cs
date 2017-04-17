using UnityEngine;
using System.Collections;

namespace ws.winx.survivorai{
	public class ChaseState : ws.winx.statemachine.StateMachineBehaviour //IEnemy
	
{
	
	public StatePatternEnemy enemy;
	//private readonly StatePatternEnemy enemy;
	
	
//	public ChaseState (StatePatternEnemy statePatternEnemy)
//	{
//		enemy = statePatternEnemy;
//	}
	
//	public void UpdateState()
//	{
//		Look ();
//		Chase ();
//	}

	public void Update()
	{
		if(!Look ())
		Chase ();
	}
	
//	public void OnTriggerEnter (Collider other)
//	{
//		
//	}
	
//	public void ToPatrolState()
//	{
//		
//	}
	
	public void ToAlertState()
	{
		//enemy.currentState = enemy.alertState;
		EventDispatcher.Instance.ChaseToAlertConditionEvent.Invoke (this.gameObject);
		//this.enabled = false;

	}
	
//	public void ToChaseState()
//	{
//		
//	}
	
//	private void Look()
//	{
//		RaycastHit hit;
//		Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;
//		if (Physics.Raycast (enemy.eyes.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag ("Player")) {
//			enemy.chaseTarget = hit.transform;
//			
//		}
//		else
//		{
//			ToAlertState();
//		}
//		
//	}



	private bool Look()
	{
		RaycastHit hit;

		//there is bug happen enemy.chaseTarget=null
		if (enemy.chaseTarget == null)
				enemy.chaseTarget = enemy.eyes.transform;
		
		Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;

		if (Physics.Raycast (enemy.eyes.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag ("Player")) {
			enemy.chaseTarget = hit.transform;
			return false;
		}
		else
		{
			ToAlertState();
			return true;
		}
		
	}
	
	private void Chase()
	{
		enemy.meshRendererFlag.material.color = Color.red;
		enemy.navMeshAgent.destination = enemy.chaseTarget.position;
		enemy.navMeshAgent.Resume ();
	}
	
	
}
}