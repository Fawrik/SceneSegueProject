using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SPWN_Manager : MonoBehaviour
{
	public static SPWN_Manager Instance;
	GameObject playerPrefab;
	public int spawnValue;

	public CurrentScene currentScene;

	public GameObject map;
	public bool showMap = false;

	private void OnEnable()
	{
		if (Instance == null)
		{
			Instance = this;
			//DontDestroyOnLoad(this);
		}
		else if (Instance != null)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this);
	}

	private void Update()
	{
		EnableMap();
	}

	void EnableMap()
	{
		if (Input.GetKeyDown(KeyCode.M))
		{
			map = GameObject.FindGameObjectWithTag("Canvas");
			showMap = !showMap;
			map.transform.GetChild(0).gameObject.SetActive(showMap);
			if (showMap)
			{
				SPWN_MapUI.Instance.UpdateMap();
			}
		}
	}

	public void LoadScene(string sceneID)
	{
		SceneManager.LoadScene(sceneID);
	}
}

	public enum CurrentScene { SceneA, SceneB, SceneC, SceneD, Other}