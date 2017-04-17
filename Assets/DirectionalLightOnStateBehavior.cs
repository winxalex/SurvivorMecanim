using UnityEngine;
using System.Collections;

public class DirectionalLightOnStateBehavior : ws.winx.statemachine.StateMachineBehaviour {

	public Light light;

	void OnEnable(){
		if (light) {
			light.enabled = true;

		}

	}

//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
}
