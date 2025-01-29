using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader {

    public enum Scean {
        MainMenuScene,
        GameScene,
        LoadingScene

    }


    private static Scean targetScene;

    public static void Load(Scean targetSecan) {
        Loader.targetScene = targetSecan;

        SceneManager.LoadScene(Scean.LoadingScene.ToString());

    }

    public static void LoaderCallback() {
        SceneManager.LoadScene(targetScene.ToString());
    } 

}
