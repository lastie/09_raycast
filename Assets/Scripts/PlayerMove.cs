using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public float speed = 0.2f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Ray cursorRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit cursorRayinfo = new RaycastHit();

		if (Input.GetMouseButtonDown(0) ) {
			Physics.Raycast(cursorRay, out cursorRayinfo, 1000f);
			Vector3 destination = cursorRayinfo.point;
			Vector3 moveDirection = destination - transform.position;
			//Debug.DrawRay(destination, Vector3.up, Color.red, 1f);
			moveDirection /= moveDirection.magnitude; // Now this vector is normalized

			GetComponent<Rigidbody>().AddForce(moveDirection * speed, ForceMode.VelocityChange);
		}
	
	}
}
