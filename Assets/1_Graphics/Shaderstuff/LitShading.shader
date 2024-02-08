Shader "Hidden/LitShading"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _CharacterPosition("Char pose",vector) = (0,0,0,0)
        _CircleRadius("Spotlight Size",Range(0,20)) = 3
        _RingSize("Ring size",Range(0,5)) = 1
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
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _CharacterPosition;
            float _CircleRadius;
            float _RingSize;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                
                float intens = col.x * 0.299 + col.y * 0.587 + col.z *0.114;
                col = fixed4(intens,intens,intens,col.w); // default color

                float dist = distance(i.worldPos,_CharacterPosition.xyz);

                //This is the Players Spotlight
                if(dist < _CircleRadius){
                    col = tex2D(_MainTex,i.uv);
                }
                //this is the Blending section
                else if (dist > _CircleRadius && dist < _CircleRadius + _RingSize){
                    float blendStrength = dist - _CircleRadius;
                    col = lerp(tex2D(_MainTex,i.uv),intens,blendStrength / _RingSize);
                    }
                return col;
            }
            ENDCG
        }
    }
}
