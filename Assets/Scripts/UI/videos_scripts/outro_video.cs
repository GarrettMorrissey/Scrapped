using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//-----------------------------------------------------------------------
// <copyright file="C:\Users\dered\OneDrive\Documents\VFS\Scrapped\GAME\Scrapped\Assets\Scripts\UI\videos_scripts\outro_video.cs" company="Amateur Hour">
//     Author: @deredhuzent (Dery Escoto)
//     Copyright (c) All rights reserved.
// </copyright>
//-----------------------------------------------------------------------


public class outro_video : MonoBehaviour
{
    [Header("timers")]
    [SerializeField]
    private float _videoTime = 20f;
    [SerializeField]
    private float _activeTitle = 16.5f;

    [Header("Next - VFS Copyright")]
    [SerializeField]
    private int _index = 6;

    [Header("Title")]
    [SerializeField]
    private GameObject _title = null;

    [SerializeField] private AK.Wwise.Event _stopEndingTune = null;

    private void Update()
    {
        //skip intro video and run game
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            _stopEndingTune.Post(gameObject);
            SceneManager.LoadScene(_index);
        }
    }

    private void Awake()
    {
        //play video and wait the time of the video
        StartCoroutine(Wait());
        StartCoroutine(Title());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(_videoTime);

        //run Landing Page after video
        SceneManager.LoadScene(_index);
    }

    IEnumerator Title(){
        yield return new WaitForSeconds(_activeTitle);

        _title.SetActive(true);
    }
}
