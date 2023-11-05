using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private GameObject _finish;
    private float _time;

    void Update()
    {
        if (Time.time > _time && GameManager.SpawnedCount < 100)
        {
            Spawn(_obstacle);
            _time = Time.time + _timeBetweenSpawn;
        }
        else if(Time.time > _time && GameManager.SpawnedCount == 100)
        {
            Spawn(_finish);
            _time = Time.time + _timeBetweenSpawn;
        }
    }
    private void Spawn(GameObject gameObject)
    {
        float y = Random.Range(-6f, -3f);
        Instantiate(gameObject, new Vector3(12, y, 0), new Quaternion(0, 0, 0, 0));
        GameManager.SpawnedCount++;
    }
}
