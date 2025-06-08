using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MenuFooterController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject indicator;
    [SerializeField] private ButtonFooterController startSelected;
    [SerializeField] private List<ButtonFooterController> footerButtons;

    [Header("Navigation Buttons")]
    [SerializeField] private ButtonFooterController shopButton;
    [SerializeField] private ButtonFooterController homeButton;
    [SerializeField] private ButtonFooterController mapButton;

    [Header("Panels")]
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject homePanel;
    [SerializeField] private GameObject mapPanel;

    // Internal
    private ButtonFooterController _buttonSelected;
    private GameObject _currentSlot;

    void Start()
    {
        if (startSelected != null)
        {
            OnButtonClickedEvent(startSelected);
        }
        else
        {
            indicator.SetActive(false);
        }
    }

    void OnEnable()
    {
        foreach (var btn in footerButtons)
        {
            btn.OnButtonClickedEvent.AddListener(OnButtonClickedEvent);
        }
    }

    void OnDisable()
    {
        foreach (var btn in footerButtons)
        {
            btn.OnButtonClickedEvent.RemoveListener(OnButtonClickedEvent);
        }
    }

    private void OnButtonClickedEvent(ButtonFooterController buttonClicked)
    {
        if (!footerButtons.Contains(buttonClicked)) return;

        if (_buttonSelected == buttonClicked)
        {
            _buttonSelected = null;
            _currentSlot = null;

            foreach (var btn in footerButtons)
                btn.SetSelect(false);

            indicator.SetActive(false);

            // Hide all panels
            ShowPanel(null);
            return;
        }

        _buttonSelected = buttonClicked;

        foreach (var btn in footerButtons)
            btn.SetSelect(_buttonSelected == btn);

        MoveIndicator();
        ShowPanel(buttonClicked);
    }

    private void ShowPanel(ButtonFooterController clicked)
    {
        shopPanel.SetActive(clicked == shopButton);
        homePanel.SetActive(clicked == homeButton);
        mapPanel.SetActive(clicked == mapButton);
    }

    private void MoveIndicator()
    {
        if (_buttonSelected == null || _currentSlot == _buttonSelected.gameObject) return;

        _currentSlot = _buttonSelected.gameObject;

        indicator.SetActive(true);
        indicator.transform.DOKill();
        indicator.transform.DOMoveX(_currentSlot.transform.position.x, 0.25f)
            .SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                indicator.transform.position = new Vector3(
                    _currentSlot.transform.position.x,
                    indicator.transform.position.y,
                    indicator.transform.position.z
                );
            });
    }
}
