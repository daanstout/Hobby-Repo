#include "VertexShader.h"
#include "GraphicsEngine.h"


bool VertexShader::Init(const void* shaderByteCode, size_t byteCodeSize) {
	if (!SUCCEEDED(GraphicsEngine::Get()->_d3dDevice->CreateVertexShader(shaderByteCode, byteCodeSize, nullptr, &_vertexShader)))
		return false;

	return true;
}

VertexShader::VertexShader() {}

void VertexShader::Release() {
	_vertexShader->Release();
	delete this;
}

VertexShader::~VertexShader() {}
