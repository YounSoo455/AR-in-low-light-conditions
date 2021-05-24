using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ProgramManager1 : MonoBehaviour
{
    private static bool setStartPoint = true;
    public static GameObject startPoint;//начальная точка как объект
    public static GameObject startPointImage;//начальная позиция на маркере
    private ARTrackedImageManager ARTrackedImageManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        ARTrackedImageManagerScript = FindObjectOfType<ARTrackedImageManager>();
    }

    // Update is called once per frame
    void Update()
    {
       SetStartPoint();
        
    }

    public static void SetStartPoint()
    {
        //Quaternion quaternion = new Quaternion(270f, 0f, 0f, 0f);
        startPointImage = GameObject.FindGameObjectWithTag("StartPointOnImage");
        if (setStartPoint)
        {
            Instantiate(startPoint, startPointImage.transform.position, startPointImage.transform.rotation);
            setStartPoint = false;
        }

    }
}
