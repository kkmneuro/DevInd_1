#if !defined _TSTRING_H_
#define      _TSTRING_H_

#include <string>
#include <tchar.h>

#ifdef _UNICODE
typedef std::wstring tstring;
#else
typedef std::string tstring;
#endif

#endif;