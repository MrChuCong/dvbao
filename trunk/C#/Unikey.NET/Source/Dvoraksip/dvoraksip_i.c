/* this file contains the actual definitions of */
/* the IIDs and CLSIDs */

/* link this file in with the server and any clients */


/* File created by MIDL compiler version 5.01.0164 */
/* at Thu Jan 10 11:59:12 2008
 */
/* Compiler settings for .\dvoraksip.idl:
    Oicf (OptLev=i2), W1, Zp8, env=Win32, ms_ext, c_ext
    error checks: allocation ref bounds_check enum stub_data 
*/
//@@MIDL_FILE_HEADING(  )
#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IID_DEFINED__
#define __IID_DEFINED__

typedef struct _IID
{
    unsigned long x;
    unsigned short s1;
    unsigned short s2;
    unsigned char  c[8];
} IID;

#endif // __IID_DEFINED__

#ifndef CLSID_DEFINED
#define CLSID_DEFINED
typedef IID CLSID;
#endif // CLSID_DEFINED

const IID LIBID_DVORAKSIPLib = {0x5863CFFB,0xC83A,0x45A8,{0xA1,0xF6,0x6A,0x87,0xC0,0x5C,0x12,0x75}};


const IID IID_IIMCallback = {0x42429669,0xae04,0x11d0,{0xa4,0xf8,0x00,0xaa,0x00,0xa7,0x49,0xb9}};


const IID IID_IInputMethod = {0x42429666,0xae04,0x11d0,{0xa4,0xf8,0x00,0xaa,0x00,0xa7,0x49,0xb9}};


const CLSID CLSID_CMSDvorakIm = {0x42429695,0xae04,0x11d0,{0xa4,0xf8,0x00,0xaa,0x00,0xa7,0x49,0xb9}};


#ifdef __cplusplus
}
#endif

