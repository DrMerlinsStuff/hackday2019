using UnityEngine;
using UnityEditor;
using System.Collections;
using ProBuilder2.EditorCommon;
using ProBuilder2.Common;

namespace ProBuilder2.Actions
{
    public class pb_VerifyEntity : Editor
    {
        [MenuItem("Tools/ProBuilder/Repair/Verify pb_Entity Exists")]
        static void Init()
        {
            pb_Object[] all = Resources.FindObjectsOfTypeAll<pb_Object>();

            Material ColliderMat = pb_Constant.ColliderMaterial;
            Material TriggerMat = pb_Constant.TriggerMaterial;

            if (ColliderMat == null)
                Debug.LogError("ProBuilder cannot find Collider material!  Make sure the Collider material asset is in \"Assets/ProCore/ProBuilder/Resources/Material\" folder.");

            if (TriggerMat == null)
                Debug.LogError("ProBuilder cannot find Trigger material!  Make sure the Trigger material asset is in \"Assets/ProCore/ProBuilder/Resources/Material\" folder.");

            foreach (pb_Object pb in all)
            {
                pb_Entity ent = pb.gameObject.GetComponent<pb_Entity>();

                if (ent == null)
                {
                    ent = pb.gameObject.AddComponent<pb_Entity>();

                    MeshRenderer mr = pb.gameObject.GetComponent<MeshRenderer>();

                    if (mr != null)
                    {
                        Material mat = mr.sharedMaterial;

                        if (ColliderMat != null && mat == ColliderMat)
                            pb_Menu_Commands.MenuSetEntityType(new pb_Object[1] { pb }, EntityType.Collider);
                        else if (TriggerMat != null && mat == TriggerMat)
                            pb_Menu_Commands.MenuSetEntityType(new pb_Object[1] { pb }, EntityType.Trigger);
                    }
                }
            }
        }
    }
}
