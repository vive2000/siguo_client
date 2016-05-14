using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Net;
using System.Text;
using System.IO;

public class LoginScript : MonoBehaviour {
    public InputField nameInput;
    public InputField passwordInput;
    public Canvas loginCanvas;
    public Canvas playCanvas;
    public Text infoText;

	public static string cookie;

	// Use this for initialization
	void Start () {
		nameInput.text = "bc";
		passwordInput.text = "12345";
//		Debug.Log(string.Format ("{0}ucenter.json", NetUtils.SERVER_NAME ()));
		Login ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator StartLogin()
    {	
		string loginResult=NetUtils.Post (string.Format ("{0}/ucenter.json", NetUtils.SERVER_NAME()),
//			"{name:\"bc\",password:\"12345\"}"
			string.Format ("{{\"name\":\"{0}\",\"password\":\"{1}\"}}",nameInput.text, passwordInput.text)
		);

        JsonData jd = JsonMapper.ToObject(loginResult);
        
        Debug.Log(jd);
        Debug.Log(jd["success"]);
        if (jd["success"].Equals(true))
        {
            iTween.RotateBy(loginCanvas.transform.FindChild("Panel").gameObject, iTween.Hash("y", .25, "easeType", "easeInOutExpo", "delay", 0, "time", 1));
            yield return new WaitForSeconds(1f);
            loginCanvas.targetDisplay = 1;
            playCanvas.targetDisplay = 0;
            //yield return new WaitForEndOfFrame();
            Debug.Log("playCanvas:" + playCanvas);
            Debug.Log("playCanvas.Panel：" + playCanvas.transform.FindChild("Panel"));
            playCanvas.transform.FindChild("Panel").Rotate(new Vector3(0, 90f, 0));
			playCanvas.transform.FindChild ("Panel").localPosition = Vector3.zero;
            iTween.RotateTo(playCanvas.transform.FindChild("Panel").gameObject, iTween.Hash("y", 0, "easeType", "easeInOutExpo", "delay", 0, "time", 1));

            yield return new WaitForSeconds(1f);
			playCanvas.GetComponentInChildren<MainPage> ().LoadData ();
			//playCanvas.GetComponentInChildren<Board> ().SetToDistributionView ();
        }
        else
        {
            iTween.ShakeRotation(loginCanvas.transform.FindChild("Panel").gameObject, iTween.Hash("x", 90f,"easeType", "easeInOutExpo","delay", 0,"time",0.5));
            Debug.Log("用户名或密码错误");
            string oldText = infoText.text;
            infoText.text = "用户名或密码错误";
            infoText.color = Color.red;
            iTween.ShakePosition(infoText.gameObject, iTween.Hash("x", 5, "y", 0, "z", 0, "easeType", "easeInOutExpo", "time",0.5));
            yield return new WaitForSeconds(2);
            infoText.text = oldText;
            infoText.color = Color.black;
        }
    }
    public void Login()
    {
        StartCoroutine("StartLogin");
    }

}
