using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Transform spanwpos;
    public GameObject spawnee;

    public Button yourButton;

    void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(summon);
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(2)) {
            summon();
        }
    }

    void summon() {
        Instantiate(spawnee, spanwpos.position, spanwpos.rotation);
    }
}
