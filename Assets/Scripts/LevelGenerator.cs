using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour
{
	NavMeshSurface meshSurface;
	
	public int width = 10;
	public int height = 10;

	public GameObject wall;
	public GameObject player;

	private bool playerSpawned = false;

	void Start () 
	{
        meshSurface = FindObjectOfType<NavMeshSurface>();

        GenerateLevel();
        meshSurface.BuildNavMesh();

    }
	
	void GenerateLevel()
	{
		for (int x = 0; x <= width; x+=3)
		{
			for (int y = 0; y <= height; y+=1)
			{
				if (Random.value >0.3f)
				{
					Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
					Instantiate(wall, pos, Quaternion.identity, transform);
				} else if (!playerSpawned)
				{
					Vector3 pos = new Vector3(x - width / 2f, 1.25f, y - height / 2f);
					Instantiate(player, pos, Quaternion.identity);
					playerSpawned = true;
				}
			}
		}
	}
}
