using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrGameOverManager : MonoBehaviour
{
    public int finalScore = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 correspond au clic gauche, 1 droit, 2 milieu
        {
            SceneManager.LoadScene("SampleScene");
        }
        
    }
}
