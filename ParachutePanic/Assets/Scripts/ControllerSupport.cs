using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerSupport : MonoBehaviour
{
    public Button priorityButton;
    public Button secondaryButton;
    
    public void Start()
    {
        priorityButton.Select();
    }
    
}
