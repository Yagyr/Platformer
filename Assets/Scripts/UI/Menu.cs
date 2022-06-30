using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuButton;
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private GameObject _loseWindow;
    [SerializeField] private GameObject _winWindow;

    [SerializeField] private MonoBehaviour[] _componentsToDisable;

    public void OpenMenuWindow()
    {
        _menuButton.SetActive(false);
        _menuWindow.SetActive(true);
        for (int i = 0; i < _componentsToDisable.Length; i++)
        {
            _componentsToDisable[i].enabled = false;
        }

        Time.timeScale = 0.01f;
    }
    public void CloseMenuWindow()
    {
        _menuButton.SetActive(true);
        _menuWindow.SetActive(false);

        for (int i = 0; i < _componentsToDisable.Length; i++)
        {
            _componentsToDisable[i].enabled = true;
        }

        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseWindow()
    {
        _menuButton.SetActive(false);
        _loseWindow.SetActive(true);
        
        for (int i = 0; i < _componentsToDisable.Length; i++)
        {
            _componentsToDisable[i].enabled = false;
        }
        
        Time.timeScale = 0.01f;
    }

    public void WinWindow()
    {
        _menuButton.SetActive(false);
        _winWindow.SetActive(true);
    }
}
