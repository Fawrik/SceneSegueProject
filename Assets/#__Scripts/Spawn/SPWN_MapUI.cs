using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPWN_MapUI : MonoBehaviour
{
	public static SPWN_MapUI Instance;
	public Animator map;
	string mapAnimationFloat = "Room";

	

	//private void OnEnable()
	//{
	//	if (Instance == null)
	//	{
	//		Instance = this;
	//		//DontDestroyOnLoad(this);
	//	}
	//	else if (Instance != null)
	//	{
	//		Destroy(this.gameObject);
	//	}
	//}

	private void OnEnable()
	{	
		map = gameObject.GetComponentInChildren<Animator>();
	}



	

	public void UpdateMap()
	{
		map = gameObject.GetComponentInChildren<Animator>();
		switch (SPWN_Manager.Instance.currentScene)
		{
			case CurrentScene.SceneA:
				map.SetFloat(mapAnimationFloat, 2);
				break;
			case CurrentScene.SceneB:
				map.SetFloat(mapAnimationFloat, 3);
				break;
			case CurrentScene.SceneC:
				map.SetFloat(mapAnimationFloat, 4);
				break;
			case CurrentScene.SceneD:
				map.SetFloat(mapAnimationFloat, 5);
				break;
			case CurrentScene.Other:
				map.SetFloat(mapAnimationFloat, 1);
				break;
			default:
				break;
		}
	}
}
