using System;
using UnityEngine;

/// <summary>
/// Aims to be the only follow/reparent behaviour you ever need?
/// </summary>
public class Attacher : MonoBehaviour
{
    public enum Strategy { Reparent, Follow }
    public enum AttachTime { OnDemand, OnStart }

    public Strategy strategy = Strategy.Follow;
    public AttachTime attachTime = AttachTime.OnStart;

    [Header("For reparent strategy")]
    public bool ResetTransformOnReparent = false;
    
    [Header("For follow strategy")]
    public bool FollowRotation = true;
    public Vector3 FollowOffset = Vector3.zero;

    [Header("Define one")]
    public Transform AttachByReference;
    public string AttachByName;
    public string AttachByTag;
    public string AttachByComponentType;
    public Renderer AttachByRenderBounds;

    private Transform attachTransform;

    private void Start()
    {
        if (attachTime == AttachTime.OnStart) Attach();
    }

    public void Attach()
    {
        attachTransform = FindAttachPoint();
        if (attachTransform != null)
        {
            switch (strategy)
            {
                case Strategy.Reparent:
                    transform.SetParent(attachTransform, !ResetTransformOnReparent);
//                    transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
                    // We're done here
                    Destroy(this);
                    break;
                case Strategy.Follow:
                    transform.SetParent(transform.root, true);
                    break;
            }
        }
    }

    private void LateUpdate()
    {
        Vector3 pos = Vector3.zero;
        Quaternion rot = Quaternion.identity;

        if (attachTransform)
        {
			Vector3 b = attachTransform.position;
			b.x = FollowOffset.x;
			//b.y = FollowOffset.y;
			pos = b;
            rot = attachTransform.rotation;            
        }
//        else if (AttachByMeshBounds != null)
//        {
//            pos = AttachByMeshBounds.mesh.bounds.center;
//        }
        else if (AttachByRenderBounds != null)
        {
            pos = AttachByRenderBounds.bounds.center;
        }

        if (FollowRotation)
        {
            transform.SetPositionAndRotation(pos + FollowOffset, rot);
        }
        else
        {   
            transform.position = pos + FollowOffset;
        }
    }
    
    private Transform FindAttachPoint()
    {
        if (AttachByReference != null) return AttachByReference;
        if (!string.IsNullOrEmpty(AttachByName)) return GameObject.Find(AttachByName).transform;
        if (!string.IsNullOrEmpty(AttachByTag)) return GameObject.FindWithTag(AttachByTag).transform;
        if (!string.IsNullOrEmpty(AttachByComponentType)) return ((Component) FindObjectOfType(Type.GetType(AttachByComponentType))).transform;
        if (AttachByRenderBounds != null) return null;
        
        return null;
    }
}