using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;


//duplicate
namespace Assets.Script.SceneScript
{
    class SceneChager
    {
        private static SceneChager instance;

        protected SceneChager()
        {   }

        public static SceneChager getInstance()
        {
            if(instance == null)
            {
                instance = new SceneChager();
            }

            return instance;
        }

        public void change(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
