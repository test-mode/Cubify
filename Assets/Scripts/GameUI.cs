using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    public Text healthUI;

    void Start()
    {

    }
 
    void Update()
    {
        healthUI.text = GameObject.Find("player").GetComponent<Player>().playerHealth.ToString();
    }

}