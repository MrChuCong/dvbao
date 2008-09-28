#include <cv.h>
#include <cxcore.h>
#include <highgui.h>
#include <stdio.h>
#include <algorithm>

using namespace std;

#define WINDOW_ID "Region Processing"

bool dragging = false;
CvPoint startPoint;
CvPoint endPoint;
IplImage* originalImage;
IplImage* currentImage;

void FilteringImage(IplImage* image, CvPoint startPoint, CvPoint endPoint)
{
	int x1 = min(startPoint.x, endPoint.x);
	int x2 = max(startPoint.x, endPoint.x);
	int y1 = min(startPoint.y, endPoint.y);
	int y2 = max(startPoint.y, endPoint.y);
	unsigned char* imageData = (unsigned char*)image->imageData;
	for (int i=y1; i<=y2; i++)
	{
		for (int j=x1; j<=x2; j++)
		{
			unsigned char* pointer = imageData + i * image->widthStep + j * image->nChannels;
			unsigned char intensity = (pointer[0] + pointer[1] + pointer[2]) / 3;
			pointer[0] = pointer[1] = pointer[2] = intensity;
		}
	}
}

void mouseHandler (int mouseEvent, int x, int y, int flags, void* param)
{
	switch (mouseEvent)
	{
	case CV_EVENT_LBUTTONDOWN:
		if (!dragging)
		{
			startPoint = cvPoint(x, y);
			dragging = true;
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
			cvReleaseImage(&currentImage);
			currentImage = cvCloneImage(originalImage);
			FilteringImage(currentImage, startPoint, endPoint);
			cvRectangle(currentImage, startPoint, endPoint, cvScalar(0, 0, 0), 2);
			cvShowImage(WINDOW_ID, currentImage);
		}
		break;
	}
}

int main (int argc, char* argv[])
{
	originalImage = cvLoadImage("input.jpg");
	cvNamedWindow(WINDOW_ID);
	cvMoveWindow(WINDOW_ID, 100, 100);
	cvSetMouseCallback(WINDOW_ID, mouseHandler, 0);
	cvShowImage(WINDOW_ID, originalImage);
	cvWaitKey(0);
	cvReleaseImage(&currentImage);
	cvReleaseImage(&originalImage);
	return 0;
}