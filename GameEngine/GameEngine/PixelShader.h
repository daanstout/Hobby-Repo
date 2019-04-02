#pragma once
#include <d3d11.h>


class GraphicsEngine;
class DeviceContext;

class PixelShader {
private:
	ID3D11PixelShader* _pixelShader;

	bool Init(const void* shaderByteCode, size_t byteCodeSize);

	friend class GraphicsEngine;
	friend class DeviceContext;
public:
	PixelShader();
	void Release();
	~PixelShader();
};

