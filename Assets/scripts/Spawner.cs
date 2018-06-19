using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    bool duringWave;
    //public float wavelength;
    public float intermission;
    public float spawnCD;
    float timer;
    float spawnCDRemaining;
    int currentWave;
    float difficultyPoints;
    public GameObject player;
    public GameObject goal;
    public GameObject[] paperworkTypes = new GameObject[1];

	// Use this for initialization
	void Start () {
        duringWave = false;
        timer = intermission;
	}
	
	// Update is called once per frame
	void Update () {
        if(duringWave)
        {
            spawnCDRemaining -= Time.deltaTime;

            if ((GameObject.FindObjectsOfType<Paperwork>().Length <= 0) && (difficultyPoints <= 0))
            {
                duringWave = false;
                timer = intermission;
                currentWave++;
            }

            if((spawnCDRemaining <= 0) && (difficultyPoints > 0))
            {
                /*to do: spawn papers in random spots and not just at the spawner. 
                 * Also there will eventually be dice rolls determining what kinds of paper get spawned, 
                 * with chances depending on wave number, but right now there's only 1 kind of paper. */
                spawnCDRemaining = spawnCD;
                ((GameObject)Instantiate(paperworkTypes[0], transform.position, transform.rotation)).GetComponent<Paperwork>().Set(gameObject, goal, player);
                difficultyPoints -= paperworkTypes[0].GetComponent<Paperwork>().difficultyPoints;
                //Debug.Log(GameObject.FindObjectsOfType<Paperwork>().Length + " " + difficultyPoints);
            }
        }
        else
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                duringWave = true;
                timer = intermission;
                difficultyPoints = 4 * currentWave + 8;
            }
        }
	}

    public int CurrentWave()
    {
        return (currentWave);
    }
}
