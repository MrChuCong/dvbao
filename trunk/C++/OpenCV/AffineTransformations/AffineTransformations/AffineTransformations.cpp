#include <cv.h>
#include <cxcore.h>
#include <highgui.h>
#include <stdio.h>
#include <iostream>
#include <cmath>

using namespace std;

#define WINDOW_ID "Affine Transformations"
#define PI 3.1415926

bool dragging = false;
CvPoint startPoint;
CvPoint endPoint;

IplImage* originalImage;
IplImage* selectedImage;
IplImage* resultImage;

void Transform (CvMat matrix)
{
	cvReleaseImage(&resultImage);
	resultImage = cvCloneImage(originalImage);
	cvRectangle(resultImage, startPoint, endPoint, cvScalar(255, 255, 255), CV_FILLED);
	int x1 = min(startPoint.x, endPoint.x);
	int x2 = max(startPoint.x, endPoint.x);
	int y1 = min(startPoint.y, endPoint.y);
	int y2 = max(startPoint.y, endPoint.y);
	for (int y=y1; y<=y2; y++)
	{
		for (int x=x1; x<=x2; x++)
		{
			double oldPos[] = { x, y, 1 };
			double newPos[3];
			CvMat oldPosMatrix = cvMat(3, 1, CV_64FC1, oldPos);
			CvMat newPosMatrix = cvMat(3, 1, CV_64FC1, newPos);
			cvMatMul(&matrix, &oldPosMatrix, &newPosMatrix);
			int xx = newPos[0];
			int yy = newPos[1];
			if (0 <= xx && xx < resultImage->width &&
				0 <= yy && yy < resultImage->height)
			{
				unsigned char* p1 = (unsigned char*)originalImage->imageData +
					y * originalImage->widthStep +
					x * originalImage->nChannels;
				unsigned char* p2 = (unsigned char*)resultImage->imageData +
					yy * resultImage->widthStep +
					xx * resultImage->nChannels;
				p2[0] = p1[0];
				p2[1] = p1[1];
				p2[2] = p1[2];
			}
		}
	}
	cvShowImage(WINDOW_ID, resultImage);
}

void TranslateImage ()
{
	int tx, ty;
	cout << "tx = ";
	cin >> tx;
	cout << "ty = ";
	cin >> ty;
	double m[] = {
		1, 0, tx,
		0, 1, ty,
		0, 0, 1,
	};
	CvMat matrix = cvMat(3, 3, CV_64FC1, m);
	Transform(matrix);
}

void ScaleImage ()
{
	int x0 = min(startPoint.x, endPoint.x);
	int y0 = min(startPoint.y, endPoint.y);
	double sx, sy;
	cout << "sx = ";
	cin >> sx;
	cout << "sy = ";
	cin >> sy;
	double m[] = {
		sx, 0, x0 * (1 - sx),
		0, sy, y0 * (1 - sy),
		0, 0, 1,
	};
	CvMat matrix = cvMat(3, 3, CV_64FC1, m);
	Transform(matrix);
}

void RotateImage ()
{
	int x0 = min(startPoint.x, endPoint.x);
	int y0 = min(startPoint.y, endPoint.y);
	double angle;
	cout << "angle = ";
	cin >> angle;
	angle = angle * PI / 180;
	int dx = x0 * cos(angle) - y0 * sin(angle);
	int dy= x0 * sin(angle) + y0 * cos(angle);
	double m[] = {
		cos(angle), -sin(angle), x0 - dx,
		sin(angle), cos(angle), y0 - dy,
		0, 0, 1,
	};
	CvMat matrix = cvMat(3, 3, CV_64FC1, m);
	Transform(matrix);
}

void mouseHandler (int mouseEvent, int x, int y, int flags, void* param)
{
	switch (mouseEvent)
	{
	case CV_EVENT_LBUTTONDOWN:
		if (!dragging)
		{
			dragging = true;
			startPoint = cvPoint(x, y);
		}
		break;
	case CV_EVENT_LBUTTONUP:
		if (dragging)
		{
			dragging = false;
		}
		break;
	case CV_EVENT_MOUSEMOVE:
		if (dragging)
		{
			endPoint = cvPoint(x, y);
			cvReleaseImage(&selectedImage);
			selectedImage = cvCloneImage(originalImage);
			cvRectangle(selectedImage, startPoint, endPoint, cvScalar(0, 0, 255), 2);
			cvShowImage(WINDOW_ID, selectedImage);
		}
		break;
	}
}

int main (int argc, char* argv[])
{
	originalImage = cvLoadImage("input.jpg");
	if (!originalImage)
	{
		cout << "Input image not found!" << endl;
		return 0;
	}
	cvNamedWindow(WINDOW_ID);
	cvMoveWindow(WINDOW_ID, 100, 100);
	cvSetMouseCallback(WINDOW_ID, mouseHandler, 0);
	cvShowImage(WINDOW_ID, originalImage);
	bool stop = false;
	while (!stop)
	{
		int key = cvWaitKey(0);
		switch (key)
		{
		case 27:	// ESC	:	Exit
		case 'q':	// Q	:	Exit
			stop = true;
			break;
		case 't':	// T	:	Translate
			if (!dragging)
			{
				TranslateImage();
			}
			break;
		case 's':	// S	:	Scale
			if (!dragging)
			{
				ScaleImage();
			}
			break;
		case 'r':	// R	:	Rotate
			if (!dragging)
			{
				RotateImage();
			}
			break;
		case 'l':	// L	:	Load the original image
			cvShowImage(WINDOW_ID, originalImage);
			break;
		}
	}
	cvReleaseImage(&originalImage);
	cvReleaseImage(&selectedImage);
	return 0;
}