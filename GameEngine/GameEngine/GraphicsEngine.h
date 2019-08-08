#pragma once

#include <d3d11.h>

class SwapChain;
class DeviceContext;
class VertexBuffer;
class IndexBuffer;
class ConstantBuffer;
class VertexShader;
class PixelShader;

class GraphicsEngine {
private:
	ID3D11Device* _d3dDevice;
	D3D_FEATURE_LEVEL _featureLevel;
	ID3D11DeviceContext* _immContext;

	DeviceContext* _immDeviceContext;
	// IDXGI Variables
	IDXGIDevice* _dxgiDevice;
	IDXGIAdapter* _dxgiAdapter;
	IDXGIFactory* _dxgiFactory;

	ID3DBlob* _blob = nullptr;

	ID3DBlob* _vsBlob = nullptr;
	ID3DBlob* _psBlob = nullptr;
	ID3D11VertexShader* _vertexShader = nullptr;
	ID3D11PixelShader* _pixelShader = nullptr;

	friend class SwapChain;
	friend class IndexBuffer;
	friend class VertexBuffer;
	friend class VertexShader;
	friend class PixelShader;
	friend class ConstantBuffer;
public:
	// Constructors
	GraphicsEngine();
	~GraphicsEngine();

	// Functions
	// Initializes the graphics engine and DirectX11 devie
	bool Init();
	// Releases all the resources loaded
	bool Release();

	SwapChain* CreateSwapChain();
	DeviceContext* GetImmediateDeviceContext();
	VertexBuffer* CreateVertexBuffer();
	IndexBuffer* CreateIndexBuffer();
	ConstantBuffer* CreateConstantBuffer();
	VertexShader* CreateVertexShader(const void* shaderByteCode, size_t byteCodeSize);
	PixelShader* CreatePixelShader(const void* shaderByteCode, size_t byteCodeSize);

	bool CompileVertexShader(const wchar_t* fileName, const char* entryPointName, void** shaderByteCode, size_t* byteCodeSize);
	bool CompilePixelShader(const wchar_t* fileName, const char* entryPointName, void** shaderByteCode, size_t* byteCodeSize);

	void ReleaseCompiledShader();

	// SINGLETON
	static GraphicsEngine* Get();
};

