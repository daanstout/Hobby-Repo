#pragma once

#include <d3d11.h>

class SwapChain;

class GraphicsEngine {
private:
	ID3D11Device* _d3dDevice;
	D3D_FEATURE_LEVEL _featureLevel;
	ID3D11DeviceContext* _immContext;
	// IDXGI Variables
	IDXGIDevice* _dxgiDevice;
	IDXGIAdapter* _dxgiAdapter;
	IDXGIFactory* _dxgiFactory;

	friend class SwapChain;
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

	// SINGLETON
	static GraphicsEngine* Get();
};

