using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool _cameraStopBool = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BringDownCamera());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CameraStop"))
        {
            spriteRenderer.color = new Color32(255, 0, 0, 255);
            _cameraStopBool = true;
        }
    }

    private IEnumerator<WaitForSeconds> BringDownCamera()
    {
        while (_cameraStopBool == false)
        {
            Camera.main.transform.Translate(0, -0.025f, 0);
            yield return new WaitForSeconds(0.001f);
        }


    }
}
