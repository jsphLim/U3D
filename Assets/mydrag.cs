using UnityEngine;
using System.Collections;

public class mydrag : UIDragDropItem {

    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        this.transform.parent = surface.transform;
        this.transform.localPosition = Vector3.zero;
    }

}
