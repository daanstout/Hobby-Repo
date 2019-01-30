#pragma once

#include <d3d11.h>

class SwapChain;

class DeviceContext {
private:
	ID3D11DeviceContext* _deviceContext;
public:
	DeviceContext(ID3D11DeviceContext* deviceContext);
	~DeviceContext();

	bool ClearRenderTargetColor(SwapChain* swapChain, float r, float g, float b, float a);
	bool Release();
};

