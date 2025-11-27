using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class Video : MonoBehaviour
{
    private float length_;
    [SerializeField] float _time;
    private void Start()
    {
        length_ =  (float) GetComponent<VideoPlayer>().clip.length;
    }
    private void Update()
    {
        _time += Time.deltaTime;
        if (_time > length_)
        {
            SceneManager.LoadSceneAsync(8);
        }
    }
}
