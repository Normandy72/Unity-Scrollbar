using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour
{
    public ScrollRect scrollRect;
    public Button[] buttons;

    private void Start()
    {
        SetActiveButton(GetActiveButtonIndex());
    }

    private void LateUpdate()
    {
        // set active button
        SetActiveButton(GetActiveButtonIndex());
    }

    private int GetActiveButtonIndex()
    {
        // current scrollbar value
        float scrollPosition = scrollRect.normalizedPosition.x;

        // index of active button
        int activeButtonIndex = Mathf.RoundToInt(scrollPosition * (buttons.Length - 1));

        return activeButtonIndex;
    }

    private void SetActiveButton(int index)
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = (i == index);
        }
    }
}
