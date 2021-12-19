// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34375,y:32509,varname:node_3138,prsc:2|emission-9952-OUT;n:type:ShaderForge.SFN_ScreenPos,id:5110,x:32127,y:32199,varname:node_5110,prsc:2,sctp:1;n:type:ShaderForge.SFN_Depth,id:9019,x:32372,y:32337,varname:node_9019,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7214,x:32867,y:32367,varname:node_7214,prsc:2|A-5389-UVOUT,B-8423-OUT;n:type:ShaderForge.SFN_Tex2d,id:9545,x:32881,y:32523,ptovrint:False,ptlb:node_9545,ptin:_node_9545,varname:node_9545,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False|UVIN-7214-OUT;n:type:ShaderForge.SFN_Step,id:5926,x:32891,y:32738,varname:node_5926,prsc:2|A-9545-RGB,B-8764-OUT;n:type:ShaderForge.SFN_NormalVector,id:5224,x:31494,y:32919,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:9742,x:31736,y:32835,varname:node_9742,prsc:2,dt:4|A-1460-OUT,B-5224-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:9208,x:32171,y:32838,varname:node_9208,prsc:2|IN-9742-OUT,IMIN-8038-OUT,IMAX-9439-OUT,OMIN-2083-OUT,OMAX-7609-OUT;n:type:ShaderForge.SFN_Vector1,id:8038,x:31929,y:32865,varname:node_8038,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:9439,x:31930,y:32910,varname:node_9439,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:2083,x:31928,y:32977,ptovrint:False,ptlb:node_2083,ptin:_node_2083,varname:node_2083,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Lerp,id:9829,x:33292,y:32731,varname:node_9829,prsc:2|A-9196-RGB,B-2260-RGB,T-5926-OUT;n:type:ShaderForge.SFN_Color,id:9196,x:33295,y:32954,ptovrint:False,ptlb:BaseColor,ptin:_BaseColor,varname:node_9196,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:2260,x:33301,y:33119,ptovrint:False,ptlb:MultyColor,ptin:_MultyColor,varname:node_2260,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Add,id:5437,x:33524,y:32726,varname:node_5437,prsc:2|A-4338-RGB,B-9829-OUT;n:type:ShaderForge.SFN_Color,id:4338,x:33295,y:32577,ptovrint:False,ptlb:PolkaColor,ptin:_PolkaColor,varname:node_4338,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.6933962,c3:0.9199046,c4:1;n:type:ShaderForge.SFN_Vector1,id:8373,x:32369,y:32595,varname:node_8373,prsc:2,v1:0.7;n:type:ShaderForge.SFN_Time,id:8187,x:31514,y:32657,varname:node_8187,prsc:2;n:type:ShaderForge.SFN_Add,id:8764,x:32685,y:32746,varname:node_8764,prsc:2|A-8373-OUT,B-9213-OUT,C-3619-UVOUT;n:type:ShaderForge.SFN_Vector1,id:9034,x:32107,y:32592,varname:node_9034,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:9213,x:32375,y:32658,varname:node_9213,prsc:2|A-7370-OUT,B-9034-OUT;n:type:ShaderForge.SFN_Abs,id:7370,x:32111,y:32656,varname:node_7370,prsc:2|IN-9867-OUT;n:type:ShaderForge.SFN_Slider,id:2836,x:31353,y:32594,ptovrint:False,ptlb:node_2836,ptin:_node_2836,varname:node_2836,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:20;n:type:ShaderForge.SFN_Multiply,id:7903,x:31680,y:32658,varname:node_7903,prsc:2|A-8187-TSL,B-2836-OUT;n:type:ShaderForge.SFN_Multiply,id:8423,x:32595,y:32414,varname:node_8423,prsc:2|A-9019-OUT,B-8598-OUT;n:type:ShaderForge.SFN_Slider,id:8598,x:32215,y:32496,ptovrint:False,ptlb:node_8598,ptin:_node_8598,varname:node_8598,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.4;n:type:ShaderForge.SFN_Panner,id:5389,x:32591,y:32239,varname:node_5389,prsc:2,spu:0.04,spv:-0.05|UVIN-8363-UVOUT;n:type:ShaderForge.SFN_Cos,id:9867,x:31844,y:32659,varname:node_9867,prsc:2|IN-7903-OUT;n:type:ShaderForge.SFN_Rotator,id:8363,x:32379,y:32209,varname:node_8363,prsc:2|UVIN-5110-UVOUT,SPD-8595-OUT;n:type:ShaderForge.SFN_Slider,id:8595,x:31967,y:32364,ptovrint:False,ptlb:node_8595,ptin:_node_8595,varname:node_8595,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.05,cur:0,max:0.05;n:type:ShaderForge.SFN_LightAttenuation,id:1460,x:31332,y:32808,varname:node_1460,prsc:2;n:type:ShaderForge.SFN_Slider,id:7609,x:31632,y:33058,ptovrint:False,ptlb:node_7609,ptin:_node_7609,varname:node_7609,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.4;n:type:ShaderForge.SFN_Rotator,id:3619,x:32368,y:32799,varname:node_3619,prsc:2|UVIN-5110-UVOUT,ANG-9208-OUT;n:type:ShaderForge.SFN_Lerp,id:410,x:33707,y:32259,varname:node_410,prsc:2|A-7159-RGB,B-625-RGB,T-8127-OUT;n:type:ShaderForge.SFN_Color,id:7159,x:33494,y:32199,ptovrint:False,ptlb:node_7159,ptin:_node_7159,varname:node_7159,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:8127,x:33274,y:32433,ptovrint:False,ptlb:node_8127,ptin:_node_8127,varname:node_8127,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.9689814,max:1;n:type:ShaderForge.SFN_Color,id:625,x:33255,y:32248,ptovrint:False,ptlb:node_625,ptin:_node_625,varname:node_625,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7877358,c2:0.8096691,c3:1,c4:1;n:type:ShaderForge.SFN_Blend,id:9952,x:34013,y:32412,varname:node_9952,prsc:2,blmd:8,clmp:True|SRC-5437-OUT,DST-410-OUT;n:type:ShaderForge.SFN_TexCoord,id:3820,x:33490,y:32492,varname:node_3820,prsc:2,uv:0,uaff:False;proporder:9545-2083-9196-2260-4338-2836-8598-8595-7609-7159-8127-625;pass:END;sub:END;*/

