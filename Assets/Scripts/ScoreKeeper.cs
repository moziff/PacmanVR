using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	public int level=0;
	public int score=0;
	public int highscore=0;
	public GameObject prefab;
	public int lives = 2;

	private bool nextLevel;
	private Edibles edibles;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		edibles = FindObjectOfType<Edibles> ();
	}

	// Update is called once per frame
	void Update () {
		if(edibles.RoundOver()){
			level++;
			Destroy (edibles.gameObject);
			Instantiate (prefab);
			highscore = score;
		}
	}

	public void IncrementScore(int value)
	{
		score+=value;
		print("You scored. Your current score is " + score);
	}
}
