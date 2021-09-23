using UnityEngine;
using UnityEditor;

namespace Fd.Editor
{
    [ExecuteInEditMode]
    internal static class ObserverForSceneStartEditorTool
    {
        [MenuItem("GameObject/Foundation/System/ObserverForSceneStart", false, 0)]
        private static void CreateObserverForSceneStart(MenuCommand menuCommand)
        {
            FdEditorUtils.CreateTIntoGameObject<ObserverForSceneStart>(menuCommand);
        }
    }
}