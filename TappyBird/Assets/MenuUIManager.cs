﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuUIManager : MonoBehaviour {

	public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
