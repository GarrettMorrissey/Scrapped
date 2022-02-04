using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//-----------------------------------------------------------------------
// <copyright file="C:\Users\dered\OneDrive\Documents\VFS\Scrapped\GAME\Scrapped\Assets\Scripts\UI\videos_scripts\VFS_Copyright.cs" company="Amateur Hour">
//     Author: @deredhuzent (Dery Escoto)
//     Copyright (c) All rights reserved.
// </copyright>
//-----------------------------------------------------------------------


public class VFS_Copyright : MonoBehaviour
{

    public float _videoTime = 5f;

    [Header("Next - Landing Page")]
    [SerializeField]
    private int _index = 1;

    private void Start()
    {
        //play video and wait the time of the video
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(_videoTime);

        SceneManager.LoadScene(_index);
    }
}
