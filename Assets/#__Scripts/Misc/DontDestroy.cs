using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	public static DontDestroy Instance;

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

		DontDestroyOnLoad(this.gameObject);
	}
}
