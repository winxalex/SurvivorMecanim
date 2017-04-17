using UnityEngine;
using System.Collections;
using ws.winx.unity.attributes;

namespace ws.winx.unity.mecanim{
	public class MecanimStateMachineBehabviour : StateMachineBehaviour {

		public enum EventType{
			Exit =0,
			Enter =1


		}

		[UnityVariableProperty(typeof(MecanimStateObservable),"","",UnityVariablePropertyAttribute.DisplayOptions.Bind)]
		public UnityVariable eventUnityVariable;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			if(eventUnityVariable!=null && eventUnityVariable.Value!=null)
				(eventUnityVariable.Value as MecanimStateObservable).InvokeOnTarget(animator.gameObject,stateInfo.shortNameHash,MecanimStateMachineBehabviour.EventType.Enter);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			if(eventUnityVariable!=null && eventUnityVariable.Value!=null)
				(eventUnityVariable.Value as MecanimStateObservable).InvokeOnTarget(animator.gameObject,stateInfo.shortNameHash,MecanimStateMachineBehabviour.EventType.Exit);

			//
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
}
