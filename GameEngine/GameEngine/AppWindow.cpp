#include "AppWindow.h"

struct vec3 {
	float x, y, z;
};

struct vertex {
	vec3 position;
};


AppWindow::AppWindow() {}


AppWindow::~AppWindow() {}

void AppWindow::OnCreate() {
	Window::OnCreate();
	GraphicsEngine::Get()->Init();
	_swapChain = GraphicsEngine::Get()->CreateSwapChain();

	RECT rc = this->GetClientWindowRect();
	_swapChain->Init(this->_hwnd, rc.right - rc.left, rc.bottom - rc.top);

	vertex list[] = {
		{-0.5f,-0.5f,0.0f}, // POS1
		{-0.5f, 0.5f,0.0f}, // POS2
		{ 0.5f,0.5f,0.0f},

		{ 0.5f,0.5f,0.0f }, // POS1
		{0.5f, -0.5f,0.0f}, // POS2
		{-0.5f,-0.5f,0.0f}
	};

	//vertex list[] = {
	//	{-0.5f,-0.5f,0.0f}, // POS1
	//	{-0.5f, 0.5f,0.0f}, // POS2
	//	{ 0.5f,-0.5f,0.0f},
	//	{ 0.5f,0.5f,0.0f } // POS1
	//};

	_vertexBuffer = GraphicsEngine::Get()->CreateVertexBuffer();
	UINT sizeList = ARRAYSIZE(list);

	GraphicsEngine::Get()->CreateShaders();

	void* shaderByteCode = nullptr;
	UINT shaderSize = 0;
	GraphicsEngine::Get()->GetShadderBufferAndSize(&shaderByteCode, &shaderSize);

	bool res = _vertexBuffer->Load(list, sizeof(vertex), sizeList, shaderByteCode, shaderSize);

}

void AppWindow::OnUpdate() {
	Window::OnUpdate();
	GraphicsEngine::Get()->GetImmediateDeviceContext()->ClearRenderTargetColor(this->_swapChain, 0, 0, 1, 1);

	RECT rc = this->GetClientWindowRect();
	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetViewportSize(rc.right - rc.left, rc.bottom - rc.top);
	GraphicsEngine::Get()->SetShaders();

	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetVertexBuffer(_vertexBuffer);

	GraphicsEngine::Get()->GetImmediateDeviceContext()->DrawTriangleList(_vertexBuffer->GetSizeVertexList(), 0);
	//GraphicsEngine::Get()->GetImmediateDeviceContext()->DrawTriangleStrip(_vertexBuffer->GetSizeVertexList(), 0);

	_swapChain->Present(false);
}

void AppWindow::OnDestroy() {
	Window::OnDestroy();

	_swapChain->Release();
	_vertexBuffer->Release();
	GraphicsEngine::Get()->Release();
}
