#include "DeviceContext.h"
#include "SwapChain.h"
#include "VertexBuffer.h"
#include "VertexShader.h"
#include "PixelShader.h"

DeviceContext::DeviceContext(ID3D11DeviceContext* deviceContext) :_deviceContext(deviceContext) {}


DeviceContext::~DeviceContext() {}

void DeviceContext::ClearRenderTargetColor(SwapChain* swapChain, float r, float g, float b, float a) {
	FLOAT clearColor[] = { r, g, b, a };
	_deviceContext->ClearRenderTargetView(swapChain->_renderTargetView, clearColor);
	_deviceContext->OMSetRenderTargets(1, &swapChain->_renderTargetView, NULL);
}

void DeviceContext::SetVertexBuffer(VertexBuffer * vertexBuffer) {
	UINT stride = vertexBuffer->vertexSize;
	UINT offset = 0;
	_deviceContext->IASetVertexBuffers(0, 1, &vertexBuffer->_buffer, &stride, &offset);
	_deviceContext->IASetInputLayout(vertexBuffer->_layout);
}

void DeviceContext::DrawTriangleList(UINT vertexCount, UINT startVertexIndex) {
	_deviceContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);

	_deviceContext->Draw(vertexCount, startVertexIndex);
}

void DeviceContext::DrawTriangleStrip(UINT vertexCount, UINT startVertexIndex) {
	_deviceContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP);

	_deviceContext->Draw(vertexCount, startVertexIndex);
}

void DeviceContext::SetViewportSize(UINT width, UINT height) {
	D3D11_VIEWPORT vp = {};
	vp.Width = width;
	vp.Height = height;
	vp.MinDepth = 0.0f;
	vp.MaxDepth = 1.0f;
	_deviceContext->RSSetViewports(1, &vp);
}

void DeviceContext::SetVertexShader(VertexShader * vertexShader) {
	_deviceContext->VSSetShader(vertexShader->_vertexShader, nullptr, 0);
}

void DeviceContext::SetPixelShader(PixelShader * pixelShader) {
	_deviceContext->PSSetShader(pixelShader->_pixelShader, nullptr, 0);
}

bool DeviceContext::Release() {
	_deviceContext->Release();
	delete this;
	return true;
}
