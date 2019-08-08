#include "GraphicsEngine.h"
#include "SwapChain.h"
#include "DeviceContext.h"
#include "VertexBuffer.h"
#include "VertexShader.h"
#include "IndexBuffer.h"
#include "PixelShader.h"
#include "ConstantBuffer.h"

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

	_d3dDevice->QueryInterface(__uuidof(IDXGIDevice), (void**)& _dxgiDevice);
	_dxgiDevice->GetParent(__uuidof(IDXGIAdapter), (void**)& _dxgiAdapter);
	_dxgiAdapter->GetParent(__uuidof(IDXGIFactory), (void**)& _dxgiFactory);

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

SwapChain* GraphicsEngine::CreateSwapChain() {

	return new SwapChain();
}

DeviceContext* GraphicsEngine::GetImmediateDeviceContext() {
	return this->_immDeviceContext;
}

VertexBuffer* GraphicsEngine::CreateVertexBuffer() {
	return new VertexBuffer();
}

IndexBuffer* GraphicsEngine::CreateIndexBuffer() {
	return new IndexBuffer();
}

ConstantBuffer* GraphicsEngine::CreateConstantBuffer() {
	return new ConstantBuffer();
}

VertexShader* GraphicsEngine::CreateVertexShader(const void* shaderByteCode, size_t byteCodeSize) {
	VertexShader* vertexShader = new VertexShader();

	if (!vertexShader->Init(shaderByteCode, byteCodeSize)) {
		vertexShader->Release();
		return nullptr;
	}

	return vertexShader;
}

PixelShader* GraphicsEngine::CreatePixelShader(const void* shaderByteCode, size_t byteCodeSize) {
	PixelShader* pixelShader = new PixelShader();

	if (!pixelShader->Init(shaderByteCode, byteCodeSize)) {
		pixelShader->Release();
		return nullptr;
	}

	return pixelShader;
}

bool GraphicsEngine::CompileVertexShader(const wchar_t* fileName, const char* entryPointName, void** shaderByteCode, size_t* byteCodeSize) {
	ID3DBlob* errblob = nullptr;
	if (!SUCCEEDED(D3DCompileFromFile(fileName, nullptr, nullptr, entryPointName, "vs_5_0", 0, 0, &_blob, &errblob))) {
		if (errblob)
			errblob->Release();
		return false;
	}

	*shaderByteCode = _blob->GetBufferPointer();
	*byteCodeSize = _blob->GetBufferSize();

	return true;
}

bool GraphicsEngine::CompilePixelShader(const wchar_t* fileName, const char* entryPointName, void** shaderByteCode, size_t* byteCodeSize) {
	ID3DBlob* errblob = nullptr;
	if (!SUCCEEDED(D3DCompileFromFile(fileName, nullptr, nullptr, entryPointName, "ps_5_0", 0, 0, &_blob, &errblob))) {
		if (errblob)
			errblob->Release();
		return false;
	}

	*shaderByteCode = _blob->GetBufferPointer();
	*byteCodeSize = _blob->GetBufferSize();

	return true;
}

void GraphicsEngine::ReleaseCompiledShader() {
	if (_blob) _blob->Release();
}

GraphicsEngine* GraphicsEngine::Get() {
	static GraphicsEngine engine;
	return &engine;
}
