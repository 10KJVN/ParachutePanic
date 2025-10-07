using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public Color clr1;
    public Color clr2;
    public Color clr3;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        ChangeColor(clr1);
    }

    private void Update()
    {
        // Alpha some why, not Keypad I guess.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //ChangeColor(Color.red);
            ChangeColor(clr1);
            Debug.Log("1 pressed");
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeColor(clr2);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeColor(clr3);
        }
    }

    public void ChangeColor(Color c)
    {
        meshRenderer.material.color = c;
    }
}
