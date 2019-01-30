#include "AppWindow.h"



AppWindow::AppWindow() {}


AppWindow::~AppWindow() {}

void AppWindow::OnCreate() {
	Window::OnCreate();
	GraphicsEngine::Get()->Init();
	_swapChain = GraphicsEngine::Get()->CreateSwapChain();
	RECT rc = this->GetClientWindowRect();
	_swapChain->Init(this->_hwnd, rc.right - rc.left, rc.bottom - rc.top);
}

void AppWindow::OnUpdate() {
	Window::OnUpdate();
	GraphicsEngine::Get()->GetImmediateDeviceContext()->ClearRenderTargetColor(this->_swapChain, 0, 1, 0, 1);

	_swapChain->Present(false);
}

void AppWindow::OnDestroy() {
	Window::OnDestroy();

	_swapChain->Release();
	GraphicsEngine::Get()->Release();
}
