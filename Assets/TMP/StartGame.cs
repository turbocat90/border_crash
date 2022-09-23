using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private FollowCamera followCamera;
    [SerializeField] private PreviewCamera previewCamera;
    private void Start()
    {
        previewCamera.gameObject.SetActive(true);
        followCamera.gameObject.SetActive(false);
    }
}
