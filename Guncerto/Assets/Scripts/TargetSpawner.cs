using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class TargetSpawner : MonoBehaviour
{
    [SerializeField] Transform[] lanes;
    [SerializeField] GameObject targetPrefab;

    Dictionary<Transform, List<Vector3>> lanesDictionary = new Dictionary<Transform, List<Vector3>>();

    void Start()
    {
        InitLists();
   
    }

    void Update()
    {
        
    }

    public void SpawnTarget()
    {
        int randomLane = Random.Range(0, lanes.Length);
        // random rotation
        GameObject newTarget = Instantiate(targetPrefab, lanesDictionary[lanes[randomLane]][0], Quaternion.Euler(new Vector3(0, Random.Range(0, 360), Random.Range(0, 360))));
        newTarget.GetComponent<MusicNote>().Movement(lanesDictionary[lanes[randomLane]].ToArray());
    }

    void InitLists()
    {

        foreach (var lane in lanes)
        {
            List<Transform> children = new List<Transform>();
            List<Vector3> lanePositions = new List<Vector3>();

            children = lane.GetComponentsInChildren<Transform>().Where(t => t != lane).ToList();
            foreach(var child in children)
            {
                
                lanePositions.Add(new Vector3(lane.position.x, child.position.y, child.position.z));
            }
            lanesDictionary.Add(lane, lanePositions);
        }
      
    }
}