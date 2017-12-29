using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class spawn : NetworkBehaviour {

    public GameObject[] letters;
    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
    //public float spawnMostWait;
    //public float spawnLesatWait;
    public bool stop;


    int randletter;
    // Use this for initialization

    void Start()
    {
        if (!isServer) { return; }

        // Do server code
        InvokeRepeating("createLetter", startWait, spawnWait);
    }

    /*
    public override void OnStartServer()
    {
        InvokeRepeating("createLetter", 4.0f, 2.0f);
    }
    */
    /*
    void Start () {
        //StartCoroutine(Spawner());
	}
	
	// Update is called once per frame
	void Update () {
        spawnWait = Random.Range(spawnLesatWait, spawnMostWait);
	}
    */

    void createLetter()
    {
        randletter = Random.Range(0, 5);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
        GameObject letter = (GameObject)Instantiate(letters[randletter], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        NetworkServer.Spawn(letter);
    }



    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randletter = Random.Range(0, 5);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

            //RpcSpawn(randletter, spawnPosition);

            //GameObject letter = (GameObject)Instantiate(letters[randletter], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            //NetworkServer.Spawn(letter);
            //Network.Instantiate(letters[randletter], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation, 0    );

            yield return new WaitForSeconds(spawnWait);
        }
    }

    /*
    [ClientRpc]
    void RpcSpawn(int randletter, Vector3 spawnPosition)
    {
        //Debug.Log(letters[randletter]);
        
        GameObject letter2 = (GameObject)Instantiate(pre, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        NetworkServer.Spawn(letter2);
    } 
    */
}
