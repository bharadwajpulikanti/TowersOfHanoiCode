using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewButtonClick : MonoBehaviour {

	// Use this for initialization
	public NewTOHScript tohs;
	public bool click1 = false;
	public bool click2 = false;
	public bool click3 = false;
	public bool click4 = false;
	public bool click5 = false;
	public bool click6 = false;
	void Start () {
	}

	// Update is called once per frame
	void Update () {



			if (click2 == true) {
					tohs.transformRing12 ();
				click2 = false;
			}


			else if (click3 == true) {
					tohs.transformRing13 ();
				click3 = false;
			}


			else if (click1 == true) {
					tohs.transformRing21 ();
				click1 = false;
			}

			else if (click4 == true) {
					tohs.transformRing23 ();
				click4 = false;
			}

			else if (click5 == true) {
					tohs.transformRing31 ();
				click5 = false;
			}

			else if (click6 == true) {
					tohs.transformRing32 ();
				click6 = false;
			}

		
	}

	public void OnButtonClick12(){
		click2 = true;
		//Debug.Log ("Click2");
	}
	public void OnButtonClick13(){
		click3 = true;
		//Debug.Log ("Click3");
	}
	public void OnButtonClick21(){
		click1= true;
		//Debug.Log ("Click1");
	}
	public void OnButtonClick23(){
		click4= true;
		//Debug.Log ("Click4");
	}
	public void OnButtonClick31(){
		click5= true;
		//Debug.Log ("Click5");
	}
	public void OnButtonClick32(){
		click6= true;
		//Debug.Log ("Click6");
	}
}
