using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class NewScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void LoadAgain(){


		SceneManager.LoadScene("TOH");
	}
	public void LoadAgain1(){


		SceneManager.LoadScene("TOH2");
	}

	public void Quit(){
		Application.Quit ();
	}

}
