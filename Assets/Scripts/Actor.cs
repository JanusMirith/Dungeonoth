using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// The base class for all the independent actors such as players and npcs
/// </summary>
public class Actor : MonoBehaviour {

    /// <summary>
    /// The starting health for the actor
    /// </summary>
    public float startHealth = 100f;

    /// <summary>
    /// The current health for the actor
    /// </summary>
    public float currentHealth = 100f;

    /// <summary>
    /// A list of possible factions
    /// </summary>
    public enum Faction
    {
        Good,
        Bad,
        Ugly,
        World
    }

    /// <summary>
    /// What faction does this actor belong to.
    /// </summary>
    public Faction myFaction = Faction.Good;

    /// <summary>
    /// A list of enemyFactions
    /// </summary>
    public List<Faction> enemyList;

    /// <summary>
    /// This method is called by unity upon loading the object.
    /// </summary>
    public virtual void Start()
    {
        if (enemyList == null)
        {
            Debug.LogWarning("Actor " + name + " has started without enemy factions, this is inefficient please set this in the editor.");
            enemyList = new List<Faction>();
        }
    }

    /// <summary>
    /// This method is called by unity every normal frame
    /// </summary>
    public virtual void Update()
    {
        //Do nothing .... for the moment
    }

    /// <summary>
    /// This is called whenever a object enters the gameobject's trigger.
    /// </summary>
    /// <param name="otherCollider">The other collider</param>
    public virtual void OnTriggerEnter(Collider otherCollider)
    {

    }

    /// <summary>
    /// Called whenever the user right-clicks on a collider.
    /// </summary>
    /// <param name="hitInfo"></param>
    public virtual void OnRightMouseClick(RaycastHit hitInfo)
    {
    }

    //Setup events
    public virtual void OnEnable()
    {
        //Start listening to right clicks
        MouseInput.rightMouseClick += OnRightMouseClick;
    }


    public virtual void OnDisable()
    {
        //Stop listening to right clicks 
        MouseInput.rightMouseClick -= OnRightMouseClick;
    }
}
