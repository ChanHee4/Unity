using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject Parent;
    
    private string EnemyName = "Enemy";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(PrefabManager.GetInstance.getPrefabByName("EnemyName")).transform.SetParent(Parent.transform);
        }
    }
}
