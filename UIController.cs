using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject Panel;
    public GameObject StartPanel;



    public void OpenMenu()
    {
        Panel.SetActive(true);
    }

    public void CloseMenu()
    {
        Panel.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        StartPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("start") == true)
        {
            StartPanel.SetActive(false);
        }
    }
}
