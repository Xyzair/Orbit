using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DM = DataManagement;


public class Score : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string moneyString = "Money: " + DM.getMoney();
        scoreText.text = moneyString;
        //Debug.Log("Changed " + moneyString, scoreText);
    }
}
