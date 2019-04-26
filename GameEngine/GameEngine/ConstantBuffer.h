#pragma once
#include <d3d11.h>

class DeviceContext;

class ConstantBuffer {
private:
	ID3D11Buffer* _buffer;

	friend class DeviceContext;
public:
	ConstantBuffer();
	~ConstantBuffer();

	bool Load(void* buffer, UINT bufferSize);
	void Update(DeviceContext* context, void* buffer);
	bool Release();
};

