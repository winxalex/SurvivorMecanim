using UnityEngine;
using System.Collections;


/// <summary>
/// State enemy pattern.(THIS IS MODEL)
/// </summary>
using System.Collections.Generic;


public class StatePatternEnemy : MonoBehaviour {


	public float searchingTurnSpeed = 120f;
	public float searchingDuration = 4f;
	public float sightRange = 20f;
	public Transform waypointsHolder;


	Transform[] _wayPoints;

	public Transform[] wayPoints {
		get {
			if(_wayPoints==null){
				//GetComponentsInChildren() returns only active, set IncludeInactive
				List<Transform> results=new List<Transform>();
				waypointsHolder.GetComponentsInChildren<Transform>(true,results);

				if(results.Count>0)
					results.RemoveAt(0);
				_wayPoints=results.ToArray();
				return _wayPoints;
			}

			return _wayPoints;
		}
	}

	public Transform eyes;
	public Vector3 offset = new Vector3 (0,.5f,0);
	public MeshRenderer meshRendererFlag;

	[HideInInspector]
	public Transform chaseTarget;
	public NavMeshAgent navMeshAgent;


//		[HideInInspector] public Transform chaseTarget;
//		[HideInInspector] public IEnemyState currentState;
//		[HideInInspector] public ChaseState chaseState;
//		[HideInInspector] public AlertState alertState;
//		[HideInInspector] public PatrolState patrolState;
//		[HideInInspector] public NavMeshAgent navMeshAgent;
//		
//		private void Awake()
//		{
//			chaseState = new ChaseState (this);
//			alertState = new AlertState (this);
//			patrolState = new PatrolState (this);
//			
//			navMeshAgent = GetComponent<NavMeshAgent> ();
//		}
//		
//		// Use this for initialization
//		void Start () 
//		{
//			currentState = patrolState;
//		}
//		
//		// Update is called once per frame
//		void Update () 
//		{
//			currentState.UpdateState ();
//		}
//		
//		private void OnTriggerEnter(Collider other)
//		{
//			currentState.OnTriggerEnter (other);
//		}




}
