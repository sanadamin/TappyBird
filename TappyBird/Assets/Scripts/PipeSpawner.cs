using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {
    public GameObject pipe;

    [SerializeField]
    private float maxYPosition,spawnTime;
    public void StopSpawningPipes()
    {
        CancelInvoke("SpawnPipeHolder");
    }
    public void StartSpawningPipes()
    {
        InvokeRepeating("SpawnPipeHolder", 0.1f, spawnTime);
    }
    void SpawnPipeHolder()
    {
        Instantiate(pipe,new Vector3(transform.position.x, Mathf.Clamp(Random.Range(-maxYPosition, maxYPosition),-2f,1.5f),0), Quaternion.identity);
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
