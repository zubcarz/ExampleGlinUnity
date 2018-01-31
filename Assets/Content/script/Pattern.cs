using System.Collections;
using UnityEngine;
using System.Collections;

public class pattern  : MonoBehaviour
{
	void OnPostRender()
	{
		// Set your materials
		GL.PushMatrix();
		// yourMaterial.SetPass( );
		// Draw your stuff
		GL.PopMatrix();
	}
}
