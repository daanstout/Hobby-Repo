#include "IndexBuffer.h"
#include "GraphicsEngine.h"


IndexBuffer::IndexBuffer() :  _buffer(0) {}


IndexBuffer::~IndexBuffer() {}

bool IndexBuffer::Load(void* indecesList, UINT listSize) {
	if (_buffer) _buffer->Release();

	D3D11_BUFFER_DESC bufferDesc = {};
	bufferDesc.Usage = D3D11_USAGE_DEFAULT;
	bufferDesc.ByteWidth = 4 * listSize;
	bufferDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
	bufferDesc.CPUAccessFlags = 0;
	bufferDesc.MiscFlags = 0;

	D3D11_SUBRESOURCE_DATA initData = {};
	initData.pSysMem = indecesList;

	this->listSize = listSize;

	HRESULT res = GraphicsEngine::Get()->_d3dDevice->CreateBuffer(&bufferDesc, &initData, &_buffer);

	if (FAILED(res))
		return false;

	return true;
}

UINT IndexBuffer::GetSizeIndexList() {
	return this->listSize;
}

bool IndexBuffer::Release() {
	_buffer->Release();
	delete this;

	return true;
}
