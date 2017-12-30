using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class camMouseLook : NetworkBehaviour {
	Vector2 mouseLook;
	Vector2 smoothV;
	Camera cam;

	public float sensitivity = 4.0f;
	public float smoothing = 2.0f;
    public float viewRange = 70.0f;
    public float camHeight = 2.0f;
    public float camDistance = 2.4f;

    Vector3 camOffset;

	GameObject player;
	// Use this for initialization
	void Start () {
		cam = Camera.main;
        camOffset = new Vector3(0.0f, camHeight, 0.0f);

    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
		var md = new Vector2 (-Input.GetAxisRaw ("Mouse X"), -Input.GetAxisRaw ("Mouse Y"));

		md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, md.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, md.y, 1f / smoothing);

		mouseLook += smoothV;
        //cam.transform.rotation = Quaternion.Inverse(transform.rotation) *  Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
        mouseLook.y = Mathf.Clamp(mouseLook.y, -viewRange, viewRange);
		cam.transform.rotation = transform.rotation *  Quaternion.AngleAxis (-mouseLook.y, Vector3.right) * Quaternion.Euler(0,180,0);

        Vector3 fwd = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized;
        //Vector3 fwd = new Vector3(cam.transform.forward.x, cam.transform.forward.y, 0);

        //cam.transform.localEulerAngles = camViewRangeClamp(cam.transform.localEulerAngles, cam.transform.up, viewRange);

        //https://answers.unity.com/questions/415623/how-do-i-limit-camera-rotation-on-y-axis.html






        //cam.transform.rotation = ClampRotationYByLookDirection(cam.transform.rotation);



        cam.transform.position = transform.position + camOffset - fwd * camDistance;
		transform.rotation = Quaternion.AngleAxis (-mouseLook.x, transform.up);
	}
    /*
    Vector3 camViewRangeClamp(Vector3 eulerAngle, Vector3 up, float range)
    {
        float original = eulerAngle.x;

        if (up.y > 0)
        {
            if (eulerAngle.x > 180)
            {
                eulerAngle.x -= 360;
            }
            if (eulerAngle.x > range)
            {
                eulerAngle.x = range;
            }
            else if (eulerAngle.x < -range)
            {
                eulerAngle.x = -range;
            }
        } else
        {
            if (eulerAngle.x > 180)
            {
                eulerAngle.x -= 360;
            }
            if (eulerAngle.x > range)
            {
                eulerAngle.x = range;
            }
            else if (eulerAngle.x < -range)
            {
                eulerAngle.x = -range;
            }
        }
        Debug.Log(Camera.main.transform.up);
        Debug.Log(Mathf.Round(original).ToString() + ',' + Mathf.Round(eulerAngle.x).ToString() + ',' + Mathf.Round(eulerAngle.y).ToString() + ',');
        return eulerAngle;
    }
    */
}
