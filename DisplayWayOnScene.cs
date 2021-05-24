using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWayOnScene : MonoBehaviour
{
    

    public static void GetDeltas(List<GameObject> objectsPoints, Camera camera, List<Vector3> deltas)
    {
        Vector3 delta = Vector3.zero; 
        Vector3 playerPosOnMap = objectsPoints[0].transform.position;
        for(int i=0; i<objectsPoints.Count-1; i++)
        {
            delta = objectsPoints[i].transform.position - objectsPoints[i + 1].transform.position;
            delta = new Vector3(delta.x / 0.5f, camera.transform.position.y, delta.z / 0.5f);
            deltas.Add(delta);
        }

    }

    public static void InstantiatePoints(List<Vector3> deltas, Camera camera, GameObject point, List<GameObject> pointsList)
    {
        Vector3 vec = Vector3.zero;
        Quaternion q = new Quaternion(0, 0, 0, 0);
        for(int i=0; i<deltas.Count; i++)
        {
            vec= new Vector3(camera.transform.position.x + deltas[i].x, camera.transform.position.y, camera.transform.position.z + deltas[i].z);
            GameObject gameObject = Instantiate(point, vec , q) as GameObject;
            pointsList.Add(gameObject);
        }
    }

    public static void ClearPoints(List<GameObject> pointsList, List<Vector3> deltas)
    {
        foreach(GameObject gameObject in pointsList)
        {
            Destroy(gameObject);
        }
        pointsList = new List<GameObject>();
        deltas = new List<Vector3>();
    }
    
}
