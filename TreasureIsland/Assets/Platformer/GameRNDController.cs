using System;
using System.Collections;
using System.Collections.Generic;
using GoraTales;
using Unity.VisualScripting;
using UnityEngine;

public class GameRNDController : MonoBehaviour
{
 int num1;
 int num2;
 int num3;

 [SerializeField] GameObject _enemy1;
 [SerializeField] GameObject _enemy2;
 [SerializeField] GameObject _enemy3;
 [SerializeField] GameObject _enemy4;
 [SerializeField] GameObject _enemy5;
 
 [SerializeField] GameObject _coin1;
 [SerializeField] GameObject _coin2;
 [SerializeField] GameObject _coin3;
 [SerializeField] GameObject _coin4;
 [SerializeField] GameObject _coin5;
 [SerializeField] GameObject _coin6;
 [SerializeField] GameObject _coin7;
 [SerializeField] GameObject _coin8;
 [SerializeField] GameObject _coin9;
 [SerializeField] GameObject _coin10;
 
 [SerializeField] GameObject _weather1;
 [SerializeField] GameObject _weather2;
 
 
 void Start()
 {
  num1 = 1;
  num2 = 2;
  num3 = 3;
  SetEnemy();
  SetRewards();
  SetWeather();
 }



 void SetEnemy()
 {

  if (num1 <= 2)
  {
   _enemy1.SetActive(true);
   _enemy2.SetActive(false);
   _enemy3.SetActive(false);
   _enemy4.SetActive(false);
   _enemy5.SetActive(false);
  }
  else if (num1 <= 4)
  {
   _enemy1.SetActive(true);
   _enemy2.SetActive(true);
   _enemy3.SetActive(false);
   _enemy4.SetActive(false);
   _enemy5.SetActive(false);
  }   else if (num1 <= 6)
  {
   _enemy1.SetActive(true);
   _enemy2.SetActive(true);
   _enemy3.SetActive(true);
   _enemy4.SetActive(false);
   _enemy5.SetActive(false);
  }
  else if (num1 <= 8)
  {
   _enemy1.SetActive(true);
   _enemy2.SetActive(true);
   _enemy3.SetActive(true);
   _enemy4.SetActive(true);
   _enemy5.SetActive(false);
  }
  else
  {
   _enemy1.SetActive(true);
   _enemy2.SetActive(true);
   _enemy3.SetActive(true);
   _enemy4.SetActive(true);
   _enemy5.SetActive(true);
  }
 }
 
 void SetRewards()
 {

  if (num2 <= 2)
  {
   _coin1.SetActive(false);
   _coin2.SetActive(false);
   _coin3.SetActive(false);
   _coin4.SetActive(false);
   _coin5.SetActive(false);
   _coin6.SetActive(false);
   _coin7.SetActive(false);
   _coin8.SetActive(false);
   _coin9.SetActive(true);
   _coin10.SetActive(true);
  }
  else if (num2 <= 4)
  {
   _coin1.SetActive(false);
   _coin2.SetActive(false);
   _coin3.SetActive(false);
   _coin4.SetActive(false);
   _coin5.SetActive(false);
   _coin6.SetActive(false);
   _coin7.SetActive(true);
   _coin8.SetActive(true);
   _coin9.SetActive(true);
   _coin10.SetActive(true);
  }   else if (num2 <= 6)
  {
   _coin1.SetActive(false);
   _coin2.SetActive(false);
   _coin3.SetActive(false);
   _coin4.SetActive(false);
   _coin5.SetActive(true);
   _coin6.SetActive(true);
   _coin7.SetActive(true);
   _coin8.SetActive(true);
   _coin9.SetActive(true);
   _coin10.SetActive(true);
  }
  else if (num2 <= 8)
  {
   _coin1.SetActive(false);
   _coin2.SetActive(false);
   _coin3.SetActive(true);
   _coin4.SetActive(true);
   _coin5.SetActive(true);
   _coin6.SetActive(true);
   _coin7.SetActive(true);
   _coin8.SetActive(true);
   _coin9.SetActive(true);
   _coin10.SetActive(true);
  }
  else
  {
   _coin1.SetActive(true);
   _coin2.SetActive(true);
   _coin3.SetActive(true);
   _coin4.SetActive(true);
   _coin5.SetActive(true);
   _coin6.SetActive(true);
   _coin7.SetActive(true);
   _coin8.SetActive(true);
   _coin9.SetActive(true);
   _coin10.SetActive(true);
  }
 }
 
 void SetWeather()
 {
  if (num3 <= 2)
  {
   _weather1.SetActive(false);
   _weather2.SetActive(false);
  }
  else if (num3 <= 4)
  {
   _weather1.SetActive(true);
   _weather2.SetActive(false);
  }   else if (num3 <= 6)
  {
   _weather1.SetActive(false);
   _weather2.SetActive(true);
  }
  else if (num3 <= 8)
  {
   _weather1.SetActive(true);
   _weather2.SetActive(true);
  }
  else
  {
   _weather1.SetActive(false);
   _weather2.SetActive(true);
  }
  
 }
 
 
 
 
 
}
