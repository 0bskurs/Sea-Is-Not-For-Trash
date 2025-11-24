using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using System.Collections.Generic;
public class UI_Coletavel : MonoBehaviour
{
    [SerializeField] RawImage rawImage;
    [SerializeField] RawImage rawImage2;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] GameObject coletavel;
    [SerializeField] ColetaItem coletaItem;
    public List<bool> whichObject;
    private void Start()
    {
        rawImage2.enabled = true;
        rawImage.enabled = false;
        
    }
    private void Update()
    {
        
        if (whichObject[0] == true)
        {
            if (coletaItem.gpuCollected == true)
            {
                rawImage2.enabled = false;
                rawImage.enabled = true;
                
            }
        }
        else if (whichObject[1] == true)
        {
            if (coletaItem.processadorCollected == true)
            {
                rawImage2.enabled = false;
                rawImage.enabled = true;
            }
        }
        else if (whichObject[2] == true)
        {
            if (coletaItem.placaMaeCollected == true)
            {
                rawImage2.enabled = false;
                rawImage.enabled = true;
            }
        }
        else if (whichObject[3] == true)
        {
            if(coletaItem.gabineteCollected == true)
            {
                rawImage2.enabled = false;
                rawImage.enabled = true;
            }
        }
        
        
    }
}
