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

class AppWindow : public Window {
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
public:
	AppWindow();

	void UpdateQuadPosition();

	~AppWindow();

	// Inherited via Window
	virtual void OnCreate() override;
	virtual void OnUpdate() override;
	virtual void OnDestroy() override;
};

