using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

	public void LoadNextScene()
	{
		int currentIndex = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (currentIndex + 1);
	}

	public void PlayAgain(){
		SceneManager.LoadScene (0);
	}

	public void Quit(){
		Application.Quit ();
	}

	public void LoadLevel(string name){
		SceneManager.LoadScene (name);
	}
}
