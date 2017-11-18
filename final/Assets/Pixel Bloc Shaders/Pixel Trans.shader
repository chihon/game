// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.18 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.18;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:True,qofs:0,qpre:3,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-7500-OUT,emission-9315-OUT,clip-2794-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:31572,y:32037,ptovrint:False,ptlb:Color Diffuse,ptin:_ColorDiffuse,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Floor,id:2499,x:31635,y:33009,varname:node_2499,prsc:2|IN-653-OUT;n:type:ShaderForge.SFN_TexCoord,id:8412,x:30920,y:32651,varname:node_8412,prsc:2,uv:0;n:type:ShaderForge.SFN_Lerp,id:4003,x:31934,y:32505,varname:node_4003,prsc:2|A-1092-RGB,B-8794-RGB,T-421-OUT;n:type:ShaderForge.SFN_Blend,id:7500,x:32398,y:32374,varname:node_7500,prsc:2,blmd:3,clmp:True|SRC-1304-RGB,DST-4003-OUT;n:type:ShaderForge.SFN_Color,id:1092,x:31559,y:32398,ptovrint:False,ptlb:Pixel Color1,ptin:_PixelColor1,varname:_ColorDiffuse_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9191176,c2:0.1216479,c3:0.1216479,c4:1;n:type:ShaderForge.SFN_Color,id:8794,x:31559,y:32547,ptovrint:False,ptlb:Pixel Color2,ptin:_PixelColor2,varname:_PixelColor2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:4452,x:30708,y:32913,ptovrint:False,ptlb:U Pixel size ,ptin:_UPixelsize,varname:node_4452,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:256;n:type:ShaderForge.SFN_Noise,id:421,x:31829,y:32856,varname:node_421,prsc:2|XY-2499-OUT;n:type:ShaderForge.SFN_Multiply,id:653,x:31334,y:32791,varname:node_653,prsc:2|A-8412-UVOUT,B-1622-OUT;n:type:ShaderForge.SFN_Append,id:1622,x:31130,y:32900,varname:node_1622,prsc:2|A-4452-OUT,B-7075-OUT;n:type:ShaderForge.SFN_Slider,id:7075,x:30708,y:33016,ptovrint:False,ptlb:V Pixel size ,ptin:_VPixelsize,varname:_UPixelsize_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:256;n:type:ShaderForge.SFN_Multiply,id:2794,x:32390,y:32931,varname:node_2794,prsc:2|A-421-OUT,B-1017-OUT;n:type:ShaderForge.SFN_Slider,id:1017,x:32057,y:33147,ptovrint:False,ptlb:Transparency,ptin:_Transparency,varname:node_1017,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:8740,x:32053,y:32764,ptovrint:False,ptlb:Emissive,ptin:_Emissive,varname:node_3936,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Multiply,id:9315,x:32469,y:32648,varname:node_9315,prsc:2|A-7500-OUT,B-8740-OUT;proporder:1304-8740-1092-8794-4452-7075-1017;pass:END;sub:END;*/

Shader "Ciconia Studio/Effects/Blend/Pixel/Trans(Leaves)" {
    Properties {
        _ColorDiffuse ("Color Diffuse", Color) = (1,1,1,1)
        _Emissive ("Emissive", Range(0, 2)) = 0
        _PixelColor1 ("Pixel Color1", Color) = (0.9191176,0.1216479,0.1216479,1)
        _PixelColor2 ("Pixel Color2", Color) = (1,1,1,1)
        _UPixelsize ("U Pixel size ", Range(0, 256)) = 0
        _VPixelsize ("V Pixel size ", Range(0, 256)) = 0
        _Transparency ("Transparency", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _ColorDiffuse;
            uniform float4 _PixelColor1;
            uniform float4 _PixelColor2;
            uniform float _UPixelsize;
            uniform float _VPixelsize;
            uniform float _Transparency;
            uniform float _Emissive;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 normalDirection = i.normalDir;
                float2 node_2499 = floor((i.uv0*float2(_UPixelsize,_VPixelsize)));
                float2 node_421_skew = node_2499 + 0.2127+node_2499.x*0.3713*node_2499.y;
                float2 node_421_rnd = 4.789*sin(489.123*(node_421_skew));
                float node_421 = frac(node_421_rnd.x*node_421_rnd.y*(1+node_421_skew.x));
                clip((node_421*_Transparency) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 node_7500 = saturate((_ColorDiffuse.rgb+lerp(_PixelColor1.rgb,_PixelColor2.rgb,node_421)-1.0));
                float3 diffuseColor = node_7500;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = (node_7500*_Emissive);
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float _UPixelsize;
            uniform float _VPixelsize;
            uniform float _Transparency;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                float2 node_2499 = floor((i.uv0*float2(_UPixelsize,_VPixelsize)));
                float2 node_421_skew = node_2499 + 0.2127+node_2499.x*0.3713*node_2499.y;
                float2 node_421_rnd = 4.789*sin(489.123*(node_421_skew));
                float node_421 = frac(node_421_rnd.x*node_421_rnd.y*(1+node_421_skew.x));
                clip((node_421*_Transparency) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
