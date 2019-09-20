#include "AppWindow.h"
#include <Windows.h>
#include "Vector3D.h"
#include "Matrix4x4.h"
#include "InputSystem.h"
#include <stdio.h>
#include <iostream>

struct vertex {
	Vector3D position;
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
	
	deltaScale += deltaTime / 0.55f;

	//cc.world.SetScale(Vector3D::lerp(Vector3D(0.5, 0.5, 0), Vector3D(1.0f, 1.0f, 0), (sin(deltaScale) + 1.0f) / 2.0f));

	//temp.SetTranslation(Vector3D::lerp(Vector3D(-1.5f, -1.5f, 0), Vector3D(1.5f, 1.5f, 0), deltaPosition));

	//cc.world *= temp;

	cc.world.SetScale(Vector3D(1, 1, 1));

	temp.SetIdentity();
	temp.SetRotationZ(0.0f);
	cc.world *= temp;

	temp.SetIdentity();
	temp.SetRotationY(rotY);
	cc.world *= temp;

	temp.SetIdentity();
	temp.SetRotationX(rotX);
	cc.world *= temp;


	cc.view.SetIdentity();
	cc.projection.SetOrtholH(
		(this->GetClientWindowRect().right - this->GetClientWindowRect().left) / 300.0f,
		(this->GetClientWindowRect().bottom - this->GetClientWindowRect().top) / 300.0f,
		-4.0f,
		4.0f
	);

	_constantBuffer->Update(GraphicsEngine::Get()->GetImmediateDeviceContext(), &cc);
}


AppWindow::~AppWindow() {}

void AppWindow::OnCreate() {
	Window::OnCreate();
	
	InputSystem::Get()->AddListener(this);

	GraphicsEngine::Get()->Init();
	_swapChain = GraphicsEngine::Get()->CreateSwapChain();

	RECT rc = this->GetClientWindowRect();
	_swapChain->Init(this->_hwnd, rc.right - rc.left, rc.bottom - rc.top);

	vertex vertexList[] = {
		//			X	Y		Z		Clr1	R	G	B		Clr2	R	G	B
		// Front Face
		{Vector3D(-0.5f,-0.5f,-0.5f),	Vector3D(1, 0, 0),		Vector3D(0.2f, 0, 0)},
		{Vector3D(-0.5f,0.5f,-0.5f),	Vector3D(1, 1, 0),		Vector3D(0.2f, 0.2f, 0)},
		{Vector3D(0.5f,0.5f,-0.5f),		Vector3D(1, 1, 0),		Vector3D(0.2f, 0.2f, 0)},
		{Vector3D(0.5f,-0.5f,-0.5f),	Vector3D(1, 0, 0),		Vector3D(0.2f, 0, 0)},
		// Back Face
		{Vector3D(0.5f,-0.5f,0.5f),		Vector3D(0, 1, 0),		Vector3D(0, 0.2f, 0)},
		{Vector3D(0.5f, 0.5f,0.5f),		Vector3D(0, 1, 1),		Vector3D(0, 0.2f, 0.2f)},
		{Vector3D(-0.5f,0.5f,0.5f),		Vector3D(0, 1, 1),		Vector3D(0, 0.2f, 0.2f)},
		{Vector3D(-0.5f,-0.5f,0.5f),	Vector3D(0, 1, 0),		Vector3D(0, 0.2f, 0)}
	};

	_vertexBuffer = GraphicsEngine::Get()->CreateVertexBuffer();
	UINT sizeList = ARRAYSIZE(vertexList);

	unsigned int indexList[] = {
		// Front Side
		0, 1, 2,
		2, 3, 0,

		// Back Side
		4, 5, 6,
		6, 7, 4,

		// Top Side
		1, 6, 5,
		5, 2, 1,

		// Bottom Side
		7, 0, 3,
		3, 4, 7,

		//Right Side
		3, 2, 5,
		5, 4, 3,

		// Left Side
		7, 6, 1,
		1, 0, 7
	};

	_indexBuffer = GraphicsEngine::Get()->CreateIndexBuffer();
	UINT sizeIndexList = ARRAYSIZE(indexList);

	bool b = _indexBuffer->Load(indexList, sizeIndexList);

	void* shaderByteCode = nullptr;
	size_t shaderSize = 0;
	GraphicsEngine::Get()->CompileVertexShader(L"VertexShader.hlsl", "vsmain", &shaderByteCode, &shaderSize);

	_vertexShader = GraphicsEngine::Get()->CreateVertexShader(shaderByteCode, shaderSize);

	bool res = _vertexBuffer->Load(vertexList, sizeof(vertex), sizeList, shaderByteCode, shaderSize);

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

	InputSystem::Get()->Update();

	GraphicsEngine::Get()->GetImmediateDeviceContext()->ClearRenderTargetColor(this->_swapChain, 0, 0, 1, 1);

	RECT rc = this->GetClientWindowRect();
	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetViewportSize(rc.right - rc.left, rc.bottom - rc.top);

	UpdateQuadPosition();

	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetConstantBuffer(_vertexShader, _constantBuffer);
	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetConstantBuffer(_pixelShader, _constantBuffer);

	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetVertexShader(_vertexShader);
	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetPixelShader(_pixelShader);

	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetVertexBuffer(_vertexBuffer);
	GraphicsEngine::Get()->GetImmediateDeviceContext()->SetIndexBuffer(_indexBuffer);

	//GraphicsEngine::Get()->GetImmediateDeviceContext()->DrawTriangleList(_vertexBuffer->GetSizeVertexList(), 0);
	//GraphicsEngine::Get()->GetImmediateDeviceContext()->DrawTriangleStrip(_vertexBuffer->GetSizeVertexList(), 0);
	GraphicsEngine::Get()->GetImmediateDeviceContext()->DrawIndexedTriangleList(_indexBuffer->GetSizeIndexList(),0,  0);

	_swapChain->Present(true);

	oldDelta = newDelta;
	newDelta = ::GetTickCount();

	deltaTime = oldDelta ? ((newDelta - oldDelta) / 1000.0f) : 0;

	std::cout << deltaTime << std::endl;
}

void AppWindow::OnDestroy() {
	Window::OnDestroy();

	_swapChain->Release();
	_vertexBuffer->Release();
	_indexBuffer->Release();
	_constantBuffer->Release();
	_vertexShader->Release();
	_pixelShader->Release();
	GraphicsEngine::Get()->Release();
}

void AppWindow::onKeyDown(int key) {
	if (key == 'W') {
		rotX += 5.0f * deltaTime;
	} else if (key == 'S') {
		rotX -= 5.0f * deltaTime;
	} else if (key == 'A') {
		rotY += 5.0f * deltaTime;
	} else if (key == 'D') {
		rotY -= 5.0f * deltaTime;
	}
}

void AppWindow::onKeyUp(int key) {
	
}
