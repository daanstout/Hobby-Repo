#include "SwapChain.h"
#include "GraphicsEngine.h"


SwapChain::SwapChain() {}


SwapChain::~SwapChain() {}

bool SwapChain::Init(HWND hwnd, UINT width, UINT height) {
	ID3D11Device* device = GraphicsEngine::Get()->_d3dDevice;

	DXGI_SWAP_CHAIN_DESC desc;
	ZeroMemory(&desc, sizeof(desc));
	desc.BufferCount = 1;
	desc.BufferDesc.Width = width;
	desc.BufferDesc.Height = height;
	desc.BufferDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
	desc.BufferDesc.RefreshRate.Numerator = 60;
	desc.BufferDesc.RefreshRate.Denominator = 1;
	desc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
	desc.OutputWindow = hwnd;
	desc.SampleDesc.Count = 1;
	desc.SampleDesc.Quality = 0;
	desc.Windowed = true;

	// Create the swap chain for the window indicated by the hwnd parameter
	HRESULT res = GraphicsEngine::Get()->_dxgiFactory->CreateSwapChain(device, &desc, &_swapChain);

	if (FAILED(res))
		return false;

	return true;
}

bool SwapChain::Release() {
	_swapChain->Release();
	
	delete this;

	return true;
}
