#pragma once
#include <d3d11.h>

class DeviceContext;

class SwapChain {
private:
	IDXGISwapChain* _swapChain;
	ID3D11RenderTargetView* _renderTargetView;

	friend class DeviceContext;
public:
	// Constructors
	SwapChain();
	~SwapChain();

	// Functions
	// Initializes the SwapChain
	bool Init(HWND hwnd, UINT width, UINT height);
	bool Present(bool vsync);
	// Releases the SwapChain
	bool Release();
};

