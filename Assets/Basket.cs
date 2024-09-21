using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    static private Text     ScoreText;
    public int lastLevel;
    public static int level;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find( "ScoreCounter" );

        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter( Collision coll ) {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if ( collidedWith.CompareTag("Apple" )) {
            Destroy( collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE( scoreCounter.score );
            level = scoreCounter.score % 1000;
            if (level == 0 ) {
                AppleTree.appleDropDelay = AppleTree.appleDropDelay - (float)(0.01*(((scoreCounter.score/1000)+1)));
                RoundText.round = (scoreCounter.score/1000) + 1;
            }
        }else if ( collidedWith.CompareTag("Branch" )) {
            Destroy( collidedWith);
            HighScore.TRY_SET_HIGH_SCORE( scoreCounter.score );
            SceneManager.LoadScene( "End_Menu");
            }
        }
        
    }

