Shader "NewShader" 
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Color ("Tint", Color) = (1, 1, 1, 1)
        _AfterimageDuration ("Afterimage Duration", Range(0, 1)) = 0.5
        _Speed ("Speed", Range(0, 10)) = 2
    }
	SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert
        #pragma target 4.5

        sampler2D _MainTex;
        float4 _Color;
        float _AfterimageDuration;
        float _Speed;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            float4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;

            // Create afterimage effect
            float ghostFade = 0;
            for (int i = 1; i <= 10; i++)
            {
                float2 ghostUV = IN.uv_MainTex + float2(0, _Speed * _AfterimageDuration * i * 0.01);
                float4 ghostColor = tex2D(_MainTex, ghostUV) * _Color;
                ghostFade += (_AfterimageDuration * ghostColor.a) / (i * 1.0);
            }
            o.Alpha = c.a + ghostFade;
        }
        ENDCG
    }
    FallBack "UniversalRP/2D/Sprite-Lit-Default"
}

