using UnityEngine;
using System.Collections;

public class QuickMatch : MonoBehaviour {
	public Canvas mainCanvas;
	public Canvas playCanvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RequestAMatch(){
		StartCoroutine ("RequestAMatchCoroutine");
	}
	IEnumerator RequestAMatchCoroutine(){
		NetUtils.Get (string.Format ("{0}/giveMeOneMatch.json",NetUtils.SERVER_NAME()));
		iTween.RotateBy(mainCanvas.transform.FindChild("Panel").gameObject, iTween.Hash("y", .25, "easeType", "easeInOutExpo", "delay", 0, "time", 1));
		yield return new WaitForSeconds(1f);
		mainCanvas.targetDisplay = 1;
		playCanvas.targetDisplay = 0;
		//yield return new WaitForEndOfFrame();
		Debug.Log("playCanvas:" + playCanvas);
		Debug.Log("playCanvas.Panel：" + playCanvas.transform.FindChild("Panel"));
		playCanvas.transform.FindChild("Panel").Rotate(new Vector3(0, 90f, 0));
		playCanvas.transform.FindChild ("Panel").localPosition = Vector3.zero;
		iTween.RotateTo(playCanvas.transform.FindChild("Panel").gameObject, iTween.Hash("y", 0, "easeType", "easeInOutExpo", "delay", 0, "time", 1));

		yield return new WaitForSeconds(1f);
		//playCanvas.GetComponentInChildren<Board> ().SetToDistributionView ();

	}
}
