// Simplified Diffuse shader. Differences from regular Diffuse one:
// - fully supports only 1 directional light. Other lights can affect it, but it will be per-vertex/SH.

Shader "Mobile/Diffuse-Color" {
Properties {
	_ColorRili ("Rili Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader {
	Tags{ "Queue" = "AlphaTest" "RenderType" = "TransparentCutout" "IgnoreProjector" = "True" }


	Blend SrcAlpha OneMinusSrcAlpha
	Pass{
		ZWrite On
		ColorMask 0
	}
CGPROGRAM
#pragma surface surf Lambert noforwardadd alpha

sampler2D _MainTex;
fixed4 _ColorRili;

struct Input {
	float2 uv_MainTex;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _ColorRili;

	o.Albedo = c.rgb;
	o.Alpha = _ColorRili.a;
}
ENDCG
}

//Fallback "Mobile/VertexLit"
}
