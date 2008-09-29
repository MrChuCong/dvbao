#include <cv.h>
#include <cxcore.h>
#include <highgui.h>
#include <iostream>
#include <cmath>

using namespace std;

#define WINDOW_ID "Histogram"

bool dragging = false;
CvPoint startPoint;
CvPoint endPoint;

IplImage* selectedImage;
IplImage* originalImage;

// Process a mouse event
void mouseHandler (int mouseEvent, int x, int y, int flags, void* param)
{
	switch (mouseEvent)
	{
	case CV_EVENT_LBUTTONDOWN:
		if (!dragging)
		{
			// If left mouse button down, and not dragging, start to drag
			dragging = true;
			startPoint = cvPoint(x, y);
		}
		break;
	case CV_EVENT_LBUTTONUP:
		if (dragging)
		{
			int x1 = min(startPoint.x, endPoint.x);
			int x2 = max(startPoint.x, endPoint.x);
			int y1 = min(startPoint.y, endPoint.y);
			int y2 = max(startPoint.y, endPoint.y);
			// Reset the start point to the left-top point
			startPoint.x = x1;
			startPoint.y = y1;
			// Reset the end point to the right-bottom point
			endPoint.x = x2;
			endPoint.y = y2;
			// End dragging
			dragging = false;
		}
		break;
	case CV_EVENT_MOUSEMOVE:
		if (dragging)
		{
			// If dragging, draw a red rectangle on the selected region
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
	// Create a window to show image
	cvNamedWindow(WINDOW_ID);
	cvMoveWindow(WINDOW_ID, 100, 100);
	cvShowImage(WINDOW_ID, originalImage);
	// Set mouse callback
	cvSetMouseCallback(WINDOW_ID, mouseHandler, 0);	
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
		}
	}
	// Release all images
	cvReleaseImage(&selectedImage);
	cvReleaseImage(&originalImage);
	return 0;
}