using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverBoundary : MonoBehaviour {

    void OnTriggerEnter(Collider collision)
    {

        Debug.Log("In OnCollisionEnter");
        var hit = collision.gameObject;
        var health = hit.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(1000);
        }
    }
}
