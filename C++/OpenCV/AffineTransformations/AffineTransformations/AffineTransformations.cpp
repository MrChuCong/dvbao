#include <cv.h>
#include <cxcore.h>
#include <highgui.h>
#include <stdio.h>
#include <iostream>
#include <cmath>

using namespace std;

#define WINDOW_ID "Affine Transformations"
#define MAXS 1000

bool dragging = false;
CvPoint startPoint;
CvPoint endPoint;
int tmp[MAXS][MAXS][3];

IplImage* originalImage;
IplImage* selectedImage;
IplImage* resultImage;

void TranslateImage ()
{
	cout << "Translating the current region ..." << endl;
	// Read the translation distances
	int tx, ty;
	cout << "tx = ";
	cin >> tx;
	cout << "ty = ";
	cin >> ty;
	cvReleaseImage(&resultImage);
	resultImage = cvCloneImage(originalImage);
	// Fill the region before processing
	cvRectangle(resultImage, startPoint, endPoint, cvScalar(255, 255, 255), CV_FILLED);
	for (int y=startPoint.y; y<=endPoint.y; y++)
	{
		for (int x=startPoint.x; x<=endPoint.x; x++)
		{
			// Calculate the new point
			CvPoint point = cvPoint(x + tx, y + ty);
			if (0 <= point.x && point.x < resultImage->width &&
				0 <= point.y && point.y < resultImage->height)
			{
				unsigned char* p1 = (unsigned char*)originalImage->imageData +
					y * originalImage->widthStep +
					x * originalImage->nChannels;
				unsigned char* p2 = (unsigned char*)resultImage->imageData +
					point.y * resultImage->widthStep +
					point.x * resultImage->nChannels;
				// Set pixel for the new point
				p2[0] = p1[0];
				p2[1] = p1[1];
				p2[2] = p1[2];
			}
		}
	}
	cvShowImage(WINDOW_ID, resultImage);
}

void ScaleImage ()
{
	cout << "Scaling the current region ..." << endl;
	// Read the scaling ratios
	double sx, sy;
	cout << "sx = ";
	cin >> sx;
	cout << "sy = ";
	cin >> sy;
	// Reset the temporary array
	for (int i=0; i<MAXS; i++)
		for (int j=0; j<MAXS; j++) tmp[i][j][0] = -1;
	cvReleaseImage(&resultImage);
	resultImage = cvCloneImage(originalImage);
	// Fill the region before processing
	cvRectangle(resultImage, startPoint, endPoint, cvScalar(255, 255, 255), CV_FILLED);
	for (int y=startPoint.y; y<=endPoint.y; y++)
	{
		for (int x=startPoint.x; x<=endPoint.x; x++)
		{
			// Calculate the new point
			CvPoint point = cvPoint(
				x * sx + startPoint.x * (1 - sx),
				y * sy + startPoint.y * (1 - sy));
			if (0 <= point.x && point.x < resultImage->width &&
				0 <= point.y && point.y < resultImage->height)
			{
				unsigned char* p = (unsigned char*)originalImage->imageData +
					y * originalImage->widthStep +
					x * originalImage->nChannels;
				// Set pixel to the temporary array
				tmp[point.y][point.x][0] = p[0];
				tmp[point.y][point.x][1] = p[1];
				tmp[point.y][point.x][2] = p[2];
			}
		}
	}
	// Interpolation
	int maxx = startPoint.x + (endPoint.x - startPoint.x) * sx + 1;
	if (maxx > resultImage->width) maxx = resultImage->width;
	int maxy = startPoint.y + (endPoint.y - startPoint.y) * sy + 1;
	if (maxy > resultImage->height) maxy = resultImage->height;
	for (int y=startPoint.y; y<maxy; y++)
	{
		for (int x=startPoint.x; x<maxx; x++)
		{
			if (tmp[y][x][0] < 0)
			{
				tmp[y][x][0] = tmp[y-1][x-1][0];
				tmp[y][x][1] = tmp[y-1][x-1][1];
				tmp[y][x][2] = tmp[y-1][x-1][2];
				if (sx > 1 && sy < 1)
				{
					tmp[y][x][0] = tmp[y][x-1][0];
					tmp[y][x][1] = tmp[y][x-1][1];
					tmp[y][x][2] = tmp[y][x-1][2];
				}
				if (sx < 1 && sy > 1)
				{
					tmp[y][x][0] = tmp[y-1][x][0];
					tmp[y][x][1] = tmp[y-1][x][1];
					tmp[y][x][2] = tmp[y-1][x][2];
				}
			}
			if (tmp[y][x][0] < 0)
			{
				if (tmp[y][x-1][0] >= 0)
				{
					tmp[y][x][0] = tmp[y][x-1][0];
					tmp[y][x][1] = tmp[y][x-1][1];
					tmp[y][x][2] = tmp[y][x-1][2];
				}
				else
				{
					tmp[y][x][0] = tmp[y-1][x][0];
					tmp[y][x][1] = tmp[y-1][x][1];
					tmp[y][x][2] = tmp[y-1][x][2];
				}
			}
			// After interpolation (if any), set pixel to the result image
			unsigned char* p = (unsigned char*)resultImage->imageData +
				y * resultImage->widthStep +
				x * resultImage->nChannels;
			p[0] = tmp[y][x][0];
			p[1] = tmp[y][x][1];
			p[2] = tmp[y][x][2];
		}
	}
	cvShowImage(WINDOW_ID, resultImage);
}

