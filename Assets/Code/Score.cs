using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private string moneyString;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Score"))
            PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("Score")){
            moneyString = "Money: " + PlayerPrefs.GetInt("Score");
            scoreText.text = moneyString;
            //Debug.Log("Changed " + moneyString, scoreText);
        }
    }
}
