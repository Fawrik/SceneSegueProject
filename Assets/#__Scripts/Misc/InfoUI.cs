using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoUI : MonoBehaviour
{
	public GameObject detailInfo;
	public bool detailInfoActive = false;

    void Update()
    {
		InfoControlls();
		UpdateInfoVisual();
    }

	void InfoControlls()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			detailInfoActive = !detailInfoActive;
		}

		if (detailInfoActive == false && Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
		else if (detailInfoActive && Input.GetKeyDown(KeyCode.Escape))
		{
			detailInfoActive = false;
		}
	}

	void UpdateInfoVisual()
	{
		detailInfo.transform.GetChild(0).gameObject.SetActive(detailInfoActive);
	}


	void ExitToMainMenu()
	{
		if (SceneManager.GetActiveScene().name != "TDC_TopDownCamera" && SceneManager.GetActiveScene().name != "Throw Jam")
		{
			if (GameObject.FindGameObjectWithTag("Canvas").transform.parent.gameObject != null)
			{
				Destroy(GameObject.FindGameObjectWithTag("Canvas").transform.parent.gameObject);
			}
		}
		
		SceneManager.LoadScene("Main Menu");
		Destroy(gameObject);
	}
}
