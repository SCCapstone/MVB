using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class SceneTransitionTest
    {
        [UnityTest]
        public IEnumerator SceneTransitionTests()
        {
            // Use the Assert class to test conditions.
            // ***Have to assert something here.......
            // Use yield to skip a frame.
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (!(scene.buildIndex == -1 && scene.isLoaded))
                {
                    // We then load the next scene by incrementing the build index by 1.
                    // Theres a bug where the code oges out of range because there is no index after
                    // 57, because of the 57th scene.
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            yield return null;
        }
    }
}
