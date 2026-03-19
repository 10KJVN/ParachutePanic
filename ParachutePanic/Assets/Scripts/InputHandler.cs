using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputHandler : MonoBehaviour
{
    public string Name => nameInput.text; // public getter for name.
    // TODO: Add a private Setter either here or elsewhere.
    
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private string filename;
    private List<InputEntry> entries = new();

    private void Start()
    {
        entries = FileHandler.ReadListFromJSON<InputEntry>(filename);
    }

    // Creates a new entry object and sets the name & points.
    public void AddNameToList()
    {
        entries.Add(new InputEntry(nameInput.text, Random.Range(0, 100)));
        nameInput.text = "";

        FileHandler.SaveToJSON<InputEntry>(entries, filename);
    }
}