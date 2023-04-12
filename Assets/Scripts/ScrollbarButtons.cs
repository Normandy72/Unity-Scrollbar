using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollbarButtons : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private List<Toggle> _toggleButtonsList;

    private Toggle _activeButton;
    private int _currentIndex = 0;
    private int _lastIndex = 0;

    private void Start()
    {
        _activeButton = _toggleButtonsList[_currentIndex];
    }

    public void OnScrollRectValueChanged(Vector2 value)
    {
        float currentPosition = _scrollRect.horizontalNormalizedPosition;
        float viewportWidth = _scrollRect.viewport.rect.width;
        int index = (int)(currentPosition / viewportWidth);

        if (index < 0) index = 0;
        if (index >= _toggleButtonsList.Count) index = _toggleButtonsList.Count - 1;

        if (index == _currentIndex) return;

        if (index > _currentIndex)
        {
            // Скроллим вправо
            string buttonText = _toggleButtonsList[_lastIndex].GetComponentInChildren<TextMeshProUGUI>().text;
            for (int i = _lastIndex; i < index; i++)
            {
                _toggleButtonsList[i].GetComponentInChildren<TextMeshProUGUI>().text = _toggleButtonsList[i + 1].GetComponentInChildren<TextMeshProUGUI>().text;
            }
            _toggleButtonsList[index].GetComponentInChildren<TextMeshProUGUI>().text = buttonText;

            _lastIndex++;
            if (_lastIndex >= _toggleButtonsList.Count) _lastIndex = 0;
            _currentIndex = index;
        }
        else
        {
            // Скроллим влево
            string buttonText = _toggleButtonsList[_lastIndex].GetComponentInChildren<TextMeshProUGUI>().text;
            for (int i = _lastIndex; i > index; i--)
            {
                _toggleButtonsList[i].GetComponentInChildren<TextMeshProUGUI>().text = _toggleButtonsList[i - 1].GetComponentInChildren<TextMeshProUGUI>().text;
            }
            _toggleButtonsList[index].GetComponentInChildren<TextMeshProUGUI>().text = buttonText;

            _lastIndex--;
            if (_lastIndex < 0) _lastIndex = _toggleButtonsList.Count - 1;
            _currentIndex = index;
        }
    }
}

// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;

// public class ScrollbarButtons : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IScrollHandler
// {
//     [SerializeField] private ScrollRect _scrollRect;
//     [SerializeField] private List<Toggle> _toggleButtonsList;
//     private Toggle _activeButton;
//     private int _currentIndex;
//     private int _lastIndex;
//     private List<string> _originalButtonsText;
//     private float _previousScrollValue;

//     private void Start()
//     {
//         _originalButtonsText = new List<string>();

//         for (int i = 0; i < _toggleButtonsList.Count; i++)
//         {
//             _toggleButtonsList[i].isOn = false;
//             _originalButtonsText.Add(_toggleButtonsList[i].GetComponentInChildren<TextMeshProUGUI>().text);
//         }

//         _activeButton = _toggleButtonsList[1];
//         _activeButton.isOn = true;

//         _currentIndex = 1;
//         _lastIndex = _toggleButtonsList.Count - 1;
//         _previousScrollValue = _scrollRect.horizontalNormalizedPosition;
//     }

//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         _previousScrollValue = _scrollRect.horizontalNormalizedPosition;
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         float currentScrollValue = _scrollRect.horizontalNormalizedPosition;

//         if (currentScrollValue < _previousScrollValue)
//         {
//             ScrollToLeft();
//         }
//         else if (currentScrollValue > _previousScrollValue)
//         {
//             ScrollToRight();
//         }

//         _previousScrollValue = currentScrollValue;
//     }

//     public void OnScroll(PointerEventData eventData)
//     {
//         float currentScrollValue = _scrollRect.horizontalNormalizedPosition;

//         if (currentScrollValue < _previousScrollValue)
//         {
//             ScrollToLeft();
//         }
//         else if (currentScrollValue > _previousScrollValue)
//         {
//             ScrollToRight();
//         }

//         _previousScrollValue = currentScrollValue;
//     }

//     private void ScrollToRight()
// {
//     int previousIndex = _currentIndex - 1;
//     if (previousIndex < 0) previousIndex = _toggleButtonsList.Count - 1;
//     int nextIndex = _currentIndex + 1;
//     if (nextIndex >= _toggleButtonsList.Count) nextIndex = 0;

//     _toggleButtonsList[nextIndex].GetComponentInChildren<TextMeshProUGUI>().text = _activeButton.GetComponentInChildren<TextMeshProUGUI>().text;
//     _activeButton.GetComponentInChildren<TextMeshProUGUI>().text = _toggleButtonsList[previousIndex].GetComponentInChildren<TextMeshProUGUI>().text;
//     _toggleButtonsList[previousIndex].GetComponentInChildren<TextMeshProUGUI>().text = _toggleButtonsList[nextIndex].GetComponentInChildren<TextMeshProUGUI>().text;

//     _currentIndex = previousIndex;
//     _activeButton = _toggleButtonsList[nextIndex];
// }


//     private void ScrollToLeft()
//     {
//         int previousIndex = _currentIndex - 1;
//         if (previousIndex < 0) previousIndex = _toggleButtonsList.Count - 1;
//         int nextIndex = _currentIndex + 1;
//         if (nextIndex >= _toggleButtonsList.Count) nextIndex = 0;

//         string previousText = _originalButtonsText[previousIndex];
//         string nextText = _originalButtonsText[nextIndex];

//         _toggleButtonsList[previousIndex].GetComponentInChildren<TextMeshProUGUI>().text = _activeButton.GetComponentInChildren<TextMeshProUGUI>().text;
//         _activeButton.GetComponentInChildren<TextMeshProUGUI>().text = nextText;
//         _toggleButtonsList[nextIndex].GetComponentInChildren<TextMeshProUGUI>().text = previousText;

//         _currentIndex = nextIndex;
//         _activeButton = _toggleButtonsList[_lastIndex];
//         _activeButton.isOn = false;
//         _lastIndex = previousIndex;
//     }
// }
