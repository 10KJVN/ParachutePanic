using UnityEngine;
using System.Collections.Generic;
using TMPro;

/// <summary>
/// This class purely manages the HighscoreUI
/// And listens to: when to open, close or update it.
/// </summary>

public class HighscoreUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject highscoreUIElementPrefab;
    [SerializeField] private Transform elementWrapper;
    [SerializeField] private TMP_Text persistentHighscoreText;
    private List<GameObject> uiElements = new();

    private void OnEnable()
    {
        HighscoreHandler.onHighscoreListChanged += UpdateUI;
        HighscoreHandler.onHighscoresLoaded += DisplayHighscore;
    }

    private void OnDisable()
    {
        HighscoreHandler.onHighscoreListChanged -= UpdateUI;
        HighscoreHandler.onHighscoresLoaded -= DisplayHighscore;
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    private void UpdateUI(List<HighscoreElement> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var element = list[i];

            if (element.points > 0)
            {
                if (i >= uiElements.Count)
                {
                    // instantiate new entry
                    var inst = Instantiate(highscoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(elementWrapper, false);

                    uiElements.Add(inst);
                }

                // write or overwrite name & points
                var texts = uiElements[i].GetComponentsInChildren<TMP_Text>();
                texts[0].text = element.playerName;
                texts[1].text = element.points.ToString();
            }
        }
    }

    private void DisplayHighscore(int highscore)
    {
        persistentHighscoreText.text = highscore.ToString();
    }
}
