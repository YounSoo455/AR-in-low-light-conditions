using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlayerPosOnMap : MonoBehaviour
{
    public GameObject player;
    public GameObject startPos;
    public Camera camera;
    private Vector3 prevPosition;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = startPos.transform.position;
        player.transform.rotation = startPos.transform.rotation;
        prevPosition = ProgramManager1.startPoint.transform.position;

    }

    // Update is called once per frameera
    void Update()
    {


        Vector3 deltaForCamera = prevPosition - camera.transform.position;
        prevPosition = camera.transform.position;

        player.transform.Translate(deltaForCamera.x * 0.5f, 0.0f, deltaForCamera.z * 0.5f);
    }

    public static void GetDeltaForCamera(Vector3 deltaForCamera, Camera camera, GameObject player)
    {

        
    }
}
