using UnityEngine;

// A script that when attached to the camera, makes the resulting
// colors inverted. See its effect in play mode.
public class Example2 : MonoBehaviour
{
	private Material mat;
	public int scale = 1;

	public void CreateMaterial()
	{
		if (!mat)
		{
			// Unity has a built-in shader that is useful for drawing
			// simple colored things. In this case, we just want to use
			// a blend mode that inverts destination colors.
			Shader shader = Shader.Find("Hidden/Internal-Colored");
			mat = new Material(shader);
			mat.hideFlags = HideFlags.HideAndDontSave;
			// Set blend mode to invert destination colors.
			mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusDstColor);
			mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
			// Turn off backface culling, depth writes, depth test.
			mat.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
			mat.SetInt("_ZWrite", 0);
			mat.SetInt("_ZTest", (int)UnityEngine.Rendering.CompareFunction.Always);
		}
	}

	// Will be called from camera after regular rendering is done.
	public void OnPostRender()
	{

		// Create material
		CreateMaterial ();
		// Create buffer
		GL.PushMatrix();
		// Allow create configuration in ortho perspective transform.
		//GL.LoadOrtho();
		// Move to local reference
		//GL.MultMatrix(transform.localToWorldMatrix);

		// activate the first shader pass (in this case we know it is the only pass)
		mat.SetPass(0);
		// draw a quad over whole screen
		int vertex = 1 * scale;
		GL.Begin(GL.QUADS);
		GL.Color(new Color(1f,0f,0f,0.5f));
		GL.Vertex3(0, 0, 0);
		GL.Color(new Color(0f,1f,0f,0.5f));
		GL.Vertex3(vertex, 0, 0);
		GL.Color(new Color(0f,0f,1f,0.5f));
		GL.Vertex3(vertex, vertex, 0);
		GL.Color(new Color(1f,0f,1f,0.5f));
		GL.Vertex3(0, vertex, 0);
		GL.Color(new Color(1f,1f,0f,0.5f));
		GL.End();

		GL.PopMatrix();
	}
}