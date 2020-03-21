using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject fallingBlockPrefab;
	public Vector2 secondsBetweenSpawnsMinMax;
	private float nextSpawnTime;

	public Vector2 spawnSizeMinMax;
	public float spawnAngleMax;

	private Vector2 screenhalfSizeWorldunits;

	void Start()
	{
		screenhalfSizeWorldunits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}

	// Update is called once per frame
	void Update()
	{
		if (Time.time > nextSpawnTime)
		{
			float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
			nextSpawnTime = Time.time + secondsBetweenSpawns;

			float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
			float spawSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
			Vector2 spawnPosition = new Vector2(Random.Range(-screenhalfSizeWorldunits.x, screenhalfSizeWorldunits.x), screenhalfSizeWorldunits.y + spawSize / 2f);
			GameObject newBlock = Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
			newBlock.transform.localScale = Vector3.one * spawSize;

			
		}
	}
}
