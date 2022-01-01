using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SPWN_PlayerSpawner : MonoBehaviour
{
	public List<SPWN_Segue> segueList = new List<SPWN_Segue>();
	public GameObject playerPrefab;
	string sceneDefaultString = "SPWN_Room_";

	void Start()
    {
		GetCurrentScene();
		segueList.AddRange(FindObjectsOfType<SPWN_Segue>());
		SpawnPlayer();

		//if (SPWN_MapUI.Instance.map != null)
			DontDestroy.Instance.GetComponentInChildren<SPWN_MapUI>().UpdateMap();
    }

	void GetCurrentScene()
	{
		if (SceneManager.GetActiveScene().name == sceneDefaultString + "A")
			SPWN_Manager.Instance.currentScene = CurrentScene.SceneA;
		else if (SceneManager.GetActiveScene().name == sceneDefaultString + "B")
			SPWN_Manager.Instance.currentScene = CurrentScene.SceneB;
		else if (SceneManager.GetActiveScene().name == sceneDefaultString + "C")
			SPWN_Manager.Instance.currentScene = CurrentScene.SceneC;
		else if (SceneManager.GetActiveScene().name == sceneDefaultString + "D")
			SPWN_Manager.Instance.currentScene = CurrentScene.SceneD;
		else
		{
			SPWN_Manager.Instance.currentScene = CurrentScene.Other;                //Scene ID unknown;
			Debug.LogError("Scene ID is not within defined parameter");	
		}
	}

	public void SpawnPlayer()
	{
		for (int segueCount = 0; segueCount < segueList.Count; segueCount++)
		{
			if (segueList[segueCount].inValue == SPWN_Manager.Instance.spawnValue)
			{
				if (!GameObject.FindGameObjectWithTag("Player"))
					Instantiate(playerPrefab, segueList[segueCount].inPoint.transform.position, Quaternion.Euler(0, segueList[segueCount].inPoint.transform.eulerAngles.y, 0));
			}
		}
	}
}
