#if OPENGL
	#define PS_SHADERMODEL ps_3_0
#elif SM4
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif


#define MAX_LIGHTS 20

sampler inputTexture;

float2 positions[MAX_LIGHTS];
float radiuses[MAX_LIGHTS];
float4 lightColors[MAX_LIGHTS];
float2 screenSize;
int lightCount;

float4 MainPS(float2 textureCoordinates: TEXCOORD0) : COLOR0
{
	float4 color = tex2D(inputTexture, textureCoordinates);
	float4 newColor = float4(0, 0, 0, 1);

	for (int i = 0; i < lightCount; i++)
	{
		float distance = length(textureCoordinates * screenSize - positions[i]);

		if (distance < radiuses[i])
		{
			newColor = lerp(newColor, lightColors[i], 1 - distance / radiuses[i]);
		}
	}
	color *= newColor;

	return color;
}

technique Techninque1
{
	pass Pass1
	{
		AlphaBlendEnable = TRUE;
		DestBlend = INVSRCALPHA;
		SrcBlend = SRCALPHA;
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};