using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GoraTales.UI.MainMenu
{
    public class MainMenuWindow : AnimatedWindow
    {
        Action _closeAction;
        
        public void OnShowSettings()
        {
            var window = Resources.Load<GameObject>("UI/Settings");
            var canvas = FindObjectOfType<Canvas>();
            Instantiate(window, canvas.transform);
        }
        
        public void OnStartGame()
        {
            _closeAction = () => { SceneManager.LoadScene("GameScene"); };
            Close();
        }
        
        public void OnStartChain()
        {
            _closeAction = () => { SceneManager.LoadScene("Roulete"); };
            Close();
        }
        
        public void OnExit()
        {
            _closeAction = () =>
            {
                Application.Quit();
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
            };
            Close();
        }

        public override void OnCloseAnimationComplite()
        {
            base.OnCloseAnimationComplite();
            _closeAction?.Invoke();
        }
    }
}
