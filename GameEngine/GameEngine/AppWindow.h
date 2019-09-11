#pragma once
#include "Window.h"
#include "GraphicsEngine.h"
#include "SwapChain.h"
#include "DeviceContext.h"
#include "VertexBuffer.h"
#include "VertexShader.h"
#include "IndexBuffer.h"
#include "PixelShader.h"
#include "ConstantBuffer.h"
#include "InputListener.h"

class AppWindow : public Window, public InputListener {
private:
	SwapChain* _swapChain;
	VertexBuffer* _vertexBuffer;
	VertexShader* _vertexShader;
	IndexBuffer* _indexBuffer;
	PixelShader* _pixelShader;
	ConstantBuffer* _constantBuffer;

	long oldDelta;
	long newDelta;
	float deltaTime;

	float deltaPosition;
	float deltaScale;

	float rotX = 0.0f;
	float rotY = 0.0f;
public:
	AppWindow();

	void UpdateQuadPosition();

	~AppWindow();

	// Inherited via Window
	virtual void OnCreate() override;
	virtual void OnUpdate() override;
	virtual void OnDestroy() override;

	// Inherited via InputListener
	virtual void onKeyDown(int key) override;
	virtual void onKeyUp(int key) override;
};
