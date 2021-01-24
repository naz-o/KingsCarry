using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AM : MonoBehaviour {

	[System.Serializable]
	public class AudioPlayClass{
		public enum AudioDestroyEnum{
			none = 0,
			destroyAtEnd = 10,
			destroyAfterTime = 20,
			destroyAfterCount = 30
		}
		public AudioClip[] audioclips;
		public AudioMixerGroup mixerGroup;
		[Range(0,100f)]
		public float probability = 100f;
		public float delay = 0f;
		[Range(0,1f)]
		public float volume = 1f;
		[Range(-1f,1f)]
		public float speed = 1f;
		[Range(0f,1f)]
		public float randomPitch = 0f;
		public bool loop = false;
		[Header("DESTROY")]
		public AudioDestroyEnum destroy;
		public float destroyValue = -1f;
		[Tooltip("For example the force it needs to reach. Only for physical sounds!")]
		public float dependencyValue = -1f;
		[Header("2D/3D")]
		public float spatialBlend = 1f;
		[Header("OTHER")]
		public float dopplerLevel = 0f;
		[SerializeField]
		public AudioRolloffMode rolloffMode = AudioRolloffMode.Linear;
		public float minDistance = 5f;
		public float maxDistance = 80;
		public float spread = 180f;
		public bool muteornah = false;

		private AudioSource a = null;

		public void Mute()
        {
			float tempvolu = volume;
			if (muteornah) {

				volume = tempvolu;
				a.volume = tempvolu;
				muteornah = !muteornah;
			}

            else
            {
				volume = 0f;
				a.volume = 0f;
				muteornah = !muteornah;
			}
        }

		public GameObject Create(string _refName = "", float _dependencyValue = -1f){
			if(_dependencyValue > -1f && dependencyValue > -1f && _dependencyValue < dependencyValue || audioclips == null || audioclips.Length == 0 || speed == 0f)
				return null;

			GameObject newAudioObject = new GameObject();

			a = newAudioObject.AddComponent<AudioSource>();
			a.clip = audioclips[Random.Range(0, audioclips.Length)];
			a.outputAudioMixerGroup = mixerGroup;
			a.pitch = speed;
			if(randomPitch > 0f)
				a.pitch += Random.Range(-randomPitch,randomPitch);
			a.loop = loop;
			a.volume = volume;
			a.spatialBlend = spatialBlend;
			a.dopplerLevel = dopplerLevel;
			a.rolloffMode = rolloffMode;
			a.minDistance = minDistance;
			a.maxDistance = maxDistance;
			a.spread = spread;

			if(!string.IsNullOrEmpty(_refName))
				newAudioObject.name = _refName;
			else
				newAudioObject.name = a.clip.name;

			switch(destroy){
				case AudioDestroyEnum.none: 
					break;
				case AudioDestroyEnum.destroyAtEnd: 
					Destroy(newAudioObject, (a.clip.length / Mathf.Abs(a.pitch)) + 0.05f);
					break;
				case AudioDestroyEnum.destroyAfterTime: 
					Destroy(newAudioObject, Mathf.Abs(destroyValue));
					break;
				case AudioDestroyEnum.destroyAfterCount: 	//try to calculate how many times it will play
					Destroy(newAudioObject, (a.clip.length / Mathf.Abs(a.pitch)) * destroyValue + 0.05f);
					break;	
			}
			return newAudioObject;
		}

		public void Play(MonoBehaviour _callingScript){
			if(a == null)
				return;

			if(delay > 0){
				_callingScript.StartCoroutine(PlayDelayed());
				return;
			}
			a.Play();
		}
		public IEnumerator PlayDelayed(){
			if(a == null)
				yield break;

			if(delay <= 0){
				a.Play();
				yield break;
			}

			yield return new WaitForSeconds(delay);
			if(a != null)
				a.Play();
		}

		public IEnumerator Fade(AudioSource _source, float _start, float _end, float _speed){
			float t = 0f;
			while(t<1f){
				t += Time.unscaledDeltaTime*_speed;
				_source.volume = Mathf.Lerp(_start, _end, t);
				yield return null;
			}
		}
	}

	[Header("AUDIO MANAGER")]
	[SerializeField]
	public AudioPlayClass menuMusic;

	[SerializeField]
	public AudioPlayClass worldMusic;

	[Header("VALUES")]
	public float musicFadeSpeed = 4f;

	public bool continueMusicAfterLevel = true;
	private bool worldMusicPlays = false;

	private AudioSource currentMusicSource;

	void Awake(){
		if(Object.FindObjectsOfType<AM>().Length > 1){	//ONLY ALLOW ONE MANAGER!
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);
	}

	public void PlayMenuMusic(){
		StartCoroutine(FadeOutCurrentAndFadeInNew(menuMusic));
		
		worldMusicPlays = false;
	}


	public void PlayWorldMusic(){
		if(continueMusicAfterLevel && worldMusicPlays)
			return;
		
		StartCoroutine(FadeOutCurrentAndFadeInNew(worldMusic));
		
		worldMusicPlays = true;
	}

	public void PlaySound(AudioPlayClass _sound){
		_sound.Create();
		_sound.Play(this);
	}

	public void ActivatedPause(){
		//do underwater thingy
	}

	private IEnumerator FadeOutCurrentAndFadeInNew(AudioPlayClass newAudio){	
		if(currentMusicSource != null && currentMusicSource.isPlaying){
			float fadeStart = currentMusicSource.volume;
			yield return StartCoroutine(newAudio.Fade(currentMusicSource, fadeStart, 0f, musicFadeSpeed));
			currentMusicSource.Stop();
		}

		if(newAudio != null){
			currentMusicSource = newAudio.Create("Menu Music").GetComponent<AudioSource>();
			DontDestroyOnLoad(currentMusicSource);		
			float endVolume = currentMusicSource.volume;
			currentMusicSource.volume = 0f;

			yield return StartCoroutine(newAudio.PlayDelayed());
			yield return StartCoroutine(newAudio.Fade(currentMusicSource, 0f, endVolume, musicFadeSpeed));
		}
	}


}
