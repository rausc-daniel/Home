Shader "Custom/Dizziness"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Dizziness("Dizziness", float) = 0
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
			float _Dizziness;


            fixed4 frag (v2f i) : SV_Target
            {
				float2 uv = i.uv;
				uv -= float2(1, 0) * sin(uv[1] / 10 * _Dizziness * 20 + _Time[1]) * _Dizziness / 500;
				float4 tex = tex2D(_MainTex, uv);
				return tex;
            }
            ENDCG
        }
    }
}
