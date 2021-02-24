using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DM = DataManagement;

public class Spawner : MonoBehaviour
{
    public Transform spanwpos;
    public GameObject spawnee;
    public Button yourButton;
    void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(buttonCommand);
	}

    // Update is called once per frame
    void Update()
    {
        float cost = DM.getPlanets() * 10;
        float money = DM.getMoney();
        if(money >= cost){
            yourButton.GetComponent<Button>().interactable = true;
        }else{
            yourButton.GetComponent<Button>().interactable = false;
        }
    }

    void buttonCommand(){
        //Create Planet
        summon();

        //Charge money
        float cost = DM.getPlanets() * 10.0f;

        DM.setMoney(DM.getMoney() - cost);

        //Increment the planets
        DM.setPlanets(DM.getPlanets() + 1);

        Debug.Log("Planets: " + DM.getPlanets() + " Cost: " + cost);

    }
    void summon() {
        //Create object
        Instantiate(spawnee, spanwpos.position, spanwpos.rotation);
    }
}
