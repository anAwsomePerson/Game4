using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paperwork : MonoBehaviour {
    //to do: figure out why I can't figure out how to assign game objects to the game object variables 
    public float difficultyPoints;
    public float speed;
    public float baseHealth;
    float health;
    GameObject spawner;
    GameObject goalGO;
    GameObject player;

	// Use this for initialization
	void Start () {
        health = baseHealth * spawner.GetComponent<Spawner>().CurrentWave() * 2 + 1;
        float distance = Mathf.Infinity;
    }

    // Update is called once per frame
    void Update()
    {
            /*Debug.Log(pathNodeIndex);
             to do: make some papers not move in a line */
        Vector3 dir = goalGO.transform.position - this.transform.localPosition;
        float distThisFrame = speed * Time.deltaTime * 7 / 6;

        if (dir.magnitude <= distThisFrame)
        {
            player.GetComponent<Player>().LoseLives(difficultyPoints);
            Destroy(gameObject);
        }

        transform.Translate(dir.normalized * distThisFrame, Space.World);
                    //this.transform.rotation = Quaternion.LookRotation(dir);
    }

    public void Set(GameObject inSpawner, GameObject inGoal, GameObject inPlayer)
    {
        spawner = inSpawner;
        goalGO = inGoal;
        player = inPlayer;
    }
}
