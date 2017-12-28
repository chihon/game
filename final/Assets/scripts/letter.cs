using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter : MonoBehaviour
{
    private float rotatespeed = 5f;

    public string word;

    private ball_collect_alphabet bca;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * rotatespeed);
        //transform.RotateAround(Vector3.zero, Vector3.down, rotatespeed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            bca = other.gameObject.GetComponent<ball_collect_alphabet>();
            bca.SetAlphabetChar(word);
            Destroy(gameObject);
        }
    }
}
