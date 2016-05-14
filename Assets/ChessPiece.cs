using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChessPiece : MonoBehaviour {
	public enum enumChessName{
		SI_LING		=40,
		JUN_ZHANG	=39,
		SHI_ZHANG	=38,
		LV_ZHANG	=37,
		TUAN_ZHANG	=36,
		YING_ZHANG	=35,
		LIAN_ZHANG	=34,
		PAI_ZHANG	=33,
		GONG_BING	=32,
		DI_LEI		=31,
		ZHA_DAN		=30,
		JUN_QI		=29,

		HUANG_SI_LING	=140,
		HUANG_JUN_ZHANG	=139,
		HUANG_SHI_ZHANG	=138,
		HUANG_LV_ZHANG	=137,
		HUANG_TUAN_ZHANG=136,
		HUANG_YING_ZHANG=135,
		HUANG_LIAN_ZHANG=134,
		HUANG_PAI_ZHANG	=133,
		HUANG_GONG_BING	=132,
		HUANG_DI_LEI	=131,
		HUANG_ZHA_DAN	=130,
		HUANG_JUN_QI	=129,
		HUANG_UNKNOWN	=100,

		LV_SI_LING		=240,
		LV_JUN_ZHANG	=239,
		LV_SHI_ZHANG	=238,
		LV_LV_ZHANG		=237,
		LV_TUAN_ZHANG	=236,
		LV_YING_ZHANG	=235,
		LV_LIAN_ZHANG	=234,
		LV_PAI_ZHANG	=233,
		LV_GONG_BING	=232,
		LV_DI_LEI		=231,
		LV_ZHA_DAN		=230,
		LV_JUN_QI		=229,
		LV_UNKNOWN		=200,

		LAN_SI_LING	=340,
		LAN_JUN_ZHANG	=339,
		LAN_SHI_ZHANG	=338,
		LAN_LV_ZHANG	=337,
		LAN_TUAN_ZHANG=336,
		LAN_YING_ZHANG=335,
		LAN_LIAN_ZHANG=334,
		LAN_PAI_ZHANG	=333,
		LAN_GONG_BING	=332,
		LAN_DI_LEI	=331,
		LAN_ZHA_DAN	=330,
		LAN_JUN_QI	=329,
		LAN_UNKNOWN	=300,

		ZI_SI_LING	=440,
		ZI_JUN_ZHANG	=439,
		ZI_SHI_ZHANG	=438,
		ZI_LV_ZHANG	=437,
		ZI_TUAN_ZHANG=436,
		ZI_YING_ZHANG=435,
		ZI_LIAN_ZHANG=434,
		ZI_PAI_ZHANG	=433,
		ZI_GONG_BING	=432,
		ZI_DI_LEI	=431,
		ZI_ZHA_DAN	=430,
		ZI_JUN_QI	=429,
		ZI_UNKNOWN	=400
	}

	public Board board;
	public int ix, iy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SelectPiece(){
		if (side != board.mySide)
			return;
		if (board.selectedPiece == null) {
			board.selectedPiece = this;
			iTween.ShakeScale (this.gameObject, iTween.Hash ("x", 0.1, "y", 0.1, "easeType", "linear", "delay", 0, "time", 20, "loopType", "pingPong"));
		} else {
			iTween.Stop ();
			SwapPieceWithAnimation (board.selectedPiece, this);
			board.selectedPiece = null;
		}
	}

	public void SwapPieceWithAnimation(ChessPiece cp1,ChessPiece cp2){
		Vector3 p1 = cp1.transform.position;
		Vector3 p2 = cp2.transform.position;
		iTween.MoveTo (cp1.gameObject, p2, 0.5f);
		iTween.MoveTo (cp2.gameObject, p1, 0.5f);
		SwapPieceData (cp1, cp2);
	}

	public void SwapPieceData(ChessPiece cp1,ChessPiece cp2){
		int ix3 = cp1.ix;
		int iy3 = cp1.iy;
		cp1.ix = cp2.ix;
		cp1.iy = cp2.iy;
		cp2.ix = ix3;
		cp2.iy = iy3;
		cp1.UpdatePositionInBoard ();
		cp2.UpdatePositionInBoard ();

	}
		
	void UpdatePositionInBoard(){
		board.UpdateMatrixFromPiece (this);
	}

	int side=0;
	enumChessName chessCategory;
	string chessName;
	public enumChessName GetChessCategory(){
		return chessCategory;
	}
	public void SetChessWithInt(int chess){
		side = chess / 100;
		chessCategory = ((enumChessName)chess);
		if (side == board.mySide) {
			chessName = ((enumChessName)chess).ToString ();
			this.GetComponentInChildren<RawImage> ().texture = Resources.Load<Texture2D> (chessName);
		} else {
			chess = chess / 100 * 100;
			chessName = ((enumChessName)chess).ToString ();
			this.GetComponentInChildren<RawImage> ().texture = Resources.Load<Texture2D> (chessName);
		}
	}

	public void SetBoardAndPosition(Board _board,int _ix,int _iy){
		board = _board;
		this.transform.SetParent(board.transform);
		ix = _ix;
		iy = _iy;
		transform.localPosition = VectorFromXY(ix,iy);
		board.UpdateMatrixFromPiece (this);

	}
	Vector3 VectorFromXY(int x,int y){
		int x1 = y;
		int y1 = 18-x;
		return new Vector3 ((x1 - 0.5f) * board.cellWidth, (y1 - 0.5f) * board.cellHeight, 0);
	}
}
