// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.18 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.18;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:True,qofs:1,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-7500-OUT,emission-1467-OUT,alpha-316-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:31572,y:32037,ptovrint:False,ptlb:Color Diffuse,ptin:_ColorDiffuse,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Lerp,id:4003,x:32051,y:32517,varname:node_4003,prsc:2|A-1092-RGB,B-8794-RGB,T-421-OUT;n:type:ShaderForge.SFN_Tex2d,id:7307,x:31572,y:32189,ptovrint:False,ptlb:Diffuse Map,ptin:_DiffuseMap,varname:node_7307,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Blend,id:7500,x:32398,y:32374,varname:node_7500,prsc:2,blmd:3,clmp:True|SRC-222-OUT,DST-4003-OUT;n:type:ShaderForge.SFN_Multiply,id:222,x:31902,y:32131,varname:node_222,prsc:2|A-1304-RGB,B-7307-RGB;n:type:ShaderForge.SFN_Color,id:1092,x:31559,y:32398,ptovrint:False,ptlb:Pixel Color1,ptin:_PixelColor1,varname:_ColorDiffuse_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9191176,c2:0.1216479,c3:0.1216479,c4:1;n:type:ShaderForge.SFN_Color,id:8794,x:31559,y:32559,ptovrint:False,ptlb:Pixel Color2,ptin:_PixelColor2,varname:_PixelColor2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:4452,x:29746,y:32357,ptovrint:False,ptlb:U Pixel size ,ptin:_UPixelsize,varname:node_4452,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:25;n:type:ShaderForge.SFN_Noise,id:421,x:31613,y:32818,varname:node_421,prsc:2|XY-3399-OUT;n:type:ShaderForge.SFN_Slider,id:7075,x:29746,y:32547,ptovrint:False,ptlb:V Pixel size ,ptin:_VPixelsize,varname:_UPixelsize_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:25;n:type:ShaderForge.SFN_Append,id:7573,x:30348,y:32430,varname:node_7573,prsc:2|A-4452-OUT,B-7075-OUT;n:type:ShaderForge.SFN_Multiply,id:5974,x:30863,y:32520,varname:node_5974,prsc:2|A-3115-OUT,B-7573-OUT;n:type:ShaderForge.SFN_TexCoord,id:427,x:30175,y:32041,varname:node_427,prsc:2,uv:0;n:type:ShaderForge.SFN_Floor,id:3399,x:31373,y:32818,varname:node_3399,prsc:2|IN-3150-OUT;n:type:ShaderForge.SFN_RemapRange,id:3115,x:30450,y:32169,varname:node_3115,prsc:2,frmn:0,frmx:1,tomn:-0.5,tomx:0.5|IN-427-UVOUT;n:type:ShaderForge.SFN_Panner,id:7715,x:30561,y:32812,varname:node_7715,prsc:2,spu:0,spv:1|UVIN-4868-UVOUT,DIST-7785-OUT;n:type:ShaderForge.SFN_Time,id:9991,x:29836,y:32977,varname:node_9991,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:4868,x:30299,y:32675,varname:node_4868,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:3150,x:31094,y:32774,varname:node_3150,prsc:2|A-5974-OUT,B-7715-UVOUT;n:type:ShaderForge.SFN_Lerp,id:7785,x:30373,y:33017,varname:node_7785,prsc:2|A-7945-OUT,B-5795-OUT,T-1314-OUT;n:type:ShaderForge.SFN_Vector1,id:7945,x:30072,y:32977,varname:node_7945,prsc:2,v1:0;n:type:ShaderForge.SFN_Slider,id:1314,x:30066,y:33306,ptovrint:False,ptlb:Animation Speed,ptin:_AnimationSpeed,varname:node_1314,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Pi,id:857,x:29869,y:33192,varname:node_857,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5795,x:30047,y:33094,varname:node_5795,prsc:2|A-9991-TTR,B-857-OUT;n:type:ShaderForge.SFN_Slider,id:316,x:32286,y:33084,ptovrint:False,ptlb:Transparency,ptin:_Transparency,varname:node_8761,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:9166,x:32061,y:32811,ptovrint:False,ptlb:Emissive,ptin:_Emissive,varname:node_3936,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Multiply,id:1467,x:32477,y:32695,varname:node_1467,prsc:2|A-7500-OUT,B-9166-OUT;proporder:1304-7307-9166-1092-8794-4452-7075-1314-316;pass:END;sub:END;*/

