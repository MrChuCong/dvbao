#include <cv.h>
#include <cxcore.h>
#include <highgui.h>
#include <iostream>
#include <cmath>

using namespace std;

#define WINDOW_ID "Histogram"

bool dragging = false;
bool isRotated = false;
CvPoint startPoint;
CvPoint endPoint;
CvPoint v[5];
int red[256];
int green[256];
int blue[256];

IplImage* selectedImage;
IplImage* originalImage;

// Get the rotated point from the orininal point with specified arguments
CvPoint GetRotatedPoint (CvPoint point, double sina, double cosa, double dx, double dy)
{
	return cvPoint(
		point.x * cosa - point.y * sina + dx,
		point.x * sina + point.y * cosa + dy);
}

// Rotate the current region with a specified angle
void RotateRegion ()
{
	cout << "Rotating the current region ..." << endl;
	// Read the angle to rotate
	double angle;
	cout << "angle = ";
	cin >> angle;
	angle = angle * CV_PI / 180;
	double sina = sin(angle);
	double cosa = cos(angle);
	double dx = startPoint.x - startPoint.x * cosa + startPoint.y * sina;
	double dy = startPoint.y - startPoint.x * sina - startPoint.y * cosa;
	// Get 4 vertices of the rotated region and an extra vertice
	v[0] = GetRotatedPoint(startPoint, sina, cosa, dx, dy);
	v[1] = GetRotatedPoint(cvPoint(endPoint.x, startPoint.y), sina, cosa, dx, dy);
	v[2] = GetRotatedPoint(endPoint, sina, cosa, dx, dy);
	v[3] = GetRotatedPoint(cvPoint(startPoint.x, endPoint.y), sina, cosa, dx, dy);
	v[4] = v[0];
	// Draw the rotated region
	cvReleaseImage(&selectedImage);
	selectedImage = cvCloneImage(originalImage);
	for (int i=0; i<4; i++)
	{
		cvLine(selectedImage, v[i], v[i+1], cvScalar(0, 0, 255), 2);
	}
	cvShowImage(WINDOW_ID, selectedImage);
	isRotated = true;
}

void ResetHistogram ()
{
	memset(red, 0, sizeof(red));
	memset(green, 0, sizeof(green));
	memset(blue, 0, sizeof(blue));
}

void PrintChannelHistogram(IplImage* image, int hist[], CvScalar color, int dx, int dy)
{
	double max = -1;
	for (int i=0; i<256; i++)
		if (hist[i] > max) max = hist[i];
	for (int i=0; i<256; i++)
	{
		cvLine(image, cvPoint(i + dx, dy),
			cvPoint(i + dx, dy - hist[i] * 100 / max), color, 1);
	}
}

void PrintHistogram (int id)
{
	char windowName[100];
	sprintf(windowName, "Method %d", id);
	cvNamedWindow(windowName);
	cvMoveWindow(windowName, id * 310 - 200, 300);
	IplImage* image = cvCreateImage(cvSize(256, 308), 8, 3);
	cvRectangle(image, cvPoint(0, 0), cvPoint(256, 308),
		cvScalar(255, 255, 255), CV_FILLED);
	PrintChannelHistogram(image, red, cvScalar(0, 0, 255), 0, 102);
	PrintChannelHistogram(image, green, cvScalar(0, 255, 0), 0, 204);
	PrintChannelHistogram(image, blue, cvScalar(255, 0, 0), 0, 306);
	cvShowImage(windowName, image);
	cvReleaseImage(&image);
}

bool InsideRegion (CvPoint point)
{
	int miny = originalImage->height;
	int maxy = 0;
	for (int i=0; i<4; i++)
	{
		int x = point.x;
		if (v[i+1].x != v[i].x)
		{
			int y = (v[i+1].y - v[i].y) * (x - v[i].x) / (v[i+1].x - v[i].x) + v[i].y;
			if (min(v[i].y, v[i+1].y) <= y && y <= max(v[i].y, v[i+1].y))
			{
				if (miny > y) miny = y;
				if (maxy < y) maxy = y;
			}
		}
	}
	return (miny <= point.y) && (point.y <= maxy);
}

// The first method to calculate the histogram, counting every pixel inside the region
void FirstMethod ()
{
	ResetHistogram();
	int minx = originalImage->width;
	int maxx = 0;
	int miny = originalImage->height;
	int maxy = 0;
	for (int i=0; i<4; i++)
	{
		if (minx > v[i].x) minx = v[i].x;
		if (maxx < v[i].x) maxx = v[i].x;
		if (miny > v[i].y) miny = v[i].y;
		if (maxy < v[i].y) maxy = v[i].y;
	}
	for (int y=miny; y<=maxy; y++)
	{
		for (int x=minx; x<=maxx; x++)
		{
			if (InsideRegion(cvPoint(x, y)))
			{
				unsigned char* p = (unsigned char*)originalImage->imageData +
					y * originalImage->widthStep +
					x * originalImage->nChannels;
				blue[p[0]]++;
				green[p[1]]++;
				red[p[2]]++;
			}
		}
	}
	PrintHistogram(1);
}

// Calculate the histogram of the current region
void CalculateHistogram ()
{
	FirstMethod();
}

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
			isRotated = false;
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
		case 'r':	// R	:	Rotate the current region
			if (!dragging)
			{
				RotateRegion();
			}
			break;
		case 'h':	// H	:	Calculate the histogram of the current region
			if (!dragging && isRotated)
			{
				CalculateHistogram();
			}
			break;
		}
	}
	// Release all images
	cvReleaseImage(&selectedImage);
	cvReleaseImage(&originalImage);
	return 0;
}