using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartSceneSegues()
	{
		SceneManager.LoadScene("SPWN_Room_A");
	}

	public void StartTopDownCamera()
	{
		SceneManager.LoadScene("TDC_TopDownCamera");
	}

	public void StartThrowJam()
	{
		SceneManager.LoadScene("Throw Jam");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
