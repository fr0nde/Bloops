using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AventureMenu : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        updateButtons();
    }
    List<GameObject> getAllLevelButtons()
    {
        List<GameObject> gamelevels = go.GetAllChilds();

        List<GameObject> buttons = new List<GameObject>();

        foreach (GameObject gamelevel in gamelevels)
        {
            List<GameObject> childs = gamelevel.GetAllChilds();

            foreach (var child in childs)
            {
                if (child.tag == "Level_Button")
                {
                    buttons.Add(child);
                }
            }
        }

        buttons.Sort(delegate (GameObject x, GameObject y)
        {
            int levelX = Int32.Parse(x.GetComponentInChildren<Text>().text);
            int levelY = Int32.Parse(x.GetComponentInChildren<Text>().text);
            if (levelX == levelY) return 0;
            if (levelX > levelY) return 1;
            return -1;
        });
        return buttons;
    }

    void updateButton(GameObject button)
    {
        bool isAvailable;
        Player p = PlayerManager.getPlayer();

        Text text = button.GetComponentInChildren<Text>();

        isAvailable = p.levelIsAvailable(text.text);

        // pour la démo on débloque tout, à revoir plus tard
        /*if (isAvailable)
        {*/
            var level = p.getLevel(text.text);
            Image image = button.GetComponentInChildren<Image>();
            loadLevelSkin(image, level);
            button.GetComponent<Button>().interactable = true;
        /*}*/
    }

    void updateButtons()
    {
        List<GameObject> buttons = getAllLevelButtons();
        foreach (GameObject button in buttons)
        {
            updateButton(button);
        }
    }

    void loadLevelSkin(Image image, LevelData level)
    {
        string path;
        if (level is null)
        {
            path = "Menu/level";
        }
        else
        {
            path = $"Menu/level-{level.stars}s";
        }

        Sprite skinTexture = Resources.Load<Sprite>(path);
        image.sprite = skinTexture;
    }

    // Update is called once per frame
    void Update()
    {
        updateButtons();
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void resetLevels()
    {
        PlayerManager.getPlayer().resetLevels();
        //updateButtons();
    }

    public void unlockLevels()
    {
        PlayerManager.getPlayer().unlockLevels();
        //updateButtons();
    }
}


public static class ClassExtension
{
    public static List<GameObject> GetAllChilds(this GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
}