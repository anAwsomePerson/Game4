using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public int money;
    public int lives;
    public int leftHand;
    public int rightHand;
    public Text moneyText;
    public Text livesText;
    public Text centerText;
    public Text leftHandText;
    public Text rightHandText;
    public string[] weaponNames = new string[2];
    public static bool playing;

	// Use this for initialization
	void Start () {
        playing = true;
        leftHandText.text = weaponNames[leftHand];
        rightHandText.text = weaponNames[rightHand];
        centerText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        moneyText.text = "Money: " + money.ToString();
        livesText.text = "Lives: " + lives.ToString();
	}

    public void LoseLives(int loss)
    {
        lives -= loss;

        if(lives <= 0)
        {
            playing = false;
            centerText.text = "You lose.";
        }
    }
}