using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuActions : MonoBehaviour, IToggleable
{
	[SerializeField]
	private GameObject progressBar;
	[SerializeField]
	private GameObject text;
	[SerializeField]
	private Slider progressSlider;
	[SerializeField]
	private GameObject settings;
	[SerializeField]
	private GameObject soundSettings;
	[SerializeField]
	private GameObject mainMenu;
	[SerializeField]
	private GameObject playMenu;
	[SerializeField]
	private GameObject backButton;
	[SerializeField]
	private Sprite[] imageList;
	[SerializeField] 
	private Sprite mainBackgroundImage;
	[SerializeField]
	private Image backgroundImage;
    [SerializeField]
    private GameObject videoObject;
	[SerializeField]
    private GameObject canvas;
	[SerializeField]
    private GameObject music;

    private int state = 0;

	private int progress = 0;

	private int playMenuCount = 0;

	private void Start()
	{
		state = 0;
		progress = 0;
		playMenuCount = 0;
	}

	public void StartButton()
	{
		MenuToggle(false, false, false, true, true);

		backgroundImage.GetComponent<Image>().sprite = imageList[playMenuCount];

		state = (int)MainMenuStates.PlayMenu;
	}

	public void Play()
	{
		playMenu.SetActive(false);

		backButton.SetActive(false);

		text.SetActive(true);

		progressBar.SetActive(true);

		StartCoroutine(Loader());
	}

	public void RightArrow()
	{
		if (playMenuCount == 5) playMenuCount = 0;
		else playMenuCount++;

		backgroundImage.GetComponent<Image>().sprite = imageList[playMenuCount];
	}

	public void LeftArrow()
	{
		if (playMenuCount == 0) playMenuCount = 5;
		else playMenuCount--;

		backgroundImage.GetComponent<Image>().sprite = imageList[playMenuCount];
	}

	public void SettingsButton()
	{
		MenuToggle(false, true, false, false, true);

		state = (int)MainMenuStates.Settings;
	}

	public void SoundSettingsButton()
	{
		MenuToggle(false, false, true, false, true);

		state = (int)MainMenuStates.SoundSettings;
	}

	public void BackButton()
	{
		switch (state)
		{
			case (int)MainMenuStates.Settings:
				MenuToggle(true, false, false, false, false);

				state = 0;
				break;
			case (int)MainMenuStates.SoundSettings:
				MenuToggle(false, true, false, false, true);

				state = 1;
				break;
			case (int)MainMenuStates.PlayMenu:
				MenuToggle(true, false, false, false, false);

				backgroundImage.GetComponent<Image>().sprite = mainBackgroundImage;

				state = 0;
				break;
			default:
				break;
		}
	}

	public void ExitButton()
	{
		Application.Quit();
	}

	IEnumerator Loader()
	{
		while (progress < 100)
		{
			yield return new WaitForSeconds(0.5f);

			progress += 10;

			progressSlider.value = progress;
		}

		videoObject.SetActive(true);

		canvas.SetActive(false);

		music.SetActive(false);

		yield return new WaitForSeconds(45f);

		SceneManager.LoadScene(1);
	}

	/// <summary>
	/// Set activation for various menu parts
	/// </summary>
	/// <param name="activations">[0] - main, [1] - settings, [2] - soundSettings, [3] - playMenu, [4] - backButton</param>
	public void MenuToggle(params bool[] activations)
	{
		mainMenu.SetActive(activations[0]);
		settings.SetActive(activations[1]);
		soundSettings.SetActive(activations[2]);
		playMenu.SetActive(activations[3]);
		backButton.SetActive(activations[4]);
	}
}
