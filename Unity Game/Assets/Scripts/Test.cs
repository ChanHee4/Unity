using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private Text ui;
    private float distance;
    public GameObject Player;
    public GameObject test;


    void Start()
    {
        ui = GetComponent<Text>();
                
    }

    void Update()
    {
        /*
        {           
            float x = Player.transform.position.x - test.transform.position.x;
            float y = Player.transform.position.y - test.transform.position.y;

            float distance = Mathf.Sqrt((x * x) + (y * y));
        }
        */

        float distance = Vector3.Distance(
            Player.transform.position, 
            test.transform.position);

        distance = test.transform.position.x;

        ui.text = distance.ToString();

        if (distance > 5.0f)
            test.GetComponent<MyGizmo>().color = Color.green;
        else
            test.GetComponent<MyGizmo>().color = Color.red;
    }
}
