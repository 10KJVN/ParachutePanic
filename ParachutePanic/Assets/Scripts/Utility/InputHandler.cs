using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;

/// <summary>
/// This class handles the input of the InputField
/// In which you pass on a username to add to a highscore list for example.
/// Start() and AddNameToList() are kept for standalone testing purposes.
/// </summary>

public class InputHandler : MonoBehaviour
{
    public string Name => nameInput.text;
    public Action OnNameRecceived;
    
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

        FileHandler.SaveToJSON(entries, filename);
    }
}