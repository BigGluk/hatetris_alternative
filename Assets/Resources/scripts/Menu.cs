using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    public void StartButton()
    {
        Application.LoadLevel(1);
    }
    public void SkinsButton()
    {
        Application.LoadLevel(2);
    }
}
