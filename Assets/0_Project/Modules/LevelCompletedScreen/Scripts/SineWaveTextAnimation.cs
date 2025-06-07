using UnityEngine;
using TMPro;

public class SineWaveTextAnimation : MonoBehaviour
{
    const float amplitude = 5f; // How far the letters float
    const float frequency = 2f; // Speed of the float
    const float waveOffset = 0.2f; // Offset between each letter

    private TMP_Text textMesh;
    private Vector3[] originalVertices;

    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
        textMesh.ForceMeshUpdate();
        originalVertices = textMesh.mesh.vertices;
    }

    void Update()
    {
        AnimateText();
    }

    void AnimateText()
    {
        // Get the updated mesh and vertices
        textMesh.ForceMeshUpdate();
        var mesh = textMesh.mesh;
        var vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            int charIndex = i / 4; // Each character is represented by 4 vertices
            float wave = Mathf.Sin(Time.time * frequency + charIndex * waveOffset);
            vertices[i].y = originalVertices[i].y + wave * amplitude;
        }

        // Apply the modified vertices back to the mesh
        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }
}
