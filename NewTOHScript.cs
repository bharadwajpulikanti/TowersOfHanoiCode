using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class NewTOHScript : MonoBehaviour {

	// Use this for initialization
	 
	public Stack<GameObject> s1 = new Stack<GameObject> ();
	public Stack<GameObject> s2 = new Stack<GameObject> ();
	public Stack<GameObject> s3 = new Stack<GameObject> ();

	public static RangeValue rangeValue;
	public GameObject r1;
	public GameObject r2;
	public GameObject r3;
	public GameObject r4;
	public GameObject r5;

	private float cX = 0f;
	private float lX = -6.5f;
	private float rX = 6.5f;

	int s1Len = 0;
	int s2Len = 0;
	int s3Len = 0;

	private  float cRingPos;
	private  float rRingPos;
	private  float lRingPos;


	public Rect rect = new Rect();

	public Text alertText;


	public bool rc3 = false;
	public bool rc4 = false;
	public bool rc5 = false;
	void Start () {

		Debug.Log("Range is "+RangeValue.range);

		if (RangeValue.range == 3) {
			rc3 = true;

		

			r5.SetActive (false);
			r4.SetActive (false);
			r3.transform.position = new Vector3 (lX, 3.75f, 0);
			r2.transform.position = new Vector3 (lX, 4.5f, 0);
			r1.transform.position = new Vector3 (lX, 5.25f, 0);

			//s1.Push (r5);
			//s1.Push (r4);
			s1.Push (r3);
			s1.Push (r2);
			s1.Push (r1);
		}

		else if (RangeValue.range == 4) {
			rc4 = true;



			r5.SetActive (false);
			r4.transform.position = new Vector3 (lX, 3.75f, 0);
			r3.transform.position = new Vector3 (lX, 4.5f, 0);
			r2.transform.position = new Vector3 (lX, 5.25f, 0);
			r1.transform.position = new Vector3 (lX, 6.0f, 0);

			//s1.Push (r5);
			s1.Push (r4);
			s1.Push (r3);
			s1.Push (r2);
			s1.Push (r1);
		}
		else if (RangeValue.range == 5) {
			rc5 = true;



			r5.transform.position = new Vector3 (lX, 3.75f, 0);
			r4.transform.position = new Vector3 (lX, 4.5f, 0);
			r3.transform.position = new Vector3 (lX, 5.25f, 0);
			r2.transform.position = new Vector3 (lX, 6.0f, 0);
			r1.transform.position = new Vector3 (lX, 6.75f, 0);

			s1.Push (r5);
			s1.Push (r4);
			s1.Push (r3);
			s1.Push (r2);
			s1.Push (r1);
		}


	}
	
	// Update is called once per frame
	void Update () {

		if (s3.Count == 3 && rc3 == true) {
			
			rc3 = false;
			StartCoroutine (Text1 ());
		}

		else if (s3.Count == 4 && rc4 == true) {

			rc4 = false;
			StartCoroutine (Text1 ());
		}	
		else if (s3.Count == 5 && rc5 == true) {

			rc5 = false;
			StartCoroutine (Text1 ());
		}
	}
	 
	IEnumerator Text(){
		yield return new WaitForSeconds (1);
		alertText.enabled = false;
	}

	IEnumerator Text1(){
		
		yield return new WaitForSeconds (2);

		LoadAgain1 ();

	}



	public void LoadAgain1(){


		SceneManager.LoadScene("TOH1");
	}


	public float RingCPos(){
		s2Len = s2.Count;
		cRingPos = (float)(3.75 + (s2Len * 0.75));
		//Debug.Log ("cRingPos -> " + cRingPos);
		return cRingPos;
	}
	public float RingRPos(){
		s3Len = s3.Count;
		rRingPos = (float)(3.75 + (s3Len * 0.75));

		return rRingPos;
	}
	public float RingLPos(){
		s1Len = s1.Count;
		lRingPos = (float)(3.75 + (s1Len * 0.75));
	
		return lRingPos;
	}


	public  void transformRing12(){

		if(s1.Count != 0){				
			if(s2.Count == 0){
				s1.Peek().transform.position = new Vector3 (cX, RingCPos (), 0);
				s2.Push(s1.Peek());
				s1.Pop();

			}
			else{
			//	Debug.Log ("Length of top s1 object is " + s1.Peek ().transform.localScale.x);
				
				if(s1.Peek().transform.localScale.x<s2.Peek().transform.localScale.x){
					s1.Peek().transform.position = new Vector3 (cX, RingCPos (), 0);
					s2.Push(s1.Peek());
					s1.Pop();
				}
				else{
					alertText.enabled = true;

					StartCoroutine (Text ());


					Debug.Log ("Wrong Move");
				}

			}

		}

	}

	public  void transformRing13(){

		if(s1.Count != 0){				
			if(s3.Count == 0){
				s1.Peek().transform.position = new Vector3 (rX, RingRPos (), 0);
				s3.Push(s1.Peek());
				s1.Pop();

			}
			else{
			//	Debug.Log ("Length of top s1 object is " + s1.Peek ().transform.localScale.x);

				if(s1.Peek().transform.localScale.x<s3.Peek().transform.localScale.x){
				s1.Peek().transform.position = new Vector3 (rX, RingRPos (), 0);
				s3.Push(s1.Peek());
				s1.Pop();
				}
				else{
					alertText.enabled = true;

					StartCoroutine (Text ());
					Debug.Log ("Wrong Move");
				}

			}

		}

	}


	public  void transformRing21(){

		if(s2.Count != 0){				
			if(s1.Count == 0){
				s2.Peek().transform.position = new Vector3 (lX, RingLPos (), 0);
				s1.Push(s2.Peek());
				s2.Pop();

			}
			else{
			//	Debug.Log ("Length of top s2 object is " + s2.Peek ().transform.localScale.x);

				if(s2.Peek().transform.localScale.x<s1.Peek().transform.localScale.x){
				s2.Peek().transform.position = new Vector3 (lX, RingLPos (), 0);
				s1.Push(s2.Peek());
				s2.Pop();
				}
				else{
					alertText.enabled = true;

					StartCoroutine (Text ());
					Debug.Log ("Wrong Move");
				}

			}

		}

	}


	public  void transformRing23(){

		if(s2.Count != 0){				
			if(s3.Count == 0){
				s2.Peek().transform.position = new Vector3 (rX, RingRPos (), 0);
				s3.Push(s2.Peek());
				s2.Pop();

			}
			else{
			//	Debug.Log ("Length of top s2 object is " + s2.Peek ().transform.localScale.x);

				if(s2.Peek().transform.localScale.x<s3.Peek().transform.localScale.x){
				s2.Peek().transform.position = new Vector3 (rX, RingRPos (), 0);
				s3.Push(s2.Peek());
				s2.Pop();
				}
				else{
					alertText.enabled = true;

					StartCoroutine (Text ());
					Debug.Log ("Wrong Move");
				}
			}

		}

	}

	public  void transformRing31(){

		if(s3.Count != 0){				
			if(s1.Count == 0){
				s3.Peek().transform.position = new Vector3 (lX, RingLPos (), 0);
				s1.Push(s3.Peek());
				s3.Pop();

			}
			else{
			//	Debug.Log ("Length of top s2 object is " + s3.Peek ().transform.localScale.x);

				if(s3.Peek().transform.localScale.x<s1.Peek().transform.localScale.x){
				s3.Peek().transform.position = new Vector3 (lX, RingLPos (), 0);
				s1.Push(s3.Peek());
				s3.Pop();
				}
				else{
					alertText.enabled = true;

					StartCoroutine (Text ());
					Debug.Log ("Wrong Move");
				}

			}

		}

	}

	public  void transformRing32(){

		if(s3.Count != 0){				
			if(s2.Count == 0){
				s3.Peek().transform.position = new Vector3 (cX, RingCPos (), 0);
				s2.Push(s3.Peek());
				s3.Pop();

			}
			else{
			//	Debug.Log ("Length of top s2 object is " + s3.Peek ().transform.localScale.x);

				if(s3.Peek().transform.localScale.x<s2.Peek().transform.localScale.x){
				s3.Peek().transform.position = new Vector3 (cX, RingCPos (), 0);
				s2.Push(s3.Peek());
				s3.Pop();
				}
				else{
					alertText.enabled = true;

					StartCoroutine (Text ());
					Debug.Log ("Wrong Move");
			}

		}

	}

}
}