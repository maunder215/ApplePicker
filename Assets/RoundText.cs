using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundText : MonoBehaviour
{
    public static int round;
    static private Text     _UI_TEXT;

    void Start() {
        _UI_TEXT = GetComponent<Text>();
        round = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if ( round == 5 ){
            SceneManager.LoadScene( "End_Menu");
        }
        _UI_TEXT.text = "Round: " + round.ToString("#,0");
    }
}
