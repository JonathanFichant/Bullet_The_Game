using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrParticleMob : MonoBehaviour
{
    private ParticleSystem particleSystemMob;

    void Start()
    {
        particleSystemMob = GetComponent<ParticleSystem>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
