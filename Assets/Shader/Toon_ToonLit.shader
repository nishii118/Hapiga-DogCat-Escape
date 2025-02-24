Shader "Toon/ToonLit" {
	Properties {
		_Color ("Main Coor", Vector) = (1,1,1,1)
		[NoScaleOffset] _MainTex ("Base (RGB)", 2D) = "white" {}
		_TColor ("Gradient Overlay Top Color", Vector) = (1,1,1,1)
		_BottomColor ("Gradient Overlay Bottom Color", Vector) = (0.23,0,0.95,1)
		_Offset ("Gradient Offset", Range(-4, 4)) = 3.2
		[Toggle(RIM)] _RIM ("Fresnel Rim?", Float) = 0
		_RimColor ("Fresnel Rim Color", Vector) = (0.49,0.94,0.64,1)
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
}