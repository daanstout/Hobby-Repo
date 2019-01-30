#include "DeviceContext.h"
#include "SwapChain.h"


DeviceContext::DeviceContext(ID3D11DeviceContext* deviceContext) :_deviceContext(deviceContext) {}


DeviceContext::~DeviceContext() {}

bool DeviceContext::ClearRenderTargetColor(SwapChain* swapChain, float r, float g, float b, float a) {
	FLOAT clearColor[] = { r, g, b, a };
	_deviceContext->ClearRenderTargetView(swapChain->_renderTargetView, clearColor);

	return true;
}

bool DeviceContext::Release() {
	_deviceContext->Release();
	delete this;
	return true;
}
