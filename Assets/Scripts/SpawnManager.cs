using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject rock;
    public GameObject[] enemys;
    public GameObject endFrameObj;
    public GameObject endLevelObj;

    public Transform rockSpawnPoint;
    public Transform pitSpawnPoint;

    public Transform spawnerPoint;

    public ComicFrame[] comicFrame;
    public float stripGapDistance = 30f;

    public int framePerStrip = 2;

    int randFrame1;
    int randFrame2;

    public static SpawnManager instance;

    private void Awake()
    {
        if (instance != this)
        {
            DestroyImmediate(instance);
            instance = this;
        }
        else
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        SpawnMap();
    }

    public void SpawnMap()
    {
        // used for randomly choosing the differant comic frames.

        for (int x = 0; x < 4; x++)
        {
            randFrame1 = Random.Range(0, (comicFrame.Length));
            randFrame2 = Random.Range(0, (comicFrame.Length));
            // loops till 'i' equals whatever  framePerStrip is set to
            for (int i = 0; i < framePerStrip; i++)
            {
                // spawns a prefab at the spawner points locaton
                Instantiate(comicFrame[randFrame1].comicFramePrefab, spawnerPoint.transform.position, Quaternion.identity);

                if (i > 0)
                {
                    float randX = Random.Range(spawnerPoint.position.x - (comicFrame[randFrame1].frameSize / 2.1f), spawnerPoint.position.x + (comicFrame[randFrame1].frameSize / 2.1f));
                    Instantiate(rock, new Vector2(randX, spawnerPoint.position.y - 3), Quaternion.identity);
                }
                // algorithm i made to hopefully calulate the distance for the spawnpoint to move to and spawn a comic frame
                spawnerPoint.transform.position = new Vector2
                       (spawnerPoint.transform.position.x + (((comicFrame[randFrame1].frameSize / 2) + (comicFrame[randFrame2].frameSize / 2)) + comicFrame[1].gapDistance), spawnerPoint.position.y);

                Instantiate(comicFrame[randFrame2].comicFramePrefab, spawnerPoint.transform.position, Quaternion.identity);

                int randEnem = Random.Range(0, enemys.Length);
                Instantiate(enemys[randEnem], spawnerPoint.position, Quaternion.identity);

                float randX2 = Random.Range(spawnerPoint.position.x - (comicFrame[randFrame1].frameSize / 2.1f), spawnerPoint.position.x + (comicFrame[randFrame1].frameSize / 2.1f));
                Instantiate(rock, new Vector2(randX2, spawnerPoint.position.y - 3), Quaternion.identity);

                spawnerPoint.transform.position = new Vector2
                       (spawnerPoint.transform.position.x + (((comicFrame[randFrame1].frameSize / 2) + (comicFrame[randFrame2].frameSize / 2)) + comicFrame[1].gapDistance), spawnerPoint.position.y);

                if (i == 2 && x == 3)
                {
                    Instantiate(endLevelObj, spawnerPoint.position, Quaternion.identity);
                    return;
                }

                if (i == 2)
                {
                    Instantiate(endFrameObj, spawnerPoint.transform.position, Quaternion.identity);
                    spawnerPoint.transform.position = new Vector2(0, spawnerPoint.position.y - stripGapDistance);
                }
            }
        }

    }

}
