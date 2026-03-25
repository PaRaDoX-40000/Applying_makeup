using UnityEngine;

public class MakeupPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] makeupPanels;
    [SerializeField] private MakeupTabButton[] tabButtons;

    private int _currentTabIndex = -1;

    private void Start()
    {
        InitDefaultState();
    }

    private void InitDefaultState()
    {
        for (int i = 0; i < makeupPanels.Length; i++)
        {
            makeupPanels[i].SetActive(false);
            tabButtons[i].SetActiveState(false);
        }
        SelectTab(0);
    }
    public void SelectTab(int index)
    {
        if (index < 0 || index >= makeupPanels.Length) return;
        if (index >= tabButtons.Length) return;
        if (index == _currentTabIndex) return;

        if (_currentTabIndex != -1)
        {
            makeupPanels[_currentTabIndex].SetActive(false);
            tabButtons[_currentTabIndex].SetActiveState(false);
        }
        makeupPanels[index].SetActive(true);
        tabButtons[index].SetActiveState(true);
        _currentTabIndex = index;
    }
}