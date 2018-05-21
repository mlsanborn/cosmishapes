using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class testnav : MonoBehaviour
{

    //so you make this field and it holds information on the BAKED navmesh
    [SerializeField]

    //Where i want to go 
    Transform _destination;
    //how am i gonna get there ?
    NavMeshAgent _navMeshAgent; //shitty AI?
    // Use this for initialization
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // oh god why is this here .....
        _navMeshAgent.SetDestination(_destination.transform.position); //maggie told me this was okay
    }
}

//this is it for the most simple ai outthere and we can leave it or change it up a bit idk