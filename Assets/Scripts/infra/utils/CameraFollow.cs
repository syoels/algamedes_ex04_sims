using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public Vector3 offset;
	Vector3 targetPos;
	// Use this for initialization
	void Start () {
		targetPos = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {

		Vector3 mouseworldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));

			Vector3 posNoZ = transform.position;
			posNoZ.z = 0f;

		Vector3 targetDirection = (mouseworldPosition - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 

			transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);

	}
}