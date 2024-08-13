using UnityEngine;

public static class UnityUtils
{
    public static Bounds GetBounds(Renderer renderer)
    {
        return renderer.bounds;
    }

    public static void DisableMeshRenderersAndColliders(GameObject gameObject)
    {
        MeshRenderer[] meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in meshRenderers)
        {
            renderer.enabled = false;
        }
        Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
    }
}
