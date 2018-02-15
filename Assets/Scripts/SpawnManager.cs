using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public Transform rockSpawnPoint;
    public Transform pitSpawnPoint;

    public Transform spawnerPoint;
    public ComicFrame[] comicFrame;

    public int framePerStrip = 3;

    int randFrame1;
    int randFrame2;



    /*
     * 
        spawnerPoint.transform.position = new Vector2
                 (spawnerPoint.transform.position.x + (((comicFrame[1].frameSize / 2) + (comicFrame[1].frameSize / 2)) + comicFrame[1].gapDistance), 0);
     */

    // Use this for initialization
    void Start()
    {
        // used for randomly choosing the differant comic frames.
        randFrame1 = Random.Range(0, (comicFrame.Length));
        randFrame2 = Random.Range(0, (comicFrame.Length));

        // loops till i equals whatever  framePerStrip is set to
        for (int i = 0; i < framePerStrip; i++)
        {
            // spawns a prefab at the spawner points locaton
            Instantiate(comicFrame[randFrame1].comicFramePrefab, spawnerPoint.transform.position, Quaternion.identity);

            // algorithm i made to hopefully calulate the distance for the spawnpoint to move to and spawn a comic frame
            spawnerPoint.transform.position = new Vector2
                   (spawnerPoint.transform.position.x + (((comicFrame[randFrame1].frameSize / 2) + (comicFrame[randFrame2].frameSize / 2)) + comicFrame[1].gapDistance), 0);

            Instantiate(comicFrame[randFrame2].comicFramePrefab, spawnerPoint.transform.position, Quaternion.identity);

            spawnerPoint.transform.position = new Vector2
                   (spawnerPoint.transform.position.x + (((comicFrame[randFrame1].frameSize / 2) + (comicFrame[randFrame2].frameSize / 2)) + comicFrame[1].gapDistance), 0);


        }

    }

}
