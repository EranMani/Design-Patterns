using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField] PlantData info;
    private SetPlantInfo _setPlantInfo;

    private void Start()
    {
        _setPlantInfo = GameObject.FindWithTag("PlantInfo").GetComponent<SetPlantInfo>();
    }

    private void OnMouseDown()
    {
        _setPlantInfo.OpenPlantPanel();
        _setPlantInfo.planeName.text = info.Name;
        _setPlantInfo.threatLevel.text = info.Threat.ToString();
        _setPlantInfo.plantIcon.GetComponent<RawImage>().texture = info.Icon;
    }

    public PlantData.THREAT Threat { get { return info.Threat; } }

}
