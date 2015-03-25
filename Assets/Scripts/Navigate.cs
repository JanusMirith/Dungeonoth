using UnityEngine;
using System.Collections;

public class Navigate : MonoBehaviour {
    public GameObject navigationTarget;
    public NavMeshAgent navMeshAgent;

    public void OnRightMouseClick(RaycastHit hitInfo)
    {
        //A quick hack to show the target of the nav agent.
        navigationTarget = hitInfo.collider.gameObject;

        //Set a new destination.
        navMeshAgent.SetDestination(hitInfo.point);
        navMeshAgent.Resume();
    }

    //Setup events
    void OnEnable()
    {
        //Start listening to right clicks
        MouseInput.rightMouseClick += OnRightMouseClick;
    }


    void OnDisable()
    {
        //Stop listening to right clicks 
        MouseInput.rightMouseClick -= OnRightMouseClick;
    }
}
