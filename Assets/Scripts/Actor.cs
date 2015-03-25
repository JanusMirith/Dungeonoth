using UnityEngine;
using System.Collections;
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
        Ugly
    }

    /// <summary>
    /// What faction does this actor belong to.
    /// </summary>
    public Faction myFaction = Faction.Good;

    /// <summary>
    /// This method is called by unity upon loading the object.
    /// </summary>
    public virtual void Start()
    {
        //Do nothing .... for the moment
    }

    /// <summary>
    /// This method is called by unity every normal frame
    /// </summary>
    public virtual void Update()
    {
        //Do nothing .... for the moment
    }
}
