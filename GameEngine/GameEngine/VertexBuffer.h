#pragma once
#include <d3d11.h>

class DeviceContext;

class VertexBuffer {
private:
	UINT vertexSize;
	UINT vertexListSize;

	ID3D11Buffer* _buffer;
	ID3D11InputLayout* _layout;

	friend class DeviceContext;
public:
	VertexBuffer();
	~VertexBuffer();

	bool Load(void* verticesList, UINT sizeVertexType, UINT sizeList, void* shaderByteCode, UINT sizeByteShader);
	UINT GetSizeVertexList();
	bool Release();
};

