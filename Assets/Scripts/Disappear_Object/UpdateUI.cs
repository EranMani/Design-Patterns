using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
    }

    private void OnEnable()
    {
        HideObject.hidePlayer += UpdateTextWhenPlayerDies;
    }

    private void OnDisable()
    {
        HideObject.hidePlayer -= UpdateTextWhenPlayerDies;
    }

    void UpdateTextWhenPlayerDies()
    {
        text.enabled = true;
        text.text = "GAME OVER!";
    }
}
