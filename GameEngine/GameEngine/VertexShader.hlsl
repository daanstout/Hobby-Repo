struct VS_INPUT {
	float4 position: POSITION;
	float4 position1: POSITION1;
	float3 color: COLOR;
	float3 color1: COLOR1;
};

struct VS_OUTPUT {
	float4 position: SV_POSITION;
	float3 color: COLOR;
	float3 color1: COLOR1;
};

cbuffer constant: register(b0) {
	row_major float4x4 world;
	row_major float4x4 view;
	row_major float4x4 projection;
	unsigned int time;
};


VS_OUTPUT vsmain(VS_INPUT input) {
	VS_OUTPUT output = (VS_OUTPUT)0;

	//output.position = lerp(input.position, input.position1, (float)((sin((float)(time / (float)1000.0f)) + 1.0f) / 2.0f));
	// World Space
	output.position = mul(input.position, world);
	// View Space
	output.position = mul(output.position, view);
	// Screen Space
	output.position = mul(output.position, projection);

	output.color = input.color;
	output.color1 = input.color1;

	return output;
}