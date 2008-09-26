/*

  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF

  ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO

  THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A

  PARTICULAR PURPOSE.

  

    This is "Sample Code" and is distributable subject to the terms of the end user license agreement.

*/

// ****************************************************************************
// FILE: dvorak_classfactory.h
// ABSTRACT: Dvorak Input Method COM Class Factory CClassFactory header.
// **************************************************************************** 
 
#ifndef __IMCF_H__
#define __IMCF_H__



class CClassFactory : public IClassFactory
{
public:

    //
    // Ctor, Dtor
    //

    CClassFactory(REFCLSID rclsid);
    virtual ~CClassFactory();


    //
    // IUnknown methods
    //

    STDMETHOD(QueryInterface) (REFIID riid, LPVOID FAR* ppvObj);
    STDMETHOD_(ULONG,AddRef) (VOID);
    STDMETHOD_(ULONG,Release) (VOID);


    //
    // IClassFactory methods
    //

    STDMETHOD(CreateInstance) (IUnknown FAR* pUnkOuter, REFIID riid,
                               LPVOID FAR *ppunkObject);
    STDMETHOD(LockServer) (BOOL fLock);


protected:

    ULONG m_cRef;
    CLSID m_clsid;

};



#endif // __IMCF_H__
