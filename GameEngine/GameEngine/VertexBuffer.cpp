#include "VertexBuffer.h"
#include "GraphicsEngine.h"


VertexBuffer::VertexBuffer() : _layout(0), _buffer(0) {}


VertexBuffer::~VertexBuffer() {}

bool VertexBuffer::Load(void* verticesList, UINT sizeVertexType, UINT sizeList, void* shaderByteCode, UINT sizeByteShader) {
	if (_buffer) _buffer->Release();
	if (_layout) _layout->Release();

	D3D11_BUFFER_DESC bufferDesc = {};
	bufferDesc.Usage = D3D11_USAGE_DEFAULT;
	bufferDesc.ByteWidth = sizeVertexType * sizeList;
	bufferDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
	bufferDesc.CPUAccessFlags = 0;
	bufferDesc.MiscFlags = 0;

	D3D11_SUBRESOURCE_DATA initData = {};
	initData.pSysMem = verticesList;

	vertexSize = sizeVertexType;
	vertexListSize = sizeList;

	HRESULT res = GraphicsEngine::Get()->_d3dDevice->CreateBuffer(&bufferDesc, &initData, &_buffer);

	if (FAILED(res))
		return false;

	D3D11_INPUT_ELEMENT_DESC layout[] = {
		// Semantic Name - Semantic Index - Format - Input Slot - Aligned Byte Offset - Input Slot Class - Instance Data Step Rate
		{"POSITION", 0,  DXGI_FORMAT_R32G32B32_FLOAT, 0, 0,D3D11_INPUT_PER_VERTEX_DATA ,0},
		{ "COLOR", 0,  DXGI_FORMAT_R32G32B32_FLOAT, 0, 12,D3D11_INPUT_PER_VERTEX_DATA ,0 },
		{ "COLOR", 1,  DXGI_FORMAT_R32G32B32_FLOAT, 0, 24,D3D11_INPUT_PER_VERTEX_DATA ,0 }
	};



	UINT layoutSize = ARRAYSIZE(layout);

	res = GraphicsEngine::Get()->_d3dDevice->CreateInputLayout(layout, layoutSize, shaderByteCode, sizeByteShader, &_layout);

	if (FAILED(res))
		return false;

	return true;
}

UINT VertexBuffer::GetSizeVertexList() {
	return this->vertexListSize;
}

bool VertexBuffer::Release() {
	_layout->Release();
	_buffer->Release();
	delete this;

	return true;
}
