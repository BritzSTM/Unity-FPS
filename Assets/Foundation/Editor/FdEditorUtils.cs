using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.Compilation;

namespace Fd.Editor
{
    internal static class FdEditorUtils
    {
        internal const string RootFolderName = "Foundation";
        internal const string AssemblyName   = "Fd";

        private static string _fdPath = string.Empty;

        /// <summary>
        /// Foundation의 최상의 경로를 나타냅니다.
        /// </summary>
        internal static string FdPath
        {
            get
            {
                if (_fdPath != string.Empty)
                    return _fdPath;

                // 어셈블리에서 경로를 획득
                var assemblies = CompilationPipeline.GetAssemblies(AssembliesType.Player);
                var path = assemblies
                    .Where(assm => assm.name == AssemblyName)
                    .SingleOrDefault().sourceFiles
                    .FirstOrDefault();

                if (path == null || path == string.Empty)
                {
                    Debug.LogError("Not found foundation path");
                    return _fdPath;
                }

                // 경로가공
                var index = path.IndexOf(RootFolderName);
                if (index == -1)
                {
                    Debug.LogError("Not found foundation path");
                    return _fdPath;
                }

                _fdPath = path.Substring(0, index + RootFolderName.Length);
                return _fdPath;
            }
        }

        /// <summary>
        /// 빈 게임 오브젝트에 T를 주입하여 생성합니다.
        /// T는 반드시 Behaviour를 상속 받은 상태이어야 합니다.
        /// </summary>
        internal static GameObject CreateTIntoGameObject<T>(MenuCommand menuCommand)
            where T : Behaviour
        {
            var obj = new GameObject(typeof(T).Name);
            obj.AddComponent<T>();

            GameObjectUtility.SetParentAndAlign(obj, menuCommand.context as GameObject);
            Undo.RegisterCreatedObjectUndo(obj, $"Create {obj.name}");
            Selection.activeGameObject = obj;

            return obj;
        }
    }
}
