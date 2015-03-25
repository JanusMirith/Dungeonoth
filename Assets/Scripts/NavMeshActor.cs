using UnityEngine;
using System.Collections;
/// <summary>
/// The base class for all the actors that navigate using the nav mesh agents.
/// </summary>
[RequireComponent (typeof (NavMeshAgent))]
public class NavMeshActor : Actor
{
    /// <summary>
    /// A reference to the actor's navmesh agent.
    /// </summary>
    [Header("NavMeshAgent, set in editor before use")]
    public NavMeshAgent navMeshAgent; //Must be set in editor.

    /// <summary>
    /// Sets a new target for the nav mesh agent
    /// </summary>
    /// <param name="targetPosition">The world space coordinates for the actor to navigate to.</param>
    public void SetNewTarget(Vector3 targetPosition)
    {
        navMeshAgent.SetDestination(targetPosition);
        navMeshAgent.Resume();
    }

    /// <summary>
    /// Orders the nav mesh agent to stop.
    /// </summary>
    public void StopNavigation()
    {
        navMeshAgent.Stop();
    }

    /// <summary>
    /// This method is called by unity upon loading the object.
    /// </summary>
    public override void Start()
    {
        base.Start();

        //Make sure we have a reference to the nav mesh agent
        if (navMeshAgent == null)
        {
            Debug.LogWarning("Actor " + name + " has started without a reference to the navMeshAgent, this is inefficient please set this in the editor.");
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        }
    }

    /// <summary>
    /// This method is called by unity every normal frame
    /// </summary>
    public override void Update()
    {
        base.Update();
    }
}
