using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ativarBotao : MonoBehaviour {

	public GameObject botaoMUTE;
	public GameObject botaoON;
	public AudioSource audio;    
	public bool tocando;
	private int intAudio = 1;

	void Start()
	{

		if (PlayerPrefs.HasKey ("audio")) {
			intAudio = PlayerPrefs.GetInt ("audio");
			Debug.Log ("no start:" + intAudio);

		} else {
			intAudio = 1;
		}

		if (intAudio == 1)
		{
			botaoMUTE.SetActive (false);
			botaoON.SetActive (true);
			audio.mute = false;



		}
		else if (intAudio == 0)
		{
			botaoMUTE.SetActive (true);
			botaoON.SetActive (false);
			audio.mute = true;


		}

	}

	public void manipulaSom()
	{

		if (intAudio == 0)
		{
			botaoMUTE.SetActive (false);
			botaoON.SetActive (true);
			audio.mute = false;
			intAudio = 1;


		}
		else if (intAudio == 1)
		{
			botaoMUTE.SetActive (true);
			botaoON.SetActive (false);
			audio.mute = true;

			intAudio = 0;
		}


		PlayerPrefs.SetInt ("audio",intAudio);

		Debug.Log (PlayerPrefs.GetInt ("audio"));
	}




}





