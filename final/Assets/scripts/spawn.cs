using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

    public GameObject[] letters;
    public Vector3 spawnValues;
    public float spawnWait;
    public int startWait;
    public float spawnMostWait;
    public float spawnLesatWait;
    public bool stop;


    int randletter;
    // Use this for initialization
    void Start () {
        StartCoroutine(Spawner());
	}
	
	// Update is called once per frame
	void Update () {
        spawnWait = Random.Range(spawnLesatWait, spawnMostWait);
	}


    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randletter = Random.Range(0, 5);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(letters[randletter], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);


            yield return new WaitForSeconds(spawnWait);
        }
    }
}
