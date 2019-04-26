#include "ConstantBuffer.h"
#include "GraphicsEngine.h"
#include "DeviceContext.h"


ConstantBuffer::ConstantBuffer() {}


ConstantBuffer::~ConstantBuffer() {}

bool ConstantBuffer::Load(void* buffer, UINT bufferSize) {
	if (_buffer) _buffer->Release();
	
	D3D11_BUFFER_DESC bufferDesc = {};
	bufferDesc.Usage = D3D11_USAGE_DEFAULT;
	bufferDesc.ByteWidth = bufferSize;
	bufferDesc.BindFlags = D3D11_BIND_CONSTANT_BUFFER;
	bufferDesc.CPUAccessFlags = 0;
	bufferDesc.MiscFlags = 0;

	D3D11_SUBRESOURCE_DATA initData = {};
	initData.pSysMem = buffer;

	HRESULT res = GraphicsEngine::Get()->_d3dDevice->CreateBuffer(&bufferDesc, &initData, &_buffer);

	if (FAILED(res))
		return false;

	return true;
}

void ConstantBuffer::Update(DeviceContext* context, void* buffer) {
	context->_deviceContext->UpdateSubresource(this->_buffer, NULL, NULL, buffer, NULL, NULL);
}

bool ConstantBuffer::Release() {
	if (_buffer) _buffer->Release();
	delete this;
	return true;
}
