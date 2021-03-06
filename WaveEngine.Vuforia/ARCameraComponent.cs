using System;
using WaveEngine.Framework.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;

namespace WaveEngine.Vuforia
{
	public class ARCameraComponent : Camera3D
	{
        private VuforiaService arService;

		public ARCameraComponent()
			: base()
		{
			this.ClearFlags = WaveEngine.Common.Graphics.ClearFlags.DepthAndStencil;
		}

		#region implemented abstract members of Camera

		protected override void Initialize ()
		{
			base.Initialize ();

            this.arService = WaveServices.GetService<VuforiaService>();
		}

		protected override void RefreshDimensions ()
		{
			this.aspectRatio = (float)platformService.ScreenWidth / (float)platformService.ScreenHeight;
			this.width = this.viewportWidth = platformService.ScreenWidth;
			this.height = this.viewportHeight = platformService.ScreenHeight;
		}

		protected override void RefreshView ()
		{
		}

		protected override void RefreshProjection ()
		{
		}

		protected override void Render (TimeSpan gameTime)
		{
			if (this.arService.State == ARState.TRACKING) 
			{
				this.view = this.arService.Pose;
				this.position = this.arService.PoseInv.Translation;
                this.lookAt = this.position + (this.arService.PoseInv.Backward * this.farPlane);

				this.projection = this.arService.GetCameraProjection (this.nearPlane, this.farPlane);

				this.projectionRenderTarget = this.projection;
				this.dirtyViewProjection = true;

				if (platformService.AdapterType != WaveEngine.Common.AdapterType.DirectX) 
				{
					this.projectionRenderTarget.M22 = -this.projectionRenderTarget.M22;
				}
			}

			base.Render (gameTime);
		}
		#endregion
	}
}

