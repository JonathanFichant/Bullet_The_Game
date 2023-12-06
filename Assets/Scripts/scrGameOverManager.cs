using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class scrGameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private VariableManager variableManager;

    void Start()
    {
        scoreText.text = variableManager.score.ToString();
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
