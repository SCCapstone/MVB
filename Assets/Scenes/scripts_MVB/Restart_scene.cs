﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_scene : MonoBehaviour
{
  public void restart()
    {
        SceneManager.LoadScene("sample_maze_2");
        Debug.Log("Working As intened");
    }
}
