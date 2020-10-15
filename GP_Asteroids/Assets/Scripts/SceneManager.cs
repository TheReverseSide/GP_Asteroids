using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    void Update()
    {
        if (!this.GetComponent<VideoPlayer>().isPlaying)
        {
            // print("Playing");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Gameplay");
        }
    }
}
