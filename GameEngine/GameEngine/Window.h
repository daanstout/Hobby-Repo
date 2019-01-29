#pragma once

#include <Windows.h>

class Window {
protected:
	// Variables
	char className[80] = "MyWindowClass\0";
	char titleName[80] = "DirectX Application\0";

	HWND _hwnd;

	bool _isRunning;
public:
	// Constructors
	Window();
	~Window();
	

	// Functions
	// Initialize the Window
	bool Init();
	// Broadcast the messages?
	bool Broadcast();
	// Release the Window
	bool Release();
	// Indicates whether the window is running
	bool IsRunning();

	RECT GetClientWindowRect();
	void SetHWND(HWND hwnd);

	// EVENTS
	virtual void OnCreate();
	virtual void OnUpdate();
	virtual void OnDestroy();
};

