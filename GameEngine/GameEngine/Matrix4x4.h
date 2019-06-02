#pragma once
#include <memory>
#include "Vector3D.h"


class Matrix4x4 {
public:
	Matrix4x4() {

	}

	void SetIdentity() {
		::memset(mat, 0, sizeof(float) * 16);
		
		mat[0][0] = 1;
		mat[1][1] = 1;
		mat[2][2] = 1;
		mat[3][3] = 1;
	}

	void SetTranslation(const Vector3D& translation) {
		SetIdentity();

		mat[3][0] = translation.x;
		mat[3][1] = translation.y;
		mat[3][2] = translation.z;
	}

	void SetScale(const Vector3D& scale) {
		SetIdentity();

		mat[0][0] = scale.x;
		mat[1][1] = scale.y;
		mat[2][2] = scale.z;
	}

	void operator *=(const Matrix4x4& matrix) {
		Matrix4x4 out;

		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				out.mat[i][j] =
					mat[i][0] * matrix.mat[0][j] +
					mat[i][1] * matrix.mat[1][j] + 
					mat[i][2] * matrix.mat[2][j] + 
					mat[i][3] * matrix.mat[3][j];
			}
		}

		::memcpy(mat, out.mat, sizeof(float) * 16);
	}

	void SetOrtholH(float width, float height, float nearPlane, float farPlane) {
		SetIdentity();

		mat[0][0] = 2.0f / width;
		mat[1][1] = 2.0f / height;
		mat[2][2] = 1.0f / (farPlane - nearPlane);
		mat[3][2] = -(nearPlane / (farPlane - nearPlane));
	}

	~Matrix4x4() {

	}



private:
	float mat[4][4] = {};
};