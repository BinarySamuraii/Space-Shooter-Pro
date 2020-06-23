﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   [SerializeField] private bool _isGameOver;

   public void GameOver()
   {
      _isGameOver = true;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
      {
         SceneManager.LoadScene(1); // Current Game Scene
      }
   }
}
