#pragma once

#include <d3d11.h>

class SwapChain;
class DeviceContext;
class VertexBuffer;

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

	ID3DBlob* _vsBlob = nullptr;
	ID3DBlob* _psBlob = nullptr;
	ID3D11VertexShader* _vertexShader = nullptr;
	ID3D11PixelShader* _pixelShader = nullptr;

	friend class SwapChain;
	friend class VertexBuffer;
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
	bool CreateShaders();
	void GetShadderBufferAndSize(void** bytecode, UINT* size);
	bool SetShaders();

	// SINGLETON
	static GraphicsEngine* Get();
};

