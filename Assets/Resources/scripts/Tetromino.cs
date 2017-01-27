using UnityEngine;
using System.Collections;

public class Tetromino : MonoBehaviour {

    float fall = 0;
    public float fallSpeed = 1;
    bool allowRotation = true;
    bool limitRotation = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckUserInput();
	}

    void CheckUserInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!CheckValidPosition())
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else FindObjectOfType<Game>().UpdateGrid(this);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!CheckValidPosition())
            {
                transform.position += new Vector3(1, 0, 0);
            }
            else FindObjectOfType<Game>().UpdateGrid(this);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (allowRotation)
            {
                if (limitRotation)
                {
                    if (transform.rotation.eulerAngles.z >= 90) Rotate(-90);
                    else Rotate(90);
                }
                else Rotate(90);
                if (CheckValidPosition())
                {
                    FindObjectOfType<Game>().UpdateGrid(this);
                }
                else
                {
                    if (limitRotation)
                    {
                        if (transform.rotation.eulerAngles.z >= 90) Rotate(-90);
                        else Rotate(90);
                    }
                    else Rotate(-90);
                }


            }
            


        }
        else if (Input.GetKey(KeyCode.DownArrow)||(Time.time - fall)>=fallSpeed)
        {
            transform.position += new Vector3(0, -1, 0);
            fall = Time.time;
            if (!CheckValidPosition())
            {
                transform.position += new Vector3(0, 1, 0);
                FindObjectOfType<Game>().DeleteRow();
                if (FindObjectOfType<Game>().IsAboveGrid(this))
                {
                    FindObjectOfType<Game>().GameOver();
                }
                enabled = false;
                FindObjectOfType<Game>().SpawnNextTetromino();
            }
            else FindObjectOfType<Game>().UpdateGrid(this);
        }
    }

    void Rotate(int i)
    {
        if (!(name == "O(Clone)"))
        {
            foreach (Transform mino in transform)
            {
                mino.Rotate(0, 0, -i);
            }
            transform.Rotate(0, 0, i);
        }
    }
    bool CheckValidPosition(){
        foreach (Transform mino in transform)
        {
            Vector2 pos = FindObjectOfType<Game>().Round(mino.position);
            if (!FindObjectOfType<Game>().CheckInsideGrid(pos))
            {
                
                return false;
            }
            if (FindObjectOfType<Game>().GetTransformAtGridPosition(pos) != null && FindObjectOfType<Game>().GetTransformAtGridPosition(pos).parent != transform)
            {
                return false;
            }
        }
        return true;
    }

    int GetRotNum(int rotation)
    {
        if (rotation < 0) rotation = 3;
        else if (rotation >= 4) rotation = 0;
        return rotation;
    }

    
}
