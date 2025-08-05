using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace LeightonCode
{

    [CustomEditor(typeof(FieldOfView))]
    public class EditorFieldOfView : Editor
    {
        void OnSceneGUI()
        {
            FieldOfView fov = (FieldOfView)target;
            Handles.color = Color.white;
            Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.left, 180, fov.viewRadius);
            Vector3 viewAngleA = fov.DirectionFromAngle(-fov.viewAngle / 2, false);
            Vector3 viewAngleB = fov.DirectionFromAngle(fov.viewAngle / 2, false);

            Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius);
            Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius);
            //visual cone for detecting player and adjusting size

            Handles.color = Color.red;
            foreach (Transform visibleTarget in fov.visibleTargets)
            {
                Handles.DrawLine(fov.transform.position, visibleTarget.position);
            }
        }
    }

}

