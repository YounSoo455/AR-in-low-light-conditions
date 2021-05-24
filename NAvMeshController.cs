using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NAvMeshController : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public GameObject player;
    public GameObject point;
    public GameObject line;

    public GameObject finishRoom1;
    public GameObject finishRoom2;
    public GameObject finishRoom3;
    public GameObject finishRoom4;

    public float distance = 1;
    public float height = 0.01f;

    private List<GameObject> points;
    private Vector3 agentPOint;
    private Vector3 lastPOint;
    private List<GameObject> lines;

    private List<GameObject> pointsOnScene;
    public Camera camera;
    private List<Vector3> deltas;
    public GameObject pointSphere;


    private void Awake()
    {
        navMeshAgent.transform.position = player.transform.position;
        points = new List<GameObject>();
        lines = new List<GameObject>();
        pointsOnScene = new List<GameObject>();
        deltas = new List<Vector3>();
        
    }

    public void Clear()
    {
        foreach(GameObject obj in points)
        {
            Destroy(obj);
        }
        foreach (GameObject obj in lines)
        {
            Destroy(obj);
        }
       
        points = new List<GameObject>();
        lines = new List<GameObject>();

        foreach(GameObject obj in pointsOnScene)
        {
            Destroy(obj);
        }
        
        pointsOnScene = new List<GameObject>();
        deltas = new List<Vector3>();
    }

    bool  Check(Vector3 distancePath)
    {
        bool result = false;
        float dis = Vector3.Distance(lastPOint, distancePath);
        if (dis > distance)
        result = true;
        lastPOint = distancePath;
        return result;
        
    }

    void UpdatePath()
    {

        lastPOint = navMeshAgent.transform.position + Vector3.forward ; // чтобы создать точку в текущей позиции

        Clear();

        for (int j = 0; j < navMeshAgent.path.corners.Length; j++)
        {
            if (Check(navMeshAgent.path.corners[j]))
            {
                GameObject p = Instantiate(point) as GameObject;
                p.transform.position = navMeshAgent.path.corners[j] + Vector3.up * height; // создаем точку и корректируем позицию 
                points.Add(p);

            }
        }

        for (int j = 0; j < points.Count; j++)
        {
            if (j + 1 < points.Count)
            {
                Vector3 center = (points[j].transform.position + points[j + 1].transform.position) / 2; // находим центр между точками
                Vector3 vector = points[j].transform.position - points[j + 1].transform.position; // находим вектор от точки А, к точке Б
                float distance = Vector3.Distance(points[j].transform.position, points[j + 1].transform.position); // находим дистанцию между А и Б

                GameObject l = Instantiate(line) as GameObject;
                l.transform.position = center - Vector3.up * height;
                l.transform.rotation = Quaternion.FromToRotation(Vector3.right, vector.normalized); // разворот по вектору
                l.transform.localScale = new Vector3(distance, 1, 1); // растягиваем по Х
                lines.Add(l);
            }
        }

        DisplayWayOnScene.GetDeltas(points, camera, deltas);
        DisplayWayOnScene.InstantiatePoints(deltas, camera, pointSphere, points);
    }
        

    private void Start()
    {
        
    }

    public void GetWayRoom1()
    {
        navMeshAgent.transform.position = player.transform.position;
        navMeshAgent.SetDestination(finishRoom1.transform.position);

        UpdatePath();
    }

    public void GetWayRoom2()
    {
        
        navMeshAgent.transform.position = player.transform.position;
        navMeshAgent.SetDestination(finishRoom2.transform.position);

        UpdatePath();

        
    }

    public void GetWayRoom3()
    {
        navMeshAgent.transform.position = player.transform.position;
        navMeshAgent.SetDestination(finishRoom3.transform.position);

        UpdatePath();
    }

    public void GetWayRoom4()
    {
        navMeshAgent.transform.position = player.transform.position;
        navMeshAgent.SetDestination(finishRoom4.transform.position);

        UpdatePath();
    }
    
}
