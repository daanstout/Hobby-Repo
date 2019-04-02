#include "PixelShader.h"
#include "GraphicsEngine.h"


bool PixelShader::Init(const void* shaderByteCode, size_t byteCodeSize) {
	if (!SUCCEEDED(GraphicsEngine::Get()->_d3dDevice->CreatePixelShader(shaderByteCode, byteCodeSize, nullptr, &_pixelShader)))
		return false;

	return true;
}

PixelShader::PixelShader() {}

void PixelShader::Release() {
	_pixelShader->Release();
	delete this;
}

PixelShader::~PixelShader() {}
