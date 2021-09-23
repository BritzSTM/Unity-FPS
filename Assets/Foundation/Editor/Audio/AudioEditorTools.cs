using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Fd.Editor
{
    [ExecuteInEditMode]
    internal static class AudioEditorTools
    {
        internal const string DefaultRequirePlaySoundFXSOName = "DefaultRequirePlaySoundFXSO";
        
        private static AudioClipEventSO _defaultRequirePlaySoundFXSO = null;
        internal static AudioClipEventSO DefaultRequirePlaySoundFXSO
        {
            get
            {
                if (_defaultRequirePlaySoundFXSO != null)
                    return _defaultRequirePlaySoundFXSO;

                string[] searchDirs = { FdEditorUtils.FdPath };
                var soGUID = AssetDatabase.FindAssets($"{DefaultRequirePlaySoundFXSOName} t:{nameof(AudioClipEventSO)}", searchDirs).SingleOrDefault();

                if(soGUID == null)
                {
                    Debug.LogError($"Not Found {DefaultRequirePlaySoundFXSOName}");
                    return _defaultRequirePlaySoundFXSO;
                }

                var soPath = AssetDatabase.GUIDToAssetPath(soGUID);
                _defaultRequirePlaySoundFXSO = AssetDatabase.LoadAssetAtPath<AudioClipEventSO>(soPath);

                return _defaultRequirePlaySoundFXSO;
            }
        }

        [MenuItem("GameObject/Foundation/Audio/DefaultSoundFXPlayer")]
        private static void CreateDefaultSoundFXPlayer(MenuCommand command)
        {
            // 객체생성
            var obj = FdEditorUtils.CreateTIntoGameObject<AudioSource>(command);
            obj.name = "DefaultSoundFXPlayer";
            GameObjectUtility.EnsureUniqueNameForSibling(obj);

            // 컴포넌트 추가 및 설정하고 직렬화 상호작용을 통해 속성 갱신
            var asCompo = obj.GetComponent<AudioSource>();
            asCompo.playOnAwake = false;

            var agentCompo = obj.AddComponent<AudioPlayAgentOnEvent>();
            var serializedObject = new SerializedObject(agentCompo);
            serializedObject.Update();

            SerializedProperty eventSOProp = serializedObject.FindProperty("_onPlayOneShotEventSO");
            eventSOProp.objectReferenceValue = DefaultRequirePlaySoundFXSO;

            serializedObject.ApplyModifiedProperties();
        }
    }
}
