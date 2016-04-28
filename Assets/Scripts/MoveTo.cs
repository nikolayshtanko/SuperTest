using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent mAgent;

	void Start() {
        mAgent = GetComponent<NavMeshAgent>();
    }
	
	void Update()
    {
        mAgent.SetDestination(target.position);
	}
}
