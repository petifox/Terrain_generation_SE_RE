using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class VegetationSpawner : MonoBehaviour
{
    public float Radius;
    public float OceanHeight;
    public List<Plant> Plants;

    [Button]
    public void Generate()
    {

    }
}
[System.Serializable]
public class Plant
{
    public List<GameObject> Instances;
    public bool RandomYRotation = true;
    [MinMaxSlider(0, 3)] public Vector2 MinMaxScale = new Vector2(0.8f, 1.2f);
}
