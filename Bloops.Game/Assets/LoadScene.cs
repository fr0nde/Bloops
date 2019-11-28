using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("loadScene", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
