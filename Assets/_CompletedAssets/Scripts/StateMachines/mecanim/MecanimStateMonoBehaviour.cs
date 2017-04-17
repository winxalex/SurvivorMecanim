using UnityEngine;
using System.Collections;
using ws.winx.unity;
using ws.winx.unity.attributes;
using UniRx;

namespace ws.winx.unity.mecanim
{
	public class MecanimStateMonoBehaviour : MonoBehaviour
	{



		[AnimatorStateAttribute ()]
		public MecanimAnimatorState state;

		public EventDispatcher dispatcher;

		[HideInInspector]
		public Animator animator;

		string _prevStateTrigger;


		public virtual void Awake ()
		{
			
			
			if (dispatcher.mecanimStateObservable!=null && state!=null) {
				dispatcher.mecanimStateObservable.Where (

					(typle) => {
						
						return state.nameHash == typle.Item1;
					})
					.AddListener (Decide);


			}
				

		}



		public void StateTransitionRequest(string stateFromToTrigger){

			if(!string.IsNullOrEmpty(_prevStateTrigger))
				animator.ResetTrigger (_prevStateTrigger);

			animator.SetTrigger (stateFromToTrigger);
			_prevStateTrigger = stateFromToTrigger;

		}


		void Decide (int nameHash, MecanimStateMachineBehabviour.EventType eventType)
		{
			

			if(eventType==MecanimStateMachineBehabviour.EventType.Enter) 
				this.enabled=true;
			else //if(eventType==MecanimStateMachineBehabviour.Event.Exit) this.enabled=false;
				this.enabled=false;


		}


	}
}

