using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour {
    public Image panel;
    public Color panelColor;
	// Use this for initialization
    void Start()
    {
        panelColor = panel.color;
    }

    void Update()
    {
        if (panel.color.a >= 1)
        {
            Application.LoadLevel("Room_for_Wake");
        }
        if (panel.enabled)
        {
            float fade = .5f;
            panel.color = new Color(255, 255, 255, panel.color.a + Time.deltaTime * fade);
            panelColor = panel.color;
      
        }
       
    }
    public void OnClick()
    {
        panel.enabled = true;
        
       

    }
}
