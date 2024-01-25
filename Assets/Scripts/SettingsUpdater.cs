using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUpdater : MonoBehaviour
{
	[SerializeField]
	private Slider _musicSlider;
	[SerializeField]
	private Slider _voiceSlider;
	[SerializeField]
	private Slider _surroundSlider;

	[SerializeField]
	private AudioSource _audio;

	[SerializeField]
	private MenuSettings _menuSettings;

	public void UpdaterAction()
	{
		_menuSettings.Settings.MusicVolume = (int)_musicSlider.value;
		_menuSettings.Settings.VoiceVolume = (int)_voiceSlider.value;
		_menuSettings.Settings.SurroundVolume = (int)_surroundSlider.value;

		_audio.volume = (float)_menuSettings.Settings.MusicVolume / 100;

		string serializeObj = JsonConvert.SerializeObject(_menuSettings.Settings);

		PlayerPrefs.SetString("settings", serializeObj);
	}

	private void Update()
	{
		_audio.volume = _musicSlider.value / 100;
	}
}