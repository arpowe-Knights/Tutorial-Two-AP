using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public Text score;

    public TextMeshProUGUI livesText;


    public GameObject winTextObject;
    public GameObject loseTextObject;

    private int scoreValue = 0;

     private int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);

        SetCountText();
    }

    // Update is called once per frame
   
   private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            
            SetCountText ();
        }
        else if (collision.collider.tag == "Enemy")
        {
            lives = lives - 1;

            SetCountText();
        }

    }
     void SetCountText()
	{
        livesText.text = "Lives: " + lives.ToString();
        score.text = "Count: " + scoreValue.ToString();
		if (scoreValue >= 5) 
		{
         // Set the text value of your 'winText'
        winTextObject.SetActive(true);
        }
        else if (lives == 0)
        {
            loseTextObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}