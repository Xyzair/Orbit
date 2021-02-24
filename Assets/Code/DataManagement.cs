using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManagement: MonoBehaviour
{
    public static float getMoney(){
        if(PlayerPrefs.HasKey("Money")){
            return PlayerPrefs.GetFloat("Money");
        }else {
            return 0.0f;
        }
    }

    public static void setMoney(float amt){
        PlayerPrefs.SetFloat("Money", amt);
    }

    public static int getPlanets(){
        if(PlayerPrefs.HasKey("Planets")){
            return PlayerPrefs.GetInt("Planets");
        }else {
            return 0;
        }
    }

    public static void setPlanets(int amt){
        PlayerPrefs.SetInt("Planets", amt);
    }
}