Shader "Shader Forge/Polkadots" {
    Properties {
        _node_9545 ("node_9545", 2D) = "black" {}
        _node_2083 ("node_2083", Float ) = 0
        _BaseColor ("BaseColor", Color) = (0,0,0,1)
        _MultyColor ("MultyColor", Color) = (1,1,1,1)
        _PolkaColor ("PolkaColor", Color) = (1,0.6933962,0.9199046,1)
        _node_2836 ("node_2836", Range(0, 20)) = 0
        _node_8598 ("node_8598", Range(0, 0.4)) = 0
        _node_8595 ("node_8595", Range(-0.05, 0.05)) = 0
        _node_7609 ("node_7609", Range(0, 0.4)) = 0
        _node_7159 ("node_7159", Color) = (1,0,0,1)
        _node_8127 ("node_8127", Range(0, 1)) = 0.9689814
        _node_625 ("node_625", Color) = (0.7877358,0.8096691,1,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            uniform sampler2D _node_9545; uniform float4 _node_9545_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _node_2083)
                UNITY_DEFINE_INSTANCED_PROP( float4, _BaseColor)
                UNITY_DEFINE_INSTANCED_PROP( float4, _MultyColor)
                UNITY_DEFINE_INSTANCED_PROP( float4, _PolkaColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_2836)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8598)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8595)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_7609)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_7159)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8127)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_625)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 projPos : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float4 _PolkaColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _PolkaColor );
                float4 _BaseColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _BaseColor );
                float4 _MultyColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _MultyColor );
                float4 node_568 = _Time;
                float _node_8595_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_8595 );
                float node_8363_ang = node_568.g;
                float node_8363_spd = _node_8595_var;
                float node_8363_cos = cos(node_8363_spd*node_8363_ang);
                float node_8363_sin = sin(node_8363_spd*node_8363_ang);
                float2 node_8363_piv = float2(0.5,0.5);
                float2 node_8363 = (mul(float2((sceneUVs.x * 2 - 1)*(_ScreenParams.r/_ScreenParams.g), sceneUVs.y * 2 - 1).rg-node_8363_piv,float2x2( node_8363_cos, -node_8363_sin, node_8363_sin, node_8363_cos))+node_8363_piv);
                float _node_8598_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_8598 );
                float2 node_7214 = ((node_8363+node_568.g*float2(0.04,-0.05))*(partZ*_node_8598_var));
                float4 _node_9545_var = tex2D(_node_9545,TRANSFORM_TEX(node_7214, _node_9545));
                float4 node_8187 = _Time;
                float _node_2836_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_2836 );
                float node_8038 = 0.0;
                float _node_2083_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_2083 );
                float _node_7609_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_7609 );
                float node_3619_ang = (_node_2083_var + ( ((0.5*dot(attenuation,i.normalDir)+0.5) - node_8038) * (_node_7609_var - _node_2083_var) ) / (1.0 - node_8038));
                float node_3619_spd = 1.0;
                float node_3619_cos = cos(node_3619_spd*node_3619_ang);
                float node_3619_sin = sin(node_3619_spd*node_3619_ang);
                float2 node_3619_piv = float2(0.5,0.5);
                float2 node_3619 = (mul(float2((sceneUVs.x * 2 - 1)*(_ScreenParams.r/_ScreenParams.g), sceneUVs.y * 2 - 1).rg-node_3619_piv,float2x2( node_3619_cos, -node_3619_sin, node_3619_sin, node_3619_cos))+node_3619_piv);
                float4 _node_7159_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_7159 );
                float4 _node_625_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_625 );
                float _node_8127_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_8127 );
                float3 emissive = saturate(((_PolkaColor_var.rgb+lerp(_BaseColor_var.rgb,_MultyColor_var.rgb,step(_node_9545_var.rgb,float3((0.7+(abs(cos((node_8187.r*_node_2836_var)))*0.2)+node_3619),0.0))))+lerp(_node_7159_var.rgb,_node_625_var.rgb,_node_8127_var)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma target 3.0
            uniform sampler2D _node_9545; uniform float4 _node_9545_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _node_2083)
                UNITY_DEFINE_INSTANCED_PROP( float4, _BaseColor)
                UNITY_DEFINE_INSTANCED_PROP( float4, _MultyColor)
                UNITY_DEFINE_INSTANCED_PROP( float4, _PolkaColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_2836)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8598)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8595)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_7609)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_7159)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8127)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_625)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 projPos : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 finalColor = 0;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
