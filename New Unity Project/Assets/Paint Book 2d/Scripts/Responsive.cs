using UnityEngine;
using System.Collections;


public class Responsive : MonoBehaviour
{
		public ScaleType scaleType = ScaleType.ASPECT_RATIO;
		public ResponsiveMode responsiveMode = ResponsiveMode.AWAKE;
		public float xposfrac = 0.5f;
		public float yposfrac = 0.5f;
		public float xscalefrac = 0.1f;
		public float yscalefrac = 0.1f;
		public float aspectfrac = 1;
		public bool doScale = true;
		public bool doTranslate = true;
		public bool isEnabled = true;
		public Camera cam;
	
		void Awake ()
		{
				if (cam == null) {
						cam = Camera.main;
				}
		
				if (isEnabled) {
						if (responsiveMode == ResponsiveMode.AWAKE) {
								SetPositionAndScale ();
						}
				}
		}

		void Update ()
		{
				if (isEnabled) {
						if (responsiveMode == ResponsiveMode.UPDATE) {
								SetPositionAndScale ();
						}
				}
		}

		private void SetPositionAndScale ()
		{
				if (doTranslate) {
						PercentagePositioning ();
				}
				if (doScale) {
						if (scaleType == ScaleType.ASPECT_RATIO) {
								AspectRatioScaling ();
						} else if (scaleType == ScaleType.PERCENTAGE) {
								PercentageScaling ();
						}
				}
		}
	
		private void PercentagePositioning ()
		{
				int swidth = Screen.width;
				int sheight = Screen.height;
		
				Vector3 positionworldvector = cam.ScreenToWorldPoint (new Vector2 (swidth * xposfrac, sheight * yposfrac));
				transform.position = new Vector3 (positionworldvector.x, positionworldvector.y, transform.position.z);
		}
	
		private void PercentageScaling ()
		{
				int swidth = Screen.width;
				int sheight = Screen.height;
		
				Vector3 sccaleworldvector = cam.ScreenToWorldPoint (new Vector2 (swidth, sheight));
				transform.localScale = new Vector3 (sccaleworldvector.x * xscalefrac, sccaleworldvector.y * yscalefrac, transform.localScale.z);
		}
	
		private void AspectRatioScaling ()
		{
				float aspectRatio = cam.aspect;
				transform.localScale = new Vector3 (aspectRatio * aspectfrac, aspectRatio * aspectfrac, aspectRatio * aspectfrac);
		}
	
		public enum ScaleType
		{
				PERCENTAGE,
				ASPECT_RATIO
		}

		public enum ResponsiveMode
		{
				AWAKE,
				UPDATE
		}
}