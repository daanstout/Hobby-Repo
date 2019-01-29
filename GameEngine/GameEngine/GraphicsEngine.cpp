#include "GraphicsEngine.h"



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

	return true;
}

bool GraphicsEngine::Release() {
	_immContext->Release();
	_d3dDevice->Release();
	return true;
}

GraphicsEngine* GraphicsEngine::Get() {
	static GraphicsEngine engine;
	return &engine;
}
