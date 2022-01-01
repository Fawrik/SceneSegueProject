 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
	public float scrollSpeedFloat = 0.5F;
	public Vector2 scrollSpeed = new Vector2(0.1f, 0.1f);
	public Material imageMat;
	float currentScrollFloat;

	void Start()
	{
		imageMat = GetComponent<Renderer>().material;
	}

	void Update()
	{
		Vector2 bgScroll = Time.time * scrollSpeed;
		currentScrollFloat += scrollSpeedFloat * Time.deltaTime;
		imageMat.mainTextureOffset = bgScroll;
	}
}
