Shader "Sunday/Teleport" {
	Properties {
		[NoScaleOffset] _NoiseTexture ("Noise Texture", 2D) = "white" {}
		_SpeedX ("Speed X", Range(-2, 2)) = -1
		_SpeedY ("Speed Y", Range(-2, 2)) = 0
		_Mask ("Mask", 2D) = "white" {}
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
}