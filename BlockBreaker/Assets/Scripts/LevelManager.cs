using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel(name);
	}
	
	public void Quit (){
		Debug.Log ("Game Quit");
		Application.Quit ();
	}
	
	public void Win (string name){
		Debug.Log ("Game Won!");
		Application.LoadLevel (name);
	}

    public void LoadNextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void BrickDestroyed () {
        if (SpriteChanging.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
