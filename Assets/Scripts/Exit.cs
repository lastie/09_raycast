using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	public bool win = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTriggerEnter(Collider activator) {
		if (activator.tag == "Player") {
			win = true;
			Destroy(activator);
		}
	}
}
