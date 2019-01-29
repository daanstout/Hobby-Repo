#include "GraphicsEngine.h"
#include "SwapChain.h"


GraphicsEngine::GraphicsEngine() {}


GraphicsEngine::~GraphicsEngine() {}

bool GraphicsEngine::Init() {

	D3D_DRIVER_TYPE driverTypes[] = {
		D3D_DRIVER_TYPE_HARDWARE,
		D3D_DRIVER_TYPE_WARP,
		D3D_DRIVER_TYPE_REFERENCE
	};

	D3D_FEATURE_LEVEL featureLevels[] = {
		D3D_FEATURE_LEVEL_11_0
	};

	UINT numDriverTypes = ARRAYSIZE(driverTypes);
	UINT numFeatureLevels = ARRAYSIZE(featureLevels);

	HRESULT res;

	for (UINT driverTypeIndex = 0; driverTypeIndex < numDriverTypes; driverTypeIndex++) {
		res = D3D11CreateDevice(NULL, driverTypes[driverTypeIndex], NULL, NULL, featureLevels, numFeatureLevels, D3D11_SDK_VERSION, &_d3dDevice, &_featureLevel, &_immContext);
		
		if (SUCCEEDED(res))
			break;
	}

	if (FAILED(res))
		return false;

	_d3dDevice->QueryInterface(__uuidof(IDXGIDevice), (void**)&_dxgiDevice);
	_dxgiDevice->GetParent(__uuidof(IDXGIAdapter), (void**)&_dxgiAdapter);
	_dxgiAdapter->GetParent(__uuidof(IDXGIFactory), (void**)&_dxgiFactory);

	return true;
}

bool GraphicsEngine::Release() {
	_dxgiDevice->Release();
	_dxgiAdapter->Release();
	_dxgiFactory->Release();

	_immContext->Release();
	_d3dDevice->Release();
	return true;
}

SwapChain * GraphicsEngine::CreateSwapChain() {

	return new SwapChain();
}

GraphicsEngine* GraphicsEngine::Get() {
	static GraphicsEngine engine;
	return &engine;
}
