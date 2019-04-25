using UnityEngine;
using System.Collections;

public class FillingHandler : MonoBehaviour
{
		public AudioSource audioSource;
		public AudioClip fillAudioClip;
		public Brush brush;
		private Vector3 Postion;

		void Start ()
		{
				if (audioSource == null) {
						audioSource = Camera.main.GetComponent<AudioSource> ();
				}
		}
	
		
		void Update ()
		{
				Postion = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Postion.z = -5;
				if (Input.GetMouseButtonDown (0)) { 
						RayCast2D ();
				} 

				if (brush != null)
						brush.transform.position = Postion;
		}
	
		
		private void RayCast2D ()
		{
				RaycastHit2D rayCastHit2D = Physics2D.Raycast (Postion, Vector2.zero);
		
				if (rayCastHit2D.collider == null) {
						return;
				}
		
				if (rayCastHit2D.collider.tag == "BrushColor") {
			  			 
						brush.currentColor = rayCastHit2D.collider.GetComponent<BrushColor> ().value;
						brush.transform.GetChild(0).GetComponent<SpriteRenderer>().color = brush.currentColor;
				} else if (rayCastHit2D.collider.tag == "ImagePart") {
			            
						rayCastHit2D.collider.GetComponent<SpriteRenderer> ().color = brush.currentColor;
						audioSource.clip = fillAudioClip;
						audioSource.Play();
				}
		}
}