using UnityEngine;
using System.Collections;
/// <summary>
/// The base class for all the actors that navigate using the nav mesh agents.
/// </summary>
[RequireComponent (typeof (NavMeshAgent))]
public class NavMeshPlayerActor : NavMeshActor
{

    /// <summary>
    /// This method is called by unity upon loading the object.
    /// </summary>
    public override void Start()
    {
        base.Start();
    }

    /// <summary>
    /// This method is called by unity every normal frame
    /// </summary>
    public override void Update()
    {
        base.Update();
    }

    /// <summary>
    /// Called whenever the user right-clicks on a collider.
    /// </summary>
    /// <param name="hitInfo"></param>
    public override void OnRightMouseClick(RaycastHit hitInfo)
    {
        base.OnRightMouseClick(hitInfo);
        //Set a new destination.
        SetNewTarget(hitInfo.point);
    }

    /// <summary>
    /// This is called whenever a object enters the gameobject's trigger.
    /// </summary>
    /// <param name="otherCollider">The other collider</param>
    public override void OnTriggerEnter(Collider otherCollider)
    {
        base.OnTriggerEnter(otherCollider);
    }

    //Setup events
    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

}
