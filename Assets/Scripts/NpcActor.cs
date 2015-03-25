using UnityEngine;
using System.Collections;
/// <summary>
/// The base class for all the actors that act without player input.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class NpcActor : NavMeshActor
{
    /// <summary>
    /// The minimum time between thoughts in seconds.
    /// </summary>
    public float minimumThoughtWaitTime = 1;

    /// <summary>
    /// The range of seconds that the actor will randomly wait between thoughts.
    /// </summary>
    public float randomThoughtWaitRange = 1;

    /// <summary>
    /// This method is called by unity upon loading the object.
    /// </summary>
    public override void Start()
    {
        base.Start();
        //Start thinking
        StartCoroutine(ThoughtLoop());
    }

    /// <summary>
    /// This method is called by unity every normal frame
    /// </summary>
    public override void Update()
    {
        base.Update();
    }

    /// <summary>
    /// This is a loop that controls when the NPC will reassess its situation 
    /// </summary>
    /// <returns>Coroutine</returns>
    protected IEnumerator ThoughtLoop()
    {
        //While true!?!?!?! yes it is fine, the yield function allows unity to stop the loop when the game or scene quits
        while (true)
        {
            //Tell the npc to think about it's next action
            Think();

            //setup the time to wait until the next thought.
            float waitTime = minimumThoughtWaitTime + (Random.value * randomThoughtWaitRange);

            //Tell the game to wait for a few seconds before looping again.
            yield return new WaitForSeconds(waitTime);
        }
    }

    /// <summary>
    /// This is the base method for all npc thought patterns.
    /// </summary>
    protected virtual void Think(){

    }
}
