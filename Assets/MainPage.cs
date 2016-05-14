using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainPage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadData(){
		StartCoroutine ("StartLoadData");	
	}
	IEnumerator StartLoadData(){
		yield return new WaitForSeconds (0.1f);
		NetUtils.Get(string.Format("{0}/matchesList.json",NetUtils.SERVER_NAME()));
	}
}
