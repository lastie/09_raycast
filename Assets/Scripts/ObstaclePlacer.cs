using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// ObstaclePlacer places walls, remmebers the wall it places
// and if the player presses [K], then all walls are deleted.

public class ObstaclePlacer : MonoBehaviour {

	public Transform obstaclePrefab; // assign in Inspector

	List<Transform> obstacleClones = new List<Transform>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// generate a ray before shooting a raycast
		Ray cursorRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		// reserve in memory a 'blank' object to hold impact data
		RaycastHit cursorRayInfo = new RaycastHit();

		if (Physics.Raycast (cursorRay, out cursorRayInfo, 100f)) {
			Debug.Log(cursorRayInfo.collider.name);
		}

		// if the player left-clicked...
		//			if (Input.GetMouseButtonDown (0)) {
		//				Instantiate (obstaclePrefab, cursorRayInfo.point, Random.rotation);
		//			}
		
		// if the player right-clicked...
		if (Input.GetMouseButtonDown (1)) {
			Transform newClone = (Transform) Instantiate (obstaclePrefab, cursorRayInfo.point, Random.rotation);
			obstacleClones.Add (newClone);
		}

		if (Input.GetKeyDown(KeyCode.K)) {
			foreach (Transform clone in obstacleClones) {
				clone.Rotate (0f, 90f, 0f, Space.World);
			}
		}
	}
}
