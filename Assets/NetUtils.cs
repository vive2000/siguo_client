using UnityEngine;
using System.Collections;
using LitJson;
using System.Net;
using System.Text;
using System.IO;

public class NetUtils : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static string SERVER_NAME(){
		return "http://localhost:3000";
	}

	static string cookie="";
	public static string Post(string url, string param){
		Debug.Log ("------------------");
		Debug.Log (string.Format( "POST to {0} with {1}", url, param));
		Encoding encoding = Encoding.UTF8;
		HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create (url);
		req.Method = "POST";
		byte[] bs = encoding.GetBytes (param);
		req.ContentType = "application/json";
		req.ContentLength = bs.Length;
		req.Headers ["cookie"] = cookie;
		req.GetRequestStream ().Write (bs, 0, bs.Length);
		HttpWebResponse res = (HttpWebResponse)req.GetResponse ();
		cookie = res.GetResponseHeader ("Set-Cookie");
		StreamReader sr = new StreamReader (res.GetResponseStream ());
		string result = sr.ReadToEnd ();
		Debug.Log (string.Format("result is {0}",result));
		return result;
	}

	public static string Get(string url){
		Debug.Log ("------------------");
		Debug.Log (string.Format( "GET to {0}", url));
		Encoding encoding = Encoding.UTF8;
		HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create (url);
		req.Method = "GET";
		req.Headers ["cookie"] = cookie;
		HttpWebResponse res = (HttpWebResponse)req.GetResponse ();
		cookie = res.GetResponseHeader ("Set-Cookie");
		StreamReader sr = new StreamReader (res.GetResponseStream ());
		string result = sr.ReadToEnd ();
		Debug.Log (result);
		return result;
	}
}
