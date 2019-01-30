#include "GraphicsEngine.h"
#include "SwapChain.h"
#include "DeviceContext.h"
#include "VertexBuffer.h"

#include <d3dcompiler.h>


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
	//ID3D11DeviceContext* _immContext;

	for (UINT driverTypeIndex = 0; driverTypeIndex < numDriverTypes; driverTypeIndex++) {
		res = D3D11CreateDevice(NULL, driverTypes[driverTypeIndex], NULL, NULL, featureLevels, numFeatureLevels, D3D11_SDK_VERSION, &_d3dDevice, &_featureLevel, &_immContext);

		if (SUCCEEDED(res))
			break;
	}

	if (FAILED(res))
		return false;

	_immDeviceContext = new DeviceContext(_immContext);

	_d3dDevice->QueryInterface(__uuidof(IDXGIDevice), (void**)&_dxgiDevice);
	_dxgiDevice->GetParent(__uuidof(IDXGIAdapter), (void**)&_dxgiAdapter);
	_dxgiAdapter->GetParent(__uuidof(IDXGIFactory), (void**)&_dxgiFactory);

	return true;
}

bool GraphicsEngine::Release() {
	_dxgiDevice->Release();
	_dxgiAdapter->Release();
	_dxgiFactory->Release();

	_immDeviceContext->Release();
	_d3dDevice->Release();
	return true;
}

SwapChain * GraphicsEngine::CreateSwapChain() {

	return new SwapChain();
}

DeviceContext * GraphicsEngine::GetImmediateDeviceContext() {
	return this->_immDeviceContext;
}

VertexBuffer * GraphicsEngine::CreateVertexBuffer() {
	return new VertexBuffer();
}

bool GraphicsEngine::CreateShaders() {
	ID3DBlob* errblob = nullptr;
	D3DCompileFromFile(L"shader.fx", nullptr, nullptr, "vsmain", "vs_5_0", NULL, NULL, &_vsBlob, &errblob);
	D3DCompileFromFile(L"shader.fx", nullptr, nullptr, "psmain", "ps_5_0", NULL, NULL, &_psBlob, &errblob);
	_d3dDevice->CreateVertexShader(_vsBlob->GetBufferPointer(), _vsBlob->GetBufferSize(), nullptr, &_vertexShader);
	_d3dDevice->CreatePixelShader(_psBlob->GetBufferPointer(), _psBlob->GetBufferSize(), nullptr, &_pixelShader);
	return true;
}

void GraphicsEngine::GetShadderBufferAndSize(void ** bytecode, UINT * size) {
	*bytecode = this->_vsBlob->GetBufferPointer();
	*size = this->_vsBlob->GetBufferSize();
}

bool GraphicsEngine::SetShaders() {
	_immContext->VSSetShader(_vertexShader, nullptr, 0);
	_immContext->PSSetShader(_pixelShader, nullptr, 0);
	return true;
}

GraphicsEngine* GraphicsEngine::Get() {
	static GraphicsEngine engine;
	return &engine;
}
