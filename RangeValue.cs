using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public  class RangeValue : MonoBehaviour {

	// Use this for initialization
	public  Slider slider;
	  public   static int range;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		range = (int)slider.value;
	}
}
