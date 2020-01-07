using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] float lvLoadDelay = 1f;
    [SerializeField] GameObject deathFX;

    public void OnTriggerEnter(Collider other)
    {
		startDeathSequence();
        deathFX.SetActive (true);
        Invoke("reloadScene", lvLoadDelay);
    }

	private void startDeathSequence()
    {
		SendMessage("OnPlayerDeath");
	}

    private void reloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
