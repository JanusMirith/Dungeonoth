using UnityEngine;
using System.Collections;

/// <summary>
/// This class emulates unity's mouse ray-cast controls to allow better logic flow.
/// </summary>
public class MouseInput : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

        //Right Click
        // Construct a ray from the current mouse coordinates
        if (Input.GetMouseButtonDown(1))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(mouseRay, out hitInfo))
            {
                //Are there any listeners?
                if (rightMouseClick != null)
                {
                    //Fire the event
                    rightMouseClick(hitInfo);
                }
            }
        }

        //Left Click
        // Construct a ray from the current mouse coordinates
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(mouseRay, out hitInfo))
            {
                //Are there any listeners?
                if (leftMouseClick != null)
                {
                    //Fire the event
                    leftMouseClick(hitInfo);
                }
            }
        }
	}

    /// <summary>
    /// Fires whenever the user left clicks on the screen.
    /// </summary>
    /// <param name="hitInfo">Hit information for the click</param>
    public delegate void LeftMouseClick(RaycastHit hitInfo);

    /// <summary>
    /// Fires whenever the user clicks on the screen.
    /// </summary>
    public static event LeftMouseClick leftMouseClick;

    /// <summary>
    /// Fires whenever the user right clicks on the screen.
    /// </summary>
    /// <param name="hitInfo">Hit information for the click</param>
    public delegate void RightMouseClick(RaycastHit hitInfo);

    /// <summary>
    /// Fires whenever the user clicks on the screen.
    /// </summary>
    public static event RightMouseClick rightMouseClick;
}
