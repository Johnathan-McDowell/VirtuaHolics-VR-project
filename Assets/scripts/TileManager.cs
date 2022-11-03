using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
   
    public GameObject[] tilePrefabs;

    public float tileLength = 7;
    public int numberOfTiles = 5;
   

    public float zSpawn = 7;

    private Transform playerTransform;
   

    private int previousIndex;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {

            SpawnTile(0);
        }
        playerTransform = tilePrefabs[1].transform;
    }
    // Update is called once per frame
    void Update()
    {
        
      if(playerTransform.position.x  >= zSpawn- (numberOfTiles* tileLength))
        {
           
            SpawnTile(0);
        }
            
    }
    public void SpawnTile(int tileIndex)
    {

         Instantiate(tilePrefabs[tileIndex], transform.right * zSpawn, transform.rotation);
         zSpawn+=tileLength;
    }
     
     
}
