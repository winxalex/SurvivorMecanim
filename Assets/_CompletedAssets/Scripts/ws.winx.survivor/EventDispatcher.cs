using UnityEngine;
using System.Collections;
using ws.winx.unity.statemachine;
using ws.winx.unity.mecanim;

namespace ws.winx.survivorai
{

	public class EventDispatcher:MonoBehaviour
	{



		public ConditionUnityEvent PatrolToAlertConditionEvent = new ConditionUnityEvent ();
		public ConditionUnityEvent PatrolToChaseConditionEvent = new ConditionUnityEvent ();
		public ConditionUnityEvent AlertToPatrolConditionEvent = new ConditionUnityEvent ();
		public ConditionUnityEvent AlertToChaseConditionEvent = new ConditionUnityEvent ();
		public ConditionUnityEvent ChaseToAlertConditionEvent = new ConditionUnityEvent ();


	

	


		static ws.winx.survivorai.EventDispatcher instance;

		public static ws.winx.survivorai.EventDispatcher Instance {
			get {
				return instance;
			}
		}

		void Awake ()
		{
			if (instance == null)
				instance = this;
			else
				DestroyImmediate (this.gameObject);


			
		}
	}

}
