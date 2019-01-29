#include "window.h"

Window* window = nullptr;


Window::Window() {}


Window::~Window() {}


LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wparam, LPARAM lparam) {
	switch (msg) {
		case WM_CREATE:
			// Fired when the Window is created
			window->OnCreate();
			break;
		case WM_DESTROY:
			// Fired when the Window is destroyed
			window->OnDestroy();
			::PostQuitMessage(0);
			break;
		default:
			return ::DefWindowProc(hwnd, msg, wparam, lparam);
	}

	return NULL;
}


bool Window::Init() {
	// Setting up the WNDCLASSEX object
	WNDCLASSEX wc;

	wc.cbClsExtra = NULL;
	wc.cbSize = sizeof(wc);
	wc.cbWndExtra = NULL;
	wc.hbrBackground = (HBRUSH)COLOR_WINDOW;
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wc.hIconSm = LoadIcon(NULL, IDI_APPLICATION);
	wc.hInstance = NULL;
	wc.lpszClassName = className;
	wc.lpszMenuName = "";
	wc.style = NULL;
	wc.lpfnWndProc = WndProc;

	// If registering the class fails, return false
	if (!::RegisterClassEx(&wc))
		return false;

	if (!window)
		window = this;

	// Create the Window
	_hwnd = ::CreateWindowEx(WS_EX_OVERLAPPEDWINDOW, className, titleName, WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, 1024, 768, NULL, NULL, NULL, NULL);

	// If creating the window failed, return false
	if (!_hwnd)
		return false;

	// Show the Window
	::ShowWindow(_hwnd, SW_SHOW);
	::UpdateWindow(_hwnd);

	// Set the flag to true to indicate that the window is running
	_isRunning = true;
	return true;
}

bool Window::Broadcast() {
	MSG msg;

	while (::PeekMessage(&msg, NULL, 0, 0, PM_REMOVE) > 0) {
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	window->OnUpdate();

	Sleep(0);

	return true;
}

bool Window::Release() {
	// Destroy the Window
	if (::DestroyWindow(_hwnd))
		return false;

	return true;
}

bool Window::IsRunning() {
	return _isRunning;
}

void Window::OnCreate() {}

void Window::OnUpdate() {}

void Window::OnDestroy() {
	_isRunning = false;
}
