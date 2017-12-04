using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public Camera cam;
	public float Acc = 1f;
	public float mouseViewDragHorizontal = 5f;
	public float objectMaxSpeed = 5f;
	public float camAngle = 0.0f;
	public float camHeight = 1.0f;
	public float camMaxLookAt = 2.0f;
	public float camLookAt = 0.0f;
	public float viewStableRatioHorizontal = 0.06f;
	public float camDistance = 4f;
	public float jumpForce = 20f;


	private Rigidbody rb;
	private Vector3 camPosition;
	// Use this for initialization
	void Start () {
		cam.gameObject.SetActive(true);
		rb = GetComponent<Rigidbody> ();
		camLookAt = Mathf.Clamp (camLookAt, -camMaxLookAt, camMaxLookAt);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Input.mousePosition;
		Vector2 mouseXY = new Vector2 ((mousePos.x - Screen.width / 2f) / Screen.width, (mousePos.y - Screen.height / 2f) / Screen.height);
		if (Mathf.Abs (mouseXY.x) > viewStableRatioHorizontal) {
			camAngle -= mouseXY.x * mouseViewDragHorizontal;
		}
		camLookAt = mouseXY.y * camMaxLookAt * 2f;
		camLookAt = Mathf.Clamp (camLookAt, -camMaxLookAt, camMaxLookAt);

		float angleSin = Mathf.Sin (Mathf.Deg2Rad * camAngle);
		float angleCos = Mathf.Cos (Mathf.Deg2Rad * camAngle);

		float horizontalValue = Input.GetAxis ("Horizontal");
		float verticalValue = Input.GetAxis ("Vertical");
		float horizontalMove = angleCos * horizontalValue - angleSin * verticalValue;
		float verticalMove = angleCos * verticalValue + angleSin * horizontalValue;

		// move rigidbody
		rb.velocity = rb.velocity + new Vector3(horizontalMove * Acc, 0f, verticalMove * Acc);
		rb.velocity = Vector3.ClampMagnitude (rb.velocity, objectMaxSpeed);
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb.AddForce (new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
		}

		// move and rotate camera
		camPosition.x = angleSin * camDistance;
		camPosition.y = camHeight;
		camPosition.z = -angleCos * camDistance;
		cam.transform.position = rb.transform.position + camPosition;
		cam.transform.LookAt (rb.transform.position + new Vector3(0f, camLookAt, 0f));
	}
}
