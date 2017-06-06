using System;
using System.Collections.Generic;
using UnityEditor;


public class BuildFunction
{
    public static string[] FindEnabledEditorScenes()
    {
        List<string> EditorSceneList = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled == false)
            {
                continue;
            }

            EditorSceneList.Add(scene.path);
        }

        return EditorSceneList.ToArray();
    }

    public static void GenericBuild(string[] scenes, string target_filename, BuildTargetGroup build_group, BuildTarget build_target, BuildOptions build_options)
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(build_group, build_target);

        string res = BuildPipeline.BuildPlayer(scenes, target_filename, build_target, build_options);
        if (0 < res.Length)
        {
            throw new Exception("GenericBuild failure: " + res);
        }
    }
}
