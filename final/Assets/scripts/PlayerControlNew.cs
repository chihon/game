using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// https://www.youtube.com/watch?v=blO039OzUZc
// https://answers.unity.com/questions/895465/raycast-to-test-if-player-is-grounded.html
public class PlayerControlNew : MonoBehaviour {
	public float speed = 3.0F;
	public float jumpForce = 7.0F;
	Rigidbody rb;
	float distToGround;
	Collider mycollider;

	bool IsGrounded()
	{
		return Physics.Raycast(transform.position, - Vector3.up, distToGround + 0.1f);
	}

	void Start() {
		mycollider = GetComponent<Collider> ();
		distToGround = mycollider.bounds.extents.y;
		Cursor.lockState = CursorLockMode.Locked;
		rb = GetComponent<Rigidbody> ();
	}
	void Update() {
		//if (!isLocalPlayer) {
		//	return;
		//}
		float translation = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		//rb.velocity = rb.velocity + new Vector3(horizontalMove * Acc, 0f, verticalMove * Acc);
		//Debug.Log (new Vector3(straffe, 0, translation));

		Vector3 realTranslate =  new Vector3(straffe, 0, translation);
		//Debug.Log(realTranslate.x);
		realTranslate = Quaternion.AngleAxis (-2f*rb.transform.eulerAngles.y, Vector3.up) * realTranslate;

		rb.transform.Translate (realTranslate);	

		if (Input.GetKeyDown ("escape")) {
			if (Cursor.lockState == CursorLockMode.Locked) {
				Cursor.lockState = CursorLockMode.None;
			}
		}
		if (Input.GetKeyDown ("space")) {
			if (IsGrounded ()) {
				rb.AddForce (new Vector3 (0f, jumpForce, 0f), ForceMode.Impulse);
			}
		}
	}
}
