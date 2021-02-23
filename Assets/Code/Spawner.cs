using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Transform spanwpos;
    public GameObject spawnee;
    public Button yourButton;
    private int planets;
    private int cost;
    void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(summon);
        planets = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.HasKey("Score")){
            int money = PlayerPrefs.GetInt("Score");
            int cost = planets * 10;
            if(money > cost){
                yourButton.GetComponent<Button>().interactable = true;
            }else{
                yourButton.GetComponent<Button>().interactable = false;
            }

        }
    }

    void summon() {
        //Create object
        Instantiate(spawnee, spanwpos.position, spanwpos.rotation);

        int cost = planets * 10;

        //Subtract money
        if(PlayerPrefs.HasKey("Score")){
            int score = PlayerPrefs.GetInt("Score");
            PlayerPrefs.SetInt("Score", score - cost);
        }

        //increment planet count
        planets += 1;
        Debug.Log("Planets: " + planets + " Cost: " + cost);
    }
}
