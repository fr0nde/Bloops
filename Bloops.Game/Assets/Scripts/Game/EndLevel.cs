using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public Text txtTime;
    public Text txtNbBounce;
    public Text txtNbTry;

    // Start is called before the first frame update
    void Start()
    {
        txtTime.text = $"Durée du niveau {GameInstanceInfo.timer}";
        txtNbBounce.text = $"Nombre de rebond {GameInstanceInfo.nbBounce}";
        txtNbTry.text = $"Nombre de tentatives {GameInstanceInfo.nbTry}";
    }

    public void fermer()
    {
        SceneManager.LoadScene("AventureMenu");
    }
}
