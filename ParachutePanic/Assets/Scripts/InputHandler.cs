using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputField nameInput;
    [SerializeField] string filename;

    List<InputEntry> entries = new List<InputEntry>();

    private void Start()
    {
        entries = FileHandler.ReadFromJSON<InputEntry>(filename);
    }

    public void AddNameToList()
    {
        // Create a new object and set name and points via the ctor.
        entries.Add(new InputEntry(nameInput.text, Random.Range(0, 100)));
        nameInput.text = "";

        FileHandler.SaveToJSON<InputEntry> (entries, filename);
    }
}
