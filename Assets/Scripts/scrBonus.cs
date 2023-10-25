using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBonus : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        monRigidBody.velocity = Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
