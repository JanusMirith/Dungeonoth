using UnityEngine;
using System.Collections;

/// <summary>
/// Modifyed from script found on http://forum.unity3d.com/threads/rts-camera-script.72045/
/// 
/// Ported to c# and changed to work with unity5 and standard input by Thomas MacNamara
/// </summary>
public class RTSCamera : MonoBehaviour
{

    public float ScrollSpeed = 15f;
    public float ScrollEdge = 0.01f;

    private int HorizontalScroll = 1;
    private int VerticalScroll = 1;
    private int DiagonalScroll = 1;

    public float PanSpeed = 10f;

    public Vector2 ZoomRange = new Vector2(-5, 5);
    public float CurrentZoom = 0;
    public float ZoomZpeed = 1;
    public float ZoomRotation = 1;

    private Vector3 InitPos;
    private Vector3 InitRotation;



    void Start()
    {
        InitPos = transform.position;
        InitRotation = transform.eulerAngles;

    }

    void Update()
    {
        //PAN
        if (Input.GetMouseButton(2))
        {
            //(Input.mousePosition.x - Screen.width * 0.5)/(Screen.width * 0.5)

            transform.Translate(Vector3.right * Time.deltaTime * PanSpeed * (Input.mousePosition.x - Screen.width * 0.5f) / (Screen.width * 0.5f), Space.World);
            transform.Translate(Vector3.forward * Time.deltaTime * PanSpeed * (Input.mousePosition.y - Screen.height * 0.5f) / (Screen.height * 0.5f), Space.World);

        }
        else
        {
            //Mouse
            if (Input.mousePosition.x >= Screen.width * (1 - ScrollEdge))
            {
                transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed, Space.World);
            }
            else if (Input.mousePosition.x <= Screen.width * ScrollEdge)
            {
                transform.Translate(Vector3.right * Time.deltaTime * -ScrollSpeed, Space.World);
            }

            if (Input.mousePosition.y >= Screen.height * (1 - ScrollEdge))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * ScrollSpeed, Space.World);
            }
            else if (Input.mousePosition.y <= Screen.height * ScrollEdge)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * -ScrollSpeed, Space.World);
            }
            //Keyboard
            if (Input.GetAxis("Horizontal") != 0f )
            {
                transform.Translate((Vector3.right * Time.deltaTime * ScrollSpeed) * Input.GetAxis("Horizontal"), Space.World);
            }
            if (Input.GetAxis("Vertical") != 0f )
            {
                transform.Translate((Vector3.forward * Time.deltaTime * ScrollSpeed) * Input.GetAxis("Vertical"), Space.World);
            }
        }

        //ZOOM IN/OUT

        CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * ZoomZpeed;

        CurrentZoom = Mathf.Clamp(CurrentZoom, ZoomRange.x, ZoomRange.y);

        transform.position = transform.position - new Vector3(0f, (transform.position.y - (InitPos.y + CurrentZoom)) * 0.1f);
        transform.eulerAngles = transform.eulerAngles - new Vector3((transform.eulerAngles.x - (InitRotation.x + CurrentZoom * ZoomRotation)) * 0.1f,0f);

    }
}
