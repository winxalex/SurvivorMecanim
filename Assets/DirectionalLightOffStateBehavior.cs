using UnityEngine;
using System.Collections;

public class DirectionalLightOffStateBehavior : ws.winx.statemachine.StateMachineBehaviour {

	public Light light;

	void OnEnable(){
//		if (GetComponent<Light>())
//			GetComponent<Light>().gameObject.SetActive(false);
		if (light)
			light.enabled = false;

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
