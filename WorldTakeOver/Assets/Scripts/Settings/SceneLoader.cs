using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float LevelDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("loadNextScene", LevelDelay);
    }

    public void loadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
