using UnityEngine;
using System.Collections;
using System.Text;

public class SubmitLayout : MonoBehaviour {
	public Board board;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DoSubmitLayout(){
		StringBuilder sb = new StringBuilder ();
		bool needComma = false;
		sb.AppendFormat ("{{\"pieces\":[");
		for (int x = 0; x < 17; x++) {
			for (int y = 0; y < 17; y++) {
				ChessPiece cp = board.ChessPieceAtXY (x, y);
				if (cp == null)
					continue;
				ChessPiece.enumChessName chessName = cp.GetChessCategory ();
				if (needComma) {
					sb.Append (",");
				}
				needComma = true;
				sb.AppendFormat ("{{\"x\":{0},\"y\":{1},\"pieceName\":\"{2}\",\"pieceInt\":{3}}}", x, y, chessName, (int)chessName);
				//Debug.Log (string.Format ("[{0},{1}]:{2},{3}", x, y, chessName,(int)chessName));
					
			}
		}
		sb.AppendFormat ("]}}");
		Debug.Log (sb);
		NetUtils.Post (string.Format ("{0}/match_save_formation.json", NetUtils.SERVER_NAME ()), sb.ToString());
			
	}
}
