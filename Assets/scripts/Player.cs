using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public int money;
    public int lives;
    public int leftHand;
    public int rightHand;
    public Text waveText;
    public Text moneyText;
    public Text livesText;
    public Text centerText;
    public Text leftHandText;
    public Text rightHandText;
    public string[] weaponNames = new string[2];
    public static bool playing;
    public GameObject spawner;
    //to do: add controls that let the player aim, move sideways, and use weapons 

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
        waveText.text = "Wave " + spawner.GetComponent<Spawner>().CurrentWave() + " of infinity";
    }

    public void LoseLives(int loss)
    {
        lives -= loss;

        if (lives <= 0)
        {
            playing = false;
            centerText.text = "You lose.";
        }
    }
}