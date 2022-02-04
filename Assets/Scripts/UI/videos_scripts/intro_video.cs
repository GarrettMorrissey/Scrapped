using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//-----------------------------------------------------------------------
// <copyright file="C:\Users\dered\OneDrive\Documents\VFS\Scrapped\GAME\Scrapped\Assets\Scripts\UI\videos_scripts\intro_video.cs" company="Amateur Hour">
//     Author: @deredhuzent (Dery Escoto)
//     Copyright (c) All rights reserved.
// </copyright>
//-----------------------------------------------------------------------


public class intro_video : MonoBehaviour
{
    [SerializeField]
    private float _videoTime = 53f;
    
    [SerializeField] private GameObject _skipAudioObject = null;
    private SkipAudio _sa;
    
    [Header("Next - Game")]
    [SerializeField]
    private int _index = 4;

    private void Awake()
    {
        _sa = _skipAudioObject.GetComponent<SkipAudio>();
        //play video and wait the time of the video
        StartCoroutine(Wait());
    }
    
    private void Update()
    {
        //skip intro video and run game
 
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            _sa.SkipCinematicSound();
            SceneManager.LoadScene(_index);
        }
    }

        IEnumerator Wait() {
        yield return new WaitForSeconds(_videoTime);

        //run game after video
        SceneManager.LoadScene(_index);
    }
}
