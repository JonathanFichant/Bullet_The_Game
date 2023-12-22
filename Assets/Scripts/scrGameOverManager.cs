using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class scrGameOverManager : MonoBehaviour
{
    //private Player playerScript;

    void Start()
    {
        /*// Trouver le joueur pr�serv� dans la nouvelle sc�ne
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            // Acc�der aux variables du joueur
            Player playerScript = playerObject.GetComponent<Player>();

            if (playerScript != null)
            {
                // Utilisez directement la variable playerScore
                int finalScore = playerScript.score;
                Debug.Log("Player Score in new scene: " + finalScore);
            }
        }*/
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
