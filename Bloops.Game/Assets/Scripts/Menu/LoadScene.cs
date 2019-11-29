using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Text infoText;
    // Start is called before the first frame update
    void Start()
    {
        setInfoText();
        invokeFunction();
    }

    void invokeFunction()
    {
        // On à une valeur par défault de 2 secondes de chargement
        int timer = LoadSceneInfo.timer == null ? 2 : int.Parse(LoadSceneInfo.timer);
        Invoke("loadScene", timer);
    }

    void setInfoText()
    {
        // Ce n'est pas obligatoire
        infoText.text = LoadSceneInfo.infoText;
    }

    void loadScene()
    {
        // Par défault on lance le Menu
        string scene = LoadSceneInfo.nextScene == null ? "Menu" : LoadSceneInfo.nextScene;
        SceneManager.LoadScene(scene);
    }

    void OnDestroy()
    {
        // On réinitialise toutes les infos après avoir lancée la scène qui va bien
        LoadSceneInfo.startScene = null;
        LoadSceneInfo.nextScene = null;
        LoadSceneInfo.infoText = null;
        LoadSceneInfo.timer = null;
    }
}
