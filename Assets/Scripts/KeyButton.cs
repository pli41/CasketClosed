using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyButton : MonoBehaviour {
    public KeyCode key;
    public Button one;
    public Button two;
    private Button current;
    private Button other;
    private Button swap;
    void Start()
    {
        current = one;
        other = two;
        current.Select();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            swap = other;
            other = current;
            current = swap;
            current.Select();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            swap = other;
            other = current;
            current = swap;
            current.Select();
        }
        if (Input.GetKey(KeyCode.Return))
        {
            current.onClick.Invoke();
        }
    }
    
}