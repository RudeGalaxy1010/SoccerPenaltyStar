using UnityEditor;

[CustomEditor(typeof(SkinPart))]
public class SkinPartEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SkinPart skinPart = target as SkinPart;

        if (skinPart.CostType != CostType.Ads)
        {
            skinPart.Cost = EditorGUILayout.IntField("Cost", skinPart.Cost);

        }
    }
}
