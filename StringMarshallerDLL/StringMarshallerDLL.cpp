// StringMarshallerDLL.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "wtypes.h"
#include "OleAuto.h"
#include "comdef.h"
#include <vector>

static bstr_t s_lastSetVersion(L"[version not set]");

extern char * __stdcall GetVersionCharPtr()
{
	return s_lastSetVersion;
}

extern char * __stdcall GetVersionCharPtr_2()
{
	// Allocate memory for the string
	int length = strlen(s_lastSetVersion) + 1;
	char *lpv = (char *)CoTaskMemAlloc(length);
	strcpy_s(lpv, length, s_lastSetVersion);
	return lpv;
}

extern BSTR __stdcall GetVersionBSTR()
{
	return SysAllocString(s_lastSetVersion);
}

extern void __stdcall SetVersionCharPtr(const char *version)
{
	s_lastSetVersion = version;
}

extern void __stdcall SetVersionBSTR(BSTR version)
{
	s_lastSetVersion = version;
}

extern HRESULT __stdcall GetVersionCharPtrPtr(char **version)
{
	*version = s_lastSetVersion;
	return S_OK;
}

extern HRESULT __stdcall GetVersionBSTRPtr(BSTR *version)
{
	*version = SysAllocString(s_lastSetVersion);
	return S_OK;
}

wchar_t *s_Functionname = nullptr;

extern void __stdcall SetVersionA(char *version)
{
	s_Functionname = L"SetVersionA";
}

extern void __stdcall SetVersionW(wchar_t *version)
{
	s_Functionname = L"SetVersionW";
}

extern BSTR __stdcall GetLastVersionFunctionName()
{
	return SysAllocString(s_Functionname);
}

extern void __stdcall GetVersionBuffer(char *buffer, unsigned long *pSize)
{
	if (pSize == nullptr)
	{
		return;
	}

	unsigned long size = strlen(s_lastSetVersion) + 1;
	if ((buffer != nullptr) && (*pSize >= size))
	{
		strcpy_s(buffer, size, s_lastSetVersion);
	}
	// The string length including the zero terminator
	*pSize = size;
}

std::vector<std::wstring> s_strings;

extern void __stdcall SetStringArray(SAFEARRAY& safeArray)
{
	s_strings.clear();
	if (safeArray.cDims == 1)
	{
		if ((safeArray.fFeatures & FADF_BSTR) == FADF_BSTR)
		{
			BSTR* bstrArray;
			HRESULT hr = SafeArrayAccessData(&safeArray, (void**)&bstrArray);

			long iMin;
			SafeArrayGetLBound(&safeArray, 1, &iMin);
			long iMax;
			SafeArrayGetUBound(&safeArray, 1, &iMax);

			for (long i = iMin; i <= iMax; ++i)
			{
				s_strings.push_back(std::wstring(bstrArray[i]));
			}
		}
	}
}

extern void __stdcall GetStringArray(SAFEARRAY *&pSafeArray)
{
	if (s_strings.size() > 0)
	{
		SAFEARRAYBOUND  Bound;
		Bound.lLbound = 0;
		Bound.cElements = s_strings.size();

		pSafeArray = SafeArrayCreate(VT_BSTR, 1, &Bound);

		BSTR *pData;
		HRESULT hr = SafeArrayAccessData(pSafeArray, (void **)&pData);
		if (SUCCEEDED(hr))
		{
			for (DWORD i = 0; i < s_strings.size(); i++)
			{
				*pData++ = SysAllocString(s_strings[i].c_str());
			}
			SafeArrayUnaccessData(pSafeArray);
		}
	}
	else
	{
		pSafeArray = nullptr;
	}
}
