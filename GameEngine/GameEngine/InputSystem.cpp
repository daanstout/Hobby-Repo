#include "InputSystem.h"
#include <Windows.h>

InputSystem::InputSystem() {}

InputSystem::~InputSystem() {}

void InputSystem::Update() {
	if (::GetKeyboardState(keysState)) {
		for (unsigned int i = 0; i < 256; i++) {
			// Key is down
			if (keysState[i] & 0x80) {
				std::map<InputListener*, InputListener*>::iterator it = mapListeners.begin();

				while (it != mapListeners.end()) {
					it->second->onKeyDown(i);
					++it;
				}
			} else { // Key is up
				if (keysState[i] != oldKeysState[i]) {
					std::map<InputListener*, InputListener*>::iterator it = mapListeners.begin();

					while (it != mapListeners.end()) {
						it->second->onKeyUp(i);
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
