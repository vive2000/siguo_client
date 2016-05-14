using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;


public class Board : MonoBehaviour
{

	ChessPiece [,] matrix;

	int[,]  originMatrix={
		{-1,  -1, -1, -1, -1, -1, -1,  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},

		{-1,  -1, -1, -1, -1, -1, -1, 331,329,331,333,333, -1, -1, -1, -1, -1, -1, -1},
		{-1,  -1, -1, -1, -1, -1, -1, 339,330,330,332,334, -1, -1, -1, -1, -1, -1, -1},
		{-1,  -1, -1, -1, -1, -1, -1, 338, -1,337, -1,336, -1, -1, -1, -1, -1, -1, -1},
		{-1,  -1, -1, -1, -1, -1, -1, 334,335, -1,335,334, -1, -1, -1, -1, -1, -1, -1},
		{-1,  -1, -1, -1, -1, -1, -1, 333, -1,332, -1,332, -1, -1, -1, -1, -1, -1, -1},
		{-1,  -1, -1, -1, -1, -1, -1, 340,331,338,337,336, -1, -1, -1, -1, -1, -1, -1},

		{-1,  231,239,238,234,233,240, -1, -1, -1, -1, -1,440,433,434,438,439,431, -1},
		{-1,  229,230, -1,235, -1,231, -1, -1, -1, -1, -1,431, -1,435, -1,430,429, -1},
		{-1,  231,230,237, -1,232,238, -1, -1, -1, -1, -1,438,432, -1,437,430,431, -1},
		{-1,  233,232, -1,235, -1,237, -1, -1, -1, -1, -1,437, -1,435, -1,432,433, -1},
		{-1,  233,234,236,234,232,236, -1, -1, -1, -1, -1,436,432,434,436,433,433, -1},
 
		{-1,  -1, -1, -1, -1, -1, -1, 139,130,130,132,134, -1, -1, -1, -1, -1, -1, -1},
		{-1,  -1, -1, -1, -1, -1, -1, 138, -1,137, -1,136, -1, -1, -1, -1, -1, -1, -1},
		{-1,  -1, -1, -1, -1, -1, -1, 134,135, -1,135,134, -1, -1, -1, -1, -1, -1, -1},
		{-1,  -1, -1, -1, -1, -1, -1, 133, -1,132, -1,132, -1, -1, -1, -1, -1, -1, -1},
		{-1,  -1, -1, -1, -1, -1, -1, 140,131,138,137,136, -1, -1, -1, -1, -1, -1, -1},
		{-1,  -1, -1, -1, -1, -1, -1, 131,129,131,133,133, -1, -1, -1, -1, -1, -1, -1},


		{-1, -1,-1,-1,-1,-1,-1,  -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1}
	};
	int[,] boardMap={
		{-1, -1,-1,-1,-1,-1,-1,  -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1},

		{-1, -1,-1,-1,-1,-1,-1,   0, 0, 0, 0, 0, -1,-1,-1,-1,-1,-1, -1},
		{-1, -1,-1,-1,-1,-1,-1,  -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1},
		{-1, -1,-1,-1,-1,-1,-1,  -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1},
		{-1, -1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1},
		{-1, -1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1},

		{-1, -1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1},
		{-1, -1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1},
		{-1, -1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1},
		{-1, -1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1},

		{-1, -1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1},
		{-1, -1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1},
		{-1, -1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1},
		{-1, -1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1},
		{-1, -1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1},

		{-1, -1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1, -1}
	};

	public Transform chesses;
	public RectTransform chessBoard;
	public ChessPiece selectedPiece;
	public int mySide;
    // Use this for initialization
	public float cellWidth;
	public float cellHeight;
	public void UpdateMatrixFromPiece(ChessPiece cp){
		int ix = cp.ix;
		int iy = cp.iy;
		matrix [ix, iy] = cp;
	}
	public ChessPiece ChessPieceAtXY(int x,int y){
		return matrix [x, y];
	}

    void Start()
    {
		cellWidth=chessBoard.rect.width/17;
		cellHeight = chessBoard.rect.height / 17;
		matrix=new ChessPiece[19,19];
		for (int x = 0; x < originMatrix.GetLength (1); x++) {
			for (int y = 0; y < originMatrix.GetLength (0); y++) {
				//Debug.Log ("x,y:" + x + "," + y);
				int chess=originMatrix[x,y];
				if (chess < 0)
					continue;
				GameObject newChess = null;

				if (chess >=0 ) {
					Transform chessTransform = chesses.FindChild ("HUANG_SI_LING");
					if (chessTransform == null) {
						continue;
					}
					GameObject prefabChess = chessTransform.gameObject;
					newChess = Instantiate (prefabChess);

					ChessPiece newChessPiece = newChess.GetComponent<ChessPiece>();

					newChessPiece.SetBoardAndPosition(this,x,y);
					newChessPiece.SetChessWithInt (chess);
				}
			}
		}

    }

    // Update is called once per frame
    void Update()
    {

    }

	Vector3 playViewPosition;
	public void SetToDistributionView(){
		playViewPosition = transform.position;
		iTween.ScaleTo(gameObject,iTween.Hash("x",2.5f,"y",2.5f,"z",2.5f,"time",1));
		iTween.MoveTo (gameObject, iTween.Hash ("x", -(Screen.currentResolution.width-GetComponent<RectTransform> ().rect.size.x) /2));
	}

	public void SetToPlayView(){
		iTween.ScaleTo(gameObject,iTween.Hash("x",1,"y",1,"z",1,"time",1));
		iTween.MoveTo (gameObject, iTween.Hash ("position",playViewPosition));
	}

	public void SubmitDistribution(){
		StartCoroutine ("StartSubmitDistribution");
	}
	public IEnumerator StartSubmitDistribution(){
		WWWForm wwwForm = new WWWForm();
		wwwForm.AddField("distribution", "dist\":\"hello\"}");
		WWW www = new WWW("localhost:3000/submitDistribution.json",wwwForm);
		yield return www;

		SetToPlayView ();
	}
}