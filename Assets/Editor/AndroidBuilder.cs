using UnityEditor;


public class AndroidBuilder
{
    [MenuItem("Custom/CI/Build Android")]
    public static void Build()
    {
        var scenes = BuildFunction.FindEnabledEditorScenes();
        BuildFunction.GenericBuild(scenes, "Equality2.apk", BuildTargetGroup.Android, BuildTarget.Android, BuildOptions.None);
    }
}