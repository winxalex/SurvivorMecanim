using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using ws.winx.unity.mecanim;

public class EventDispatcher : MonoBehaviour {

//	public UnityEvent patrolStateEnterEvent;
//	public UnityEvent chaseStateEnterEvent;
//	public UnityEvent alertStateEnterEvent;
//
//	public UnityEvent patrolStateExitEvent;
//	public UnityEvent chaseStateExitEvent;
//	public UnityEvent alertStateExitEvent;

//	public StateTransitionRequestEvent stateTransitionRequestEvent=new StateTransitionRequestEvent();

	public MecanimStateObservable mecanimStateObservable = new MecanimStateObservable ();

	static EventDispatcher _instance;

	public static EventDispatcher Instance {
		get {
			return _instance;
		}
	}

	void Awake(){
		if (_instance == null)
			_instance = this;
		else
			DestroyImmediate (this.gameObject);

	}


}