// Get the rotated point from the orininal point with specified arguments
CvPoint GetRotatedPoint (CvPoint point, double sina, double cosa, double dx, double dy)
{
	return cvPoint(
		point.x * cosa - point.y * sina + dx,
		point.x * sina + point.y * cosa + dy);
}

// Get the intersect point (if any), between a vertical line acrossing a specified point
// and a specified line
CvPoint GetIntersectPoint (CvPoint p1, CvPoint p2, CvPoint point)
{
	if (p1.x == p2.x) return cvPoint(-1, -1);
	int x = point.x;
	int y = (p2.y - p1.y) * (x - p1.x) / (p2.x - p1.x) + p1.y;
	if (y < min(p1.y, p2.y) || y > max(p1.y, p2.y)) x = -1;
	return cvPoint(x, y);
}

// Check whether a point inside a polygon with 4 specified vertices
bool CheckPointInside (CvPoint p1, CvPoint p2, CvPoint p3, CvPoint p4, CvPoint point)
{
	int miny = resultImage->height;
	int maxy = 0;
	CvPoint p = GetIntersectPoint(p1, p2, point);
	if (p.x >= 0)
	{
		if (miny > p.y) miny = p.y;
		if (maxy < p.y) maxy = p.y;
	}
	p = GetIntersectPoint(p2, p3, point);
	if (p.x >= 0)
	{
		if (miny > p.y) miny = p.y;
		if (maxy < p.y) maxy = p.y;
	}
	p = GetIntersectPoint(p3, p4, point);
	if (p.x >= 0)
	{
		if (miny > p.y) miny = p.y;
		if (maxy < p.y) maxy = p.y;
	}
	p = GetIntersectPoint(p4, p1, point);
	if (p.x >= 0)
	{
		if (miny > p.y) miny = p.y;
		if (maxy < p.y) maxy = p.y;
	}
	return (miny <= point.y) && (point.y <= maxy);
}

void RotateImage ()
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
	// Reset the temporary array
	for (int i=0; i<MAXS; i++)
		for (int j=0; j<MAXS; j++) tmp[i][j][0] = -1;
	cvReleaseImage(&resultImage);
	resultImage = cvCloneImage(originalImage);
	cvRectangle(resultImage, startPoint, endPoint, cvScalar(255, 255, 255), CV_FILLED);
	int minx = resultImage->width;
	int maxx = 0;
	int miny = resultImage->height;
	int maxy = 0;
	for (int y=startPoint.y; y<=endPoint.y; y++)
	{
		for (int x=startPoint.x; x<=endPoint.x; x++)
		{
			// Calculate the new point
			CvPoint point = GetRotatedPoint(cvPoint(x, y), sina, cosa, dx, dy);
			if (0 <= point.x && point.x < resultImage->width &&
				0 <= point.y && point.y < resultImage->height)
			{
				if (minx > point.x) minx = point.x;
				if (maxx < point.x) maxx = point.x;
				if (miny > point.y) miny = point.y;
				if (maxy < point.y) maxy = point.y;
				// Set pixel to the temporary array
				unsigned char* p = (unsigned char*)originalImage->imageData +
					y * originalImage->widthStep +
					x * originalImage->nChannels;
				tmp[point.y][point.x][0] = p[0];
				tmp[point.y][point.x][1] = p[1];
				tmp[point.y][point.x][2] = p[2];
			}
		}
	}
	// Get 4 vertices of the rotated region
	CvPoint p1 = GetRotatedPoint(startPoint, sina, cosa, dx, dy);
	CvPoint p2 = GetRotatedPoint(cvPoint(endPoint.x, startPoint.y), sina, cosa, dx, dy);
	CvPoint p3 = GetRotatedPoint(endPoint, sina, cosa, dx, dy);
	CvPoint p4 = GetRotatedPoint(cvPoint(startPoint.x, endPoint.y), sina, cosa, dx, dy);
	// Interpolation
	for (int y=miny; y<=maxy; y++)
	{
		for (int x=minx; x<=maxx; x++)
		{
			if (CheckPointInside(p1, p2, p3, p4, cvPoint(x, y)))
			{
				if (tmp[y][x][0] < 0)
				{
					if (tmp[y][x-1][0] >= 0)
					{
						tmp[y][x][0] = tmp[y][x-1][0];
						tmp[y][x][1] = tmp[y][x-1][1];
						tmp[y][x][2] = tmp[y][x-1][2];
					}
				}
				if (tmp[y][x][0] >= 0)
				{
					// After interpolation (if any), set pixel to the result image
					unsigned char* p = (unsigned char*)resultImage->imageData +
						y * resultImage->widthStep +
						x * resultImage->nChannels;
					p[0] = tmp[y][x][0];
					p[1] = tmp[y][x][1];
					p[2] = tmp[y][x][2];
				}
			}
		}
	}
	cvShowImage(WINDOW_ID, resultImage);
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
			system("cls");
			cout << "Selected Region: ";
			cout << "(" << startPoint.x << ", " << startPoint.y << ") -> ";
			cout << "(" << endPoint.x << ", " << endPoint.y << ")" << endl;
			cout << "Press ESC or Q to exit the program." << endl;
			cout << "Press T to translate the current region." << endl;
			cout << "Press S to scale the current region." << endl;
			cout << "Press R to rotate the current region." << endl;
			cout << "Press L to reload the original image." << endl;
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
	// Release all images
	cvReleaseImage(&resultImage);
	cvReleaseImage(&originalImage);
	cvReleaseImage(&selectedImage);
	return 0;
}