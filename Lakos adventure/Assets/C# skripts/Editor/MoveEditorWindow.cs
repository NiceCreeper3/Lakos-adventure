using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Moves))]
public class MoveEditorWindow : Editor  
{
    //SerializedProperty values
    #region
    SerializedProperty MoveName;
    SerializedProperty MoveDiskrepseon;
    SerializedProperty MoveSound;

    SerializedProperty power;
    SerializedProperty MoveElement;

    SerializedProperty AddedAbilityes;


    SerializedProperty healPower;

    SerializedProperty _getBoffings;
    #endregion

    private bool _flaverInfo, BasickMoves, Ablitys = false;
    private bool _wantsToChangeHealt = false;
    private bool _wantsToBuff = false;


    // gets a refrends to the values
    private void OnEnable()
    {
        // getes refrends to all the values ind the Moves scripts
        
        MoveName = serializedObject.FindProperty("MoveName");
        MoveDiskrepseon = serializedObject.FindProperty("MoveDiskrepseon");
        MoveSound = serializedObject.FindProperty("MoveSound");

        power = serializedObject.FindProperty("power");
        MoveElement = serializedObject.FindProperty("MoveElement");

        AddedAbilityes = serializedObject.FindProperty("AddedAbilityes");

        healPower = serializedObject.FindProperty("_healPower");
        _getBoffings = serializedObject.FindProperty("_getBoffings");

    }

    public override void OnInspectorGUI()
    {
        Moves moves = (Moves)target;

        serializedObject.Update();

        // makes a drop down four falver info
        _flaverInfo = EditorGUILayout.BeginFoldoutHeaderGroup(_flaverInfo, "Flaver info");
        if (_flaverInfo)
        {
            // displayes ety pise of info
            EditorGUILayout.PropertyField(MoveName);
            EditorGUILayout.PropertyField(MoveDiskrepseon);
            EditorGUILayout.PropertyField(MoveSound);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(5);


        // displayes normal pise of info
        EditorGUILayout.PropertyField(power);
        EditorGUILayout.PropertyField(MoveElement);

        EditorGUILayout.Space(-5);

        EditorGUILayout.PropertyField(AddedAbilityes);

        EditorGUILayout.Space(5);

        #region
        // Abilty

        // makes a drop down four falver info
        Ablitys = EditorGUILayout.BeginFoldoutHeaderGroup(Ablitys, "the normal");
        if (Ablitys)
        {
            GUILayout.Label("Abiltys info");
            _wantsToChangeHealt = GUILayout.Toggle(_wantsToChangeHealt, "using buffing");
            _wantsToBuff = GUILayout.Toggle(_wantsToBuff, "using healt change");
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(5);

        // shows healtchange values informason
        if (_wantsToChangeHealt)
        {
            // displayes ety pise of info
            GUILayout.Label("how to change healt");
            EditorGUILayout.PropertyField(healPower);
        }

        EditorGUILayout.Space(10);

        // shows buff informason
        if (_wantsToBuff)
        {
            // displayes ety pise of info
            EditorGUILayout.PropertyField(_getBoffings);

        }
        #endregion

        serializedObject.ApplyModifiedProperties();

        //base.OnInspectorGUI();

    }
}
