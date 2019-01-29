#pragma once
#include <d3d11.h>

class SwapChain {
private:
	IDXGISwapChain* _swapChain;
public:
	// Constructors
	SwapChain();
	~SwapChain();

	// Functions
	// Initializes the SwapChain
	bool Init(HWND hwnd, UINT width, UINT height);
	// Releases the SwapChain
	bool Release();
};

