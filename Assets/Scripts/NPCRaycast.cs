using UnityEngine;
using System.Collections;

public class NPCRaycast : MonoBehaviour {

	public float speed = 0.3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody>().AddForce (transform.forward * speed, ForceMode.VelocityChange);

		// generate ray
		Ray ray = new Ray(transform.position, transform.forward);

		// actually shoot raycast
		if (Physics.Raycast(ray, 3f)) {
			transform.Rotate(0f, Random.Range (-90f, 90f), 0f);
		}
	}
}