Shader "Ciconia Studio/Effects/Blend/Pixel/Diffuse Animated (2 Sided)" {
    Properties {
        _ColorDiffuse ("Color Diffuse", Color) = (1,1,1,1)
        _DiffuseMap ("Diffuse Map", 2D) = "white" {}
        _Emissive ("Emissive", Range(0, 2)) = 0
        _PixelColor1 ("Pixel Color1", Color) = (0.9191176,0.1216479,0.1216479,1)
        _PixelColor2 ("Pixel Color2", Color) = (1,1,1,1)
        _UPixelsize ("U Pixel size ", Range(0, 25)) = 1
        _VPixelsize ("V Pixel size ", Range(0, 25)) = 1
        _AnimationSpeed ("Animation Speed", Range(0, 1)) = 0
        _Transparency ("Transparency", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Geometry+1"
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
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
            uniform float4 _TimeEditor;
            uniform float4 _ColorDiffuse;
            uniform sampler2D _DiffuseMap; uniform float4 _DiffuseMap_ST;
            uniform float4 _PixelColor1;
            uniform float4 _PixelColor2;
            uniform float _UPixelsize;
            uniform float _VPixelsize;
            uniform float _AnimationSpeed;
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
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
                float4 _DiffuseMap_var = tex2D(_DiffuseMap,TRANSFORM_TEX(i.uv0, _DiffuseMap));
                float4 node_9991 = _Time + _TimeEditor;
                float2 node_3399 = floor((((i.uv0*1.0+-0.5)*float2(_UPixelsize,_VPixelsize))+(i.uv0+lerp(0.0,(node_9991.a*3.141592654),_AnimationSpeed)*float2(0,1))));
                float2 node_421_skew = node_3399 + 0.2127+node_3399.x*0.3713*node_3399.y;
                float2 node_421_rnd = 4.789*sin(489.123*(node_421_skew));
                float node_421 = frac(node_421_rnd.x*node_421_rnd.y*(1+node_421_skew.x));
                float3 node_7500 = saturate(((_ColorDiffuse.rgb*_DiffuseMap_var.rgb)+lerp(_PixelColor1.rgb,_PixelColor2.rgb,node_421)-1.0));
                float3 diffuseColor = node_7500;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = (node_7500*_Emissive);
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,_Transparency);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _ColorDiffuse;
            uniform sampler2D _DiffuseMap; uniform float4 _DiffuseMap_ST;
            uniform float4 _PixelColor1;
            uniform float4 _PixelColor2;
            uniform float _UPixelsize;
            uniform float _VPixelsize;
            uniform float _AnimationSpeed;
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
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _DiffuseMap_var = tex2D(_DiffuseMap,TRANSFORM_TEX(i.uv0, _DiffuseMap));
                float4 node_9991 = _Time + _TimeEditor;
                float2 node_3399 = floor((((i.uv0*1.0+-0.5)*float2(_UPixelsize,_VPixelsize))+(i.uv0+lerp(0.0,(node_9991.a*3.141592654),_AnimationSpeed)*float2(0,1))));
                float2 node_421_skew = node_3399 + 0.2127+node_3399.x*0.3713*node_3399.y;
                float2 node_421_rnd = 4.789*sin(489.123*(node_421_skew));
                float node_421 = frac(node_421_rnd.x*node_421_rnd.y*(1+node_421_skew.x));
                float3 node_7500 = saturate(((_ColorDiffuse.rgb*_DiffuseMap_var.rgb)+lerp(_PixelColor1.rgb,_PixelColor2.rgb,node_421)-1.0));
                float3 diffuseColor = node_7500;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * _Transparency,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
