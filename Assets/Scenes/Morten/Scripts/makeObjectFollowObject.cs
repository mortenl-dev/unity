using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class makeObjectFollowObject : MonoBehaviour
{   

    [SerializeField] List<GameObject> Follower = new List<GameObject>();
    [SerializeField] List<GameObject> Followed = new List<GameObject>();
    Vector3 inherentPosition;

     // Start is called before the first frame update
    void Start()
    {   
        for (int i = 0; i < Follower.Count; i++)
        {
            inherentPosition = Follower[i].transform.position;
        }

        
    }

    // Update is called once per frame
    void Update()
    {   
        for (int i = 0; i < Follower.Count; i++)
        {   
            Follower[i].transform.position = Followed[i].transform.position + inherentPosition;
        }
    }
}
