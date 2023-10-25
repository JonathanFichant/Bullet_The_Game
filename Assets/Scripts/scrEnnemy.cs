using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public Player player;
    public float speedMob;
    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        speedMob = 0.2f;
        dead = false;
        player = FindObjectOfType<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down*speedMob * Time.deltaTime;
        if (transform.position.y < -5.5 && !dead)
        {
            dead = true;
            player.life--;
        }
    }
}
