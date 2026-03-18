using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputHandler : MonoBehaviour
{
    //public InputField nameInput { get; private set; }
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] string filename;
    
    // Maybe with or without the = "" - But i'll see. It was without.
    public string Name => nameInput.text; // public getter for name.

    List<InputEntry> entries = new List<InputEntry>();

    private void Start()
    {
        entries = FileHandler.ReadListFromJSON<InputEntry>(filename);
    }

    public void AddNameToList()
    {
        // Create a new object and set name and points via the ctor.
        entries.Add(new InputEntry(nameInput.text, Random.Range(0, 100)));
        nameInput.text = "";

        FileHandler.SaveToJSON<InputEntry>(entries, filename);
    }

    public string GetName() => nameInput.text;
    
}
