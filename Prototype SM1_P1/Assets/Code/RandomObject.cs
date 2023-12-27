using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{
    public List<Transform> SpawnPoints;
    public GameObject[] RandomObjects;
    public Transform Player;

    public float curTime;
    public float NextSpawn;

    // Update is called once per frame

    void Start(){
        curTime = 0f;
    }

    void Update()
    {
        curTime += Time.deltaTime;

        if(curTime > NextSpawn){
            ShootObject();
            curTime = 0f;
        }
    }

    void ShootObject(){
        int Points = Random.Range(0, SpawnPoints.Count);
        int RandomIndex = Random.Range(0, RandomObjects.Length);

        GameObject clone = Instantiate(RandomObjects[RandomIndex], SpawnPoints[Points].position, Quaternion.identity);
    }
}
