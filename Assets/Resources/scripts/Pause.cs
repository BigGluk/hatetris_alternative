using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    public float timing;
    public float musicbutton;
    public float soundbutton;
    public bool pausing;
    public GameObject pausemenu;
    public GameObject old;
    public GameObject musicon;
    public GameObject musicoff;
    public GameObject soundon;
    public GameObject soundoff;
    // потом надо будет запилить сохранение выбора
    void Start()
    {
        musicon.SetActive(true);
        musicoff.SetActive(false);
        soundon.SetActive(true);
        soundoff.SetActive(false);
    }
    public void MusicTurn()
    {
        if (musicbutton == 1)
        {
            musicon.SetActive(true);
            musicoff.SetActive(false);
            musicbutton = 0;
        }
        else if (musicbutton == 0)
        {
            musicon.SetActive(false);
            musicoff.SetActive(true);
            musicbutton = 1;
        }
    }
    public void SoundTurn()
    {
        if (soundbutton == 1)
        {
            soundon.SetActive(true);
            soundoff.SetActive(false);
            soundbutton = 0;
        }
        else if (soundbutton == 0)
        {
            soundon.SetActive(false);
            soundoff.SetActive(true);
            soundbutton = 1;
        }
    }
    public void Paused()
    {
        
        pausing = true;
    }
    public void Resume()
    {
        pausing = false;
    }
    public void Quit()
    {
        Application.LoadLevel(0);
    }


	
	// Update is called once per frame
	void Update () {
        if (pausing == true)
        {
            timing = 0;
            Time.timeScale = timing;
            pausemenu.SetActive(true);
            old.SetActive(false);
        }
        else if (pausing == false)
        {
            timing = 1;
            Time.timeScale = timing;
            pausemenu.SetActive(false);
            old.SetActive(true);
        }
    }

    }

