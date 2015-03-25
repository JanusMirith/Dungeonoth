using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The base class for all the actors that act without player input.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class AgressiveNpcActor : NpcActor
{

    /// <summary>
    /// A list of enemyFactions
    /// </summary>
    public List<Faction> enemyList;

    /// <summary>
    /// This method is called by unity upon loading the object.
    /// </summary>
    public override void Start()
    {
        base.Start();
        if (enemyList == null)
        {
            Debug.LogWarning("Actor " + name + " has started without enemy factions, this is inefficient please set this in the editor.");
            enemyList = new List<Faction>();
        }
    }

    /// <summary>
    /// This method is called by unity every normal frame
    /// </summary>
    public override void Update()
    {
        base.Update();
    }

    /// <summary>
    /// Think about what to do.
    /// </summary>
    protected override void Think()
    {
        base.Think();

        //This function could be made WAY more efficient 
        //We should find a way to share a list of actors
        Actor[] actorList = GameObject.FindObjectsOfType<Actor>();
        Actor enemyActor = null;
        float distance = float.MaxValue;

        foreach (Actor actor in actorList)
        {
            foreach (Faction enemyFaction in enemyList)
            {
                if (enemyFaction == actor.myFaction)
                {
                    if (Vector3.Distance(transform.position, actor.transform.position) < distance)
                    {
                        enemyActor = actor;
                        SetNewTarget(actor.transform.position);
                    }
                }
            }
        }

        if (enemyActor != null)
        {
            SetNewTarget(enemyActor.transform.position);
        }
    }
}