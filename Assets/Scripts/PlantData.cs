using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "plantdata", menuName = "Plant Data", order = 51)]
public class PlantData : ScriptableObject
{
    public enum THREAT { None, Low, Moderate, High }

    [SerializeField] string plantName;
    [SerializeField] THREAT planetThreat;
    [SerializeField] Texture icon;
}
