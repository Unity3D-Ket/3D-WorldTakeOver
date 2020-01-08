using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject EnemyDeathFX;
    [SerializeField] Transform parentFxClone;

    [Header("Point System")]
    [SerializeField] int score = 100;
    ScoreBoard scoreBoard;

    [Header("Enemy Health")]
    [SerializeField] int maxHealth = 10;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();

        colliderSettings();
    }

    private void colliderSettings()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    public void OnParticleCollision(GameObject other)
    {
        decreaseHealth();
    }

    private void decreaseHealth()
    {
        maxHealth--;

        if (maxHealth <= 0)
        {
            enemyDeathSequence();
        }
    }

    private void enemyDeathSequence()
    {
        scoreBoard.scoreHit(score);
        GameObject fx = Instantiate(EnemyDeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentFxClone;
        Destroy(gameObject);
    }
}
