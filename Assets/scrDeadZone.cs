using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDeadZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Détruit l'objet qui entre en collision.
        Destroy(other.gameObject);
    }
}
