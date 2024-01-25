using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuActions : MonoBehaviour, IToggleable
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject pauseButton;
    [SerializeField]
    private GameObject gameUI;

    private bool isPause;

    public void OpenPauseMenu()
    {
        MenuToggle(true, false, false);

        Time.timeScale = 0;
    }

    public void ClosePauseMenu() 
    {
        MenuToggle(false, true, true);

        Time.timeScale = 1;
    }

    public void OpenSettings()
    {
        Debug.Log("Settings");
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }

	public void MenuToggle(params bool[] activations)
	{
        pauseMenu.SetActive(activations[0]);
        pauseButton.SetActive(activations[1]);
        gameUI.SetActive(activations[2]);
	}
}
