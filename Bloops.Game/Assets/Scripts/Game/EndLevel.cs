using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public Text txtLevel;
    public Text nbTime;
    public Text nbNbBounce;
    public Text nbNbTry;

    // Start is called before the first frame update
    void Start()
    {
        pushValidateLevel();

        txtLevel.text = $"Niveau : {GameSceneInfo.level}";
        nbTime.text = $"{Mathf.Round(GameInstanceInfo.timer).ToString()} secondes";
        nbNbBounce.text = $"{GameInstanceInfo.nbBounce}";
        nbNbTry.text = $"{GameInstanceInfo.nbTry}";


    }
    void pushValidateLevel()
    {
        Player p = PlayerManager.getPlayer();
        LevelData ld = new LevelData();
        ld.level = GameSceneInfo.level.ToString();
        ld.stars = 5; // TODO FAIRE UN CALCUL INTELLIGENT DES REGLES POUR AVOIR LE NOMBRE DE STARS
        p.addLevel(ld);
    }

    public void fermer()
    {
        SceneManager.LoadScene("AventureMenu");
    }
}
