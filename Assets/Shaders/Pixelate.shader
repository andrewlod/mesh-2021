Shader "Custom/Pixelate"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		size("Size", Range(1,64)) = 8		//Tamanho do pixel: 1 a 64
	}
		SubShader
		{
			Pass{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				uniform sampler2D _MainTex;
				uniform float4 _MainTex_TexelSize;	//"Normalizador" do tamanho do pixel (para encontrar a coordenada dos vizinhos)
				int size;

				//Recebe vértice e texCoord e passa para frente
				struct VertexInput {
					float4 vertex : POSITION;
					float4 texCoord : TEXCOORD0;
				};

				//Recebe a posição e a texCoord, a qual manipulará o pixel atual e seus vizinhos
				struct VertexOutput {
					float4 pos : SV_POSITION;
					float4 texCoord : TEXCOORD0;
				};

				//Apenas recebe parâmetros e passa para a função frag
				VertexOutput vert(VertexInput input) {
					VertexOutput vout;

					vout.pos = UnityObjectToClipPos(input.vertex);
					vout.texCoord = input.texCoord;

					return vout;
				}

				//Faz os cálculos necessários para aplicação do filtro
				float4 frag(VertexOutput input) : COLOR{
					float x = input.texCoord.x;
					float y = input.texCoord.y;

					float _size_x = _MainTex_TexelSize.z / (float)size;
					float _size_y = _MainTex_TexelSize.w / (float)size;


					float4 color = tex2D(_MainTex, float2(floor(x*_size_x) / _size_x, floor(y*_size_y) / _size_y));
					return color;
				}

				ENDCG
			}
		}
			FallBack "Diffuse"
}
