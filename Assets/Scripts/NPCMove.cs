using UnityEngine;
using System.Collections;

public class NPCMove : MonoBehaviour {

	public float speed = 10f;
	public float detectionRadius = 20f;
	public float sightConeAngle = 60f;
	GameObject player;
	Rigidbody rbody;
	Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		rbody = GetComponent<Rigidbody>();
		initialPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.VelocityChange);
		rbody.velocity = transform.forward * speed;

		Ray NPCray = new Ray(transform.position, transform.forward);
		RaycastHit rayHit = new RaycastHit();

		if (Physics.Raycast(NPCray, out rayHit, 2f) && rayHit.collider.tag != "Player") {
			transform.Rotate (0f, 90f, 0f);
		}

		Vector3 fromNPCtoPlayer = player.transform.position - transform.position;
		fromNPCtoPlayer /= fromNPCtoPlayer.magnitude;
		Ray NtoP = new Ray(transform.position, fromNPCtoPlayer);
		RaycastHit NtoPHit = new RaycastHit();

		bool isCloseEnough = (Vector3.Distance(transform.position, player.transform.position) < detectionRadius);
		bool isInViewCone = (Vector3.Angle(transform.forward, fromNPCtoPlayer) < (sightConeAngle / 2));
		bool isInLineOfSight = (Physics.Raycast(NtoP, out NtoPHit, detectionRadius) && NtoPHit.collider.tag == "Player");

		if (isCloseEnough && isInViewCone && isInLineOfSight) {
			rbody.velocity = fromNPCtoPlayer * speed * 2f;
			if (Physics.Raycast(NPCray, out rayHit, 2f) && rayHit.collider.tag != "Player") {
				transform.Rotate (0f, 90f, 0f);
			}
			if (Vector3.Distance(transform.position, player.transform.position) < 5f) {
				player.transform.position = initialPosition;
			}
		}

	}
}
