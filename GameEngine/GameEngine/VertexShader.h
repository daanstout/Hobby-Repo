#pragma once
#include <d3d11.h>


class GraphicsEngine;
class DeviceContext;

class VertexShader {
private:
	ID3D11VertexShader* _vertexShader;

	bool Init(const void* shaderByteCode, size_t byteCodeSize);

	friend class GraphicsEngine;
	friend class DeviceContext;
public:
	VertexShader();
	void Release();
	~VertexShader();
};

