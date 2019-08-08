#pragma once
#include <d3d11.h>

class DeviceContext;

class IndexBuffer {
private:
	UINT listSize;

	ID3D11Buffer* _buffer;

	friend class DeviceContext;
public:
	IndexBuffer();
	~IndexBuffer();

	bool Load(void* indicesList, UINT listSize);
	UINT GetSizeIndexList();
	bool Release();
};

