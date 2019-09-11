#pragma once
#include "InputListener.h"
#include <map>

class InputSystem {
public:
	InputSystem();
	~InputSystem();

	void Update();

	void AddListener(InputListener* listener);
	void RemoveListener(InputListener* listener);

	static InputSystem* Get();

private:
	std::map<InputListener*, InputListener*> mapListeners;
	unsigned char keysState[256] = {};
	unsigned char oldKeysState[256] = {};
};

