using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class scrGameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public VariableManager variableManager;

    void Start()
    {
        variableManager = FindObjectOfType<VariableManager>();
        scoreText.text = "Score : " + variableManager.score.ToString();
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
