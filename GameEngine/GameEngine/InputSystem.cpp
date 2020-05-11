#include "InputSystem.h"
#include <Windows.h>

InputSystem::InputSystem() {}

InputSystem::~InputSystem() {}

void InputSystem::Update() {
	POINT currentMousePosition = {};
	::GetCursorPos(&currentMousePosition);

	if (firstTime) {
		oldMousePosition = Point(currentMousePosition.x, currentMousePosition.y);
		firstTime = false;
	}

	if (currentMousePosition.x != oldMousePosition.x || currentMousePosition.y != oldMousePosition.y) {
		// There is a mouse move event

		std::map<InputListener*, InputListener*>::iterator it = mapListeners.begin();

		while (it != mapListeners.end()) {
			it->second->OnMouseMove(Point(currentMousePosition.x - oldMousePosition.x, currentMousePosition.y - oldMousePosition.y));
			++it;
		}
	}

	oldMousePosition = Point(currentMousePosition.x, currentMousePosition.y);

	if (::GetKeyboardState(keysState)) {
		for (unsigned int i = 0; i < 256; i++) {
			// Key is down
			if (keysState[i] & 0x80) {
				std::map<InputListener*, InputListener*>::iterator it = mapListeners.begin();

				while (it != mapListeners.end()) {
					if (i == VK_LBUTTON) {
						if (keysState[i] != oldKeysState[i])
							it->second->OnLeftMouseDown(Point(currentMousePosition.x, currentMousePosition.y));
					} else if (i == VK_RBUTTON) {
						if (keysState[i] != oldKeysState[i])
							it->second->OnRightMouseDown(Point(currentMousePosition.x, currentMousePosition.y));
					} else {
						it->second->OnKeyDown(i);
					}
					++it;
				}
			} else { // Key is up
				if (keysState[i] != oldKeysState[i]) {
					std::map<InputListener*, InputListener*>::iterator it = mapListeners.begin();

					while (it != mapListeners.end()) {
						if (i == VK_LBUTTON) {
							it->second->OnLeftMouseUp(Point(currentMousePosition.x, currentMousePosition.y));
						} else if (i == VK_RBUTTON) {
							it->second->OnRightMouseUp(Point(currentMousePosition.x, currentMousePosition.y));
						} else {
							it->second->OnKeyUp(i);
						}
						++it;
					}
				}
			}
		}
		// Store the current key state
		::memcpy(oldKeysState, keysState, sizeof(unsigned char) * 256);
	}
}

void InputSystem::AddListener(InputListener* listener) {
	mapListeners.insert(std::make_pair<InputListener*, InputListener*>(std::forward<InputListener*>(listener), std::forward<InputListener*>(listener)));
}

void InputSystem::RemoveListener(InputListener* listener) {
	std::map<InputListener*, InputListener*>::iterator it = mapListeners.find(listener);

	if (it != mapListeners.end()) {
		mapListeners.erase(it);
	}
}

InputSystem* InputSystem::Get() {
	static InputSystem system;
	return &system;
}
