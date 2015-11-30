using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour {
    public Image panel;
    public Color panelColor;
    private string scene;
	public AudioClip casketOpen;
	private AudioSource audioS;
	// Use this for initialization
    void Start()
    {
		audioS = GetComponent<AudioSource> ();
        panelColor = panel.color;
    }

    void Update()
    {
        if (panel.color.a >= 1)
        {

        }

        if (panel.enabled)
        {
            float fade = .5f;
            panel.color = new Color(255, 255, 255, panel.color.a + Time.deltaTime * fade);
            panelColor = panel.color;
      		
        }
       
    }
    public void OnClick(string scene)
    {
        this.scene = scene;
        panel.enabled = true;
		PlaySFX();
    }

	/// <summary>
	/// Plays the SFX.
	/// </summary>
	public void PlaySFX(){
		audioS.Stop ();
		audioS.clip = casketOpen;
		audioS.Play ();
		Invoke ("LoadLevel", casketOpen.length);
	}

	/// <summary>
	/// Loads the level.
	/// </summary>
	public void LoadLevel(){
		Application.LoadLevel(scene);
	}
}
