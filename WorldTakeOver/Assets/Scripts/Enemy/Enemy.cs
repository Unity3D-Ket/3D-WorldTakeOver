using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject EnemyDeathFX;
    [SerializeField] Transform parentFxClone;

    private void Start()
    {
        colliderSettings();
    }

    private void colliderSettings()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    public void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(EnemyDeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentFxClone;
        Destroy(gameObject);
    }
}
