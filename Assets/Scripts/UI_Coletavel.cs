using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class UI_Coletavel : MonoBehaviour
{
    [SerializeField] RawImage rawImage;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] GameObject coletavel;
    [SerializeField] ColetaItem coletaItem;
    public bool isCollected;
    private void Start()
    {
        rawImage.enabled = false;
        isCollected = false;
    }
    private void Update()
    {
        isCollected = coletaItem.thatObjectCollected;
        if (isCollected == true)
        {

            rawImage.enabled = true;
        }
        
        
    }
}
