#pragma once

#include <d3d11.h>

class SwapChain;
class VertexBuffer;
class VertexShader;
class PixelShader;
class ConstantBuffer;

class DeviceContext {
private:
	ID3D11DeviceContext* _deviceContext;

	friend class ConstantBuffer;
public:
	DeviceContext(ID3D11DeviceContext* deviceContext);
	~DeviceContext();

	void ClearRenderTargetColor(SwapChain* swapChain, float r, float g, float b, float a);
	void SetVertexBuffer(VertexBuffer* vertexBuffer);
	void DrawTriangleList(UINT vertexCount, UINT startVertexIndex);
	void DrawTriangleStrip(UINT vertexCount, UINT startVertexIndex);
	void SetViewportSize(UINT width, UINT height);

	void SetConstantBuffer(VertexShader* vertexShader, ConstantBuffer* buffer);
	void SetConstantBuffer(PixelShader* pixelShader, ConstantBuffer* buffer);

	void SetVertexShader(VertexShader* vertexShader);
	void SetPixelShader(PixelShader* pixelShader);
	bool Release();
};

