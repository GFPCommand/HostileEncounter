using Newtonsoft.Json;

namespace Assets.Scripts
{
	public class Settings
	{
		[JsonIgnore]
		private int _musicVolume;
		[JsonIgnore]
		private int _voiceVolume;
		[JsonIgnore]
		private int _surroundVolume;

		[JsonProperty("language")]
		public string Language { get; set; }

		[JsonProperty("graphic")]
		public string GraphicQuality { get; set; }

		[JsonProperty("music")]
		public int MusicVolume {
			get { return _musicVolume; }
			set 
			{
				_musicVolume = value > 100 ? 100 : value;
			}
		}

		[JsonProperty("voice")]
		public int VoiceVolume {
			get { return _voiceVolume; }
			set
			{
				_voiceVolume = value > 100 ? 100 : value;
			}
		}

		[JsonProperty("surround")]
		public int SurroundVolume { 
			get { return _surroundVolume; }
			set
			{
				_surroundVolume = value > 100 ? 100 : value;
			}
		}
	}
}
