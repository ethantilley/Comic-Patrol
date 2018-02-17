using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by using this i can create on of these like a asset
[CreateAssetMenu(fileName = "New Comic Frame", menuName = "Frame")]
public class ComicFrame : ScriptableObject
{


    public float frameSize;
    public float gapDistance;
   
    public GameObject comicFramePrefab;

    public int rockSpawnAmount; //???
}
