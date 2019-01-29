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
}

void AppWindow::OnDestroy() {
	Window::OnDestroy();

	_swapChain->Release();
	GraphicsEngine::Get()->Release();
}
