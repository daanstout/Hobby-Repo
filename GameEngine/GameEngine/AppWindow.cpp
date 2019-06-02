#include "AppWindow.h"
#include <Windows.h>
#include "Vector3D.h"
#include "Matrix4x4.h"
#include <stdio.h>
#include <iostream>

struct vertex {
	Vector3D position;
	Vector3D position1;
	Vector3D color;
	Vector3D color1;
};

__declspec(align(16))
struct constant {
	Matrix4x4 world;
	Matrix4x4 view;
	Matrix4x4 projection;
	unsigned int time;
};


AppWindow::AppWindow() {}

void AppWindow::UpdateQuadPosition() {

	constant cc;
	cc.time = ::GetTickCount();

	deltaPosition += deltaTime / 10.0f;

	if (deltaPosition > 1.0f)
		deltaPosition = 0;

	Matrix4x4 temp;

	//cc.world.SetTranslation(Vector3D::lerp(Vector3D(-2, -2, 0), Vector3D(2, 2, 0), deltaPosition));
	
	deltaScale += deltaTime / 0.15f;

	cc.world.SetScale(Vector3D::lerp(Vector3D(0.5, 0.5, 0), Vector3D(1.0f, 1.0f, 0), (sin(deltaScale) + 1.0f) / 2.0f));

	temp.SetTranslation(Vector3D::lerp(Vector3D(-1.5f, -1.5f, 0), Vector3D(1.5f, 1.5f, 0), deltaPosition));

	cc.world *= temp;


	cc.view.SetIdentity();
	cc.projection.SetOrtholH(
		(this->GetClientWindowRect().right - this->GetClientWindowRect().left) / 400.0f,
		(this->GetClientWindowRect().bottom - this->GetClientWindowRect().top) / 400.0f,
		-4.0f,
		4.0f
	);

	_constantBuffer->Update(GraphicsEngine::Get()->GetImmediateDeviceContext(), &cc);
}


AppWindow::~AppWindow() {}

void AppWindow::OnCreate() {
	Window::OnCreate();
	GraphicsEngine::Get()->Init();
	_swapChain = GraphicsEngine::Get()->CreateSwapChain();

	RECT rc = this->GetClientWindowRect();
	_swapChain->Init(this->_hwnd, rc.right - rc.left, rc.bottom - rc.top);

	//vertex list[] = {
	//	{-0.5f,-0.5f,0.0f}, // POS1
	//	{-0.5f, 0.5f,0.0f}, // POS2
	//	{ 0.5f,0.5f,0.0f},

	//	{ 0.5f,0.5f,0.0f }, // POS1
	//	{0.5f, -0.5f,0.0f}, // POS2
	//	{-0.5f,-0.5f,0.0f}
	//};

	vertex list[] = {
		{Vector3D(-0.5f,-0.5f,0.0f),	Vector3D(-0.32f, -0.11f, 0.0f),		Vector3D(0, 0, 0),		Vector3D(0, 1, 0)}, // POS1
		{Vector3D(-0.5f, 0.5f,0.0f),	Vector3D(-0.11f, 0.78f, 0.0f),		Vector3D(1, 1, 0),		Vector3D(0, 1, 1)}, // POS2
		{Vector3D(0.5f,-0.5f,0.0f),		Vector3D(0.75f, -0.73f, 0.0f),		Vector3D(0, 0, 1),		Vector3D(1, 0, 0)},
		{Vector3D(0.5f,0.5f,0.0f),		Vector3D(0.88f, 0.77f, 0.0f),		Vector3D(1, 1, 1),		Vector3D(0, 0, 1)} // POS11
	};

	_vertexBuffer = GraphicsEngine::Get()->CreateVertexBuffer();
	UINT sizeList = ARRAYSIZE(list);

	void* shaderByteCode = nullptr;
	size_t shaderSize = 0;
	GraphicsEngine::Get()->CompileVertexShader(L"VertexShader.hlsl", "vsmain", &shaderByteCode, &shaderSize);

	_vertexShader = GraphicsEngine::Get()->CreateVertexShader(shaderByteCode, shaderSize);

	bool res = _vertexBuffer->Load(list, sizeof(vertex), sizeList, shaderByteCode, shaderSize);

	GraphicsEngine::Get()->ReleaseCompiledShader();



	GraphicsEngine::Get()->CompilePixelShader(L"PixelShader.hlsl", "psmain", &shaderByteCode, &shaderSize);

	_pixelShader = GraphicsEngine::Get()->CreatePixelShader(shaderByteCode, shaderSize);

	GraphicsEngine::Get()->ReleaseCompiledShader();


	constant cc;

	cc.time = 0;

	_constantBuffer = GraphicsEngine::Get()->CreateConstantBuffer();

	_constantBuffer->Load(&cc, sizeof(constant));
}

void AppWindow::OnUpdate() {
	Window::OnUpdate();
	GraphicsEngine::Get()->GetImmediateDeviceContext()->ClearRenderTargetColor(this->_swapChain, 0, 0, 1, 1);

	RECT rc = this->GetClientWindowRect();
	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetViewportSize(rc.right - rc.left, rc.bottom - rc.top);

	UpdateQuadPosition();

	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetConstantBuffer(_vertexShader, _constantBuffer);
	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetConstantBuffer(_pixelShader, _constantBuffer);

	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetVertexShader(_vertexShader);
	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetPixelShader(_pixelShader);

	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetVertexBuffer(_vertexBuffer);

	//GraphicsEngine::Get()->GetImmediateDeviceContext()->DrawTriangleList(_vertexBuffer->GetSizeVertexList(), 0);
	GraphicsEngine::Get()->GetImmediateDeviceContext()->DrawTriangleStrip(_vertexBuffer->GetSizeVertexList(), 0);

	_swapChain->Present(false);

	oldDelta = newDelta;
	newDelta = ::GetTickCount();

	std::cout << oldDelta << " - " << newDelta << std::endl;

	deltaTime = oldDelta ? ((newDelta - oldDelta) / 1000.0f) : 0;

	std::cout << deltaTime << std::endl;
}

void AppWindow::OnDestroy() {
	Window::OnDestroy();

	_swapChain->Release();
	_vertexBuffer->Release();
	_vertexShader->Release();
	_pixelShader->Release();
	GraphicsEngine::Get()->Release();
}
