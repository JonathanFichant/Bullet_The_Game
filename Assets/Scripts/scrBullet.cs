using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rbBullet;
    public float speed = 12f;
    public GameObject bonus;
    public Player player;
    public TrailRenderer trailRenderer;
    public GameObject ExplosionHexa;
    public GameObject ExplosionSpeeder;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (transform.position.y > 5.2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ennemy")){
            if (other.name.Contains("Hexa"))
            {
                Instantiate(ExplosionHexa, other.gameObject.transform.position, transform.rotation);
            }
            else if (other.name.Contains("Speeder"))
            {
                Instantiate(ExplosionSpeeder, other.gameObject.transform.position, transform.rotation);
            }
            Destroy(other.gameObject); // destruction des objets avec tag Ennemy
            Destroy(gameObject); // destruction de l'objet lui meme
            player.score++; // incrémentation valeur score de l'objet player
            if (Random.Range(0, 100) <= 5) // pourcentage de drop
            {
                Instantiate(bonus, other.gameObject.transform.position, transform.rotation);
            }
        }
    }

    public void SetDirectionAndSpeed(Vector2 direction, float speed, float scaleMultiplier)
    {
        rbBullet.velocity = direction * speed;
        trailRenderer.startWidth *= scaleMultiplier;
        trailRenderer.endWidth *= scaleMultiplier;
    }
}
