Shader "Custom/InverseSquareGradientShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Center ("Center", Vector) = (0,0,0)
        _Mass ("Mass", Float) = 1000.0
        _G ("GravitationalConstant", Float) = 0.0000000000667430
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        struct Input
        {
            float3 worldPos;
        };

        float4 _Color;
        float3 _Center;
        float _Mass;
        float _G;

        void surf (Input IN, inout SurfaceOutput o)
        {
            float distanceFromCenter = distance(IN.worldPos, _Center);
            float gravityStrength = _G * _Mass / (distanceFromCenter * distanceFromCenter);
            float gradient = saturate(gravityStrength / 1.0); // Adjust the denominator to fit visualization needs
            float4 color = lerp(float4(1, 0, 0, 1), float4(0, 1, 0, 1), gradient);
            o.Albedo = color.rgb;
            o.Alpha = color.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
