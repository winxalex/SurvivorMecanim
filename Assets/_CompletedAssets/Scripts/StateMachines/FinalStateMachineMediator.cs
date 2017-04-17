using UnityEngine;
using System.Collections;

public class FinalStateMachineMediator : MonoBehaviour {

	public Animator animator;
	public EventDispatcher dispatcher;

	string prev;




	public void HandleStateTransitionRequest(string stateFromToTrigger){

		if(!string.IsNullOrEmpty(prev))
			animator.ResetTrigger (prev);

		animator.SetTrigger (stateFromToTrigger);
		prev = stateFromToTrigger;

	}
}
