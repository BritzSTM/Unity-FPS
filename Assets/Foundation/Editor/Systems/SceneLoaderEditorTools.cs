using UnityEditor;
using UnityEngine;

namespace Fd.Editor
{
    [ExecuteInEditMode]
    internal static class SceneLoaderEditorTools
    {
        [MenuItem("GameObject/Foundation/System/SceneLoader", false, 0)]
        private static void CreateSceneLoader(MenuCommand command)
        {
            FdEditorUtils.CreateTIntoGameObject<SceneLoader>(command);
        }

        [MenuItem("GameObject/Foundation/System/SceneLoaderWhenOnEvent", false, 0)]
        private static void CreateSceneLoaderWhenOnEvent(MenuCommand command)
        {
            FdEditorUtils.CreateTIntoGameObject<SceneLoaderWhenOnEvent>(command);
        }

        [MenuItem("GameObject/Foundation/System/SceneColdLauncher", false, 0)]
        private static void CreateSceneColdLoader(MenuCommand command)
        {
            FdEditorUtils.CreateTIntoGameObject<SceneColdLauncher>(command);
        }
    }
}