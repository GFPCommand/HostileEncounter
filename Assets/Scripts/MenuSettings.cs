using Assets.Scripts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuSettings : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _languageText;
	[SerializeField]
	private TMP_Text _graphText;
	[SerializeField]
	private TMP_Text _settingsText;
	[SerializeField]
	private TMP_Text _soundSettingsText;
	[SerializeField]
	private TMP_Text _soundSettingsMainText;
	[SerializeField]
	private TMP_Text _musicText;
	[SerializeField]
	private TMP_Text _voiceText;
	[SerializeField]
	private TMP_Text _surroundText;

	[SerializeField]
	private Slider _musicSlider;
	[SerializeField]
	private Slider _voiceSlider;
	[SerializeField]
	private Slider _surroundSlider;

	[SerializeField]
	private AudioSource _audio;
    [SerializeField]
    private VideoPlayer _video;

    [SerializeField]
	private TextAsset _settingsTextAssets;

	public Settings Settings;
	public MenuSettingsText SettingsText;

	private string[] _languagesArray = { "EN", "RU" };
	private string[] _graphicQualityArray = { "LOW", "MED", "HIGH" };

	private void Awake()
	{
		if (!PlayerPrefs.HasKey("settings"))
		{
			Settings = new() { Language = "EN", GraphicQuality = "MED", MusicVolume = 100, VoiceVolume = 100, SurroundVolume = 100};

			PlayerPrefs.SetString("settings", JsonConvert.SerializeObject(Settings));
		}
		string readText = PlayerPrefs.GetString("settings");

		Settings = JsonConvert.DeserializeObject<Settings>(readText);

		LoadSettingsTextFromFile();
	}

	private void Start()
	{
		TextChange();

		_musicSlider.value = Settings.MusicVolume;
		_voiceSlider.value = Settings.VoiceVolume;
		_surroundSlider.value = Settings.SurroundVolume;

		_audio.volume = (float)Settings.MusicVolume / 100;
		_audio.volume = (float)Settings.MusicVolume / 100;
	}

	public void ChangeLanguage()
	{
		int num = Settings.Language == "EN" ? 0 : 1;

		num = (num == 0 ? 1 : 0);

		Settings.Language = _languagesArray[num];

		LoadSettingsTextFromFile();

		TextChange();
	}

	public void ChangeGraphicQuality(int buttonNum)
	{
		int num = default;

		switch (Settings.GraphicQuality)
		{
			case "LOW":
				num = 0;
				QualitySettings.SetQualityLevel(1, true);
				break;
			case "MED":
				num = 1;
				QualitySettings.SetQualityLevel(3, true);
				break;
			case "HIGH":
				num = 2;
				QualitySettings.SetQualityLevel(5, true);
				break;
		}

		switch(buttonNum)
		{
			case 1: //right
				num++;
				if (num == 3) num = 0;

				_graphText.text = $"{SettingsText.GraphText} {_graphicQualityArray[num]}";
				Settings.GraphicQuality = _graphicQualityArray[num];

				break;
			case 2: //left
				num--;
				if (num == -1) num = 2;

				_graphText.text = $"{SettingsText.GraphText} {_graphicQualityArray[num]}";
				Settings.GraphicQuality = _graphicQualityArray[num];

				break;
		}

		TextChange();
	}

	private void TextChange()
	{
		var langStr = Settings.Language.Equals("EN") ? "EN" : "РУ";

		string graphStr = Settings.GraphicQuality;

		if (Settings.Language.Equals("RU"))
		{
			switch (Settings.GraphicQuality)
			{
				case "LOW":
					graphStr = "НИЗ";
					break;
				case "MED":
					graphStr = "СРЕД";
					break;
				case "HIGH":
					graphStr = "ВЫС";
					break;
			}
		}

		_languageText.text = $"{SettingsText.LangText} {langStr}";
		_graphText.text = $"{SettingsText.GraphText} {graphStr}";

		_settingsText.text = SettingsText.SettingsText;
		_soundSettingsText.text = SettingsText.SoundSettingsText;
		_soundSettingsMainText.text = SettingsText.SoundSettingsText;
		_musicText.text = SettingsText.MusicText;
		_voiceText.text = SettingsText.VoiceText;
		_surroundText.text = SettingsText.SurroundText;
	}

	private void LoadSettingsTextFromFile()
	{
		var settingsText = _settingsTextAssets.text;

		var info = JObject.Parse(settingsText);

		var txt = info[Settings.Language].ToString();

		SettingsText = JsonConvert.DeserializeObject<MenuSettingsText>(txt);
	}
}
