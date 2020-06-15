using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.Video;

public class VideoComponent : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public UnityEngine.UI.Text VideoText;
    public UnityEngine.UI.Text VideoText2;
    public UnityEngine.UI.Text VideoText3;


 
    public async void LoadVideo()
    {
         videoPlayer.gameObject.SetActive(true);
        videoPlayer.clip = await Addressables.LoadAssetAsync<VideoClip>("Video001");
        videoPlayer.Play();
        VideoText.text = videoPlayer.clip.name;
        VideoText2.text = $"frameCount{videoPlayer.clip.frameCount}";
        VideoText3.text = $"frameRate{videoPlayer.clip.frameRate}";
     }
}
