using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void OnParticleCollision(GameObject other)
    {
        //print("Particle Collisided with "+ gameObject.name);
        Destroy(gameObject);
    }
}
