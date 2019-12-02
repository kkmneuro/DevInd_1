#if !defined(AFX_XSTRING_UTILITY_H__C1EB2693_3B8D_11D2_AFDB_004F49028E56__INCLUDED_)
#define AFX_XSTRING_UTILITY_H__C1EB2693_3B8D_11D2_AFDB_004F49028E56__INCLUDED_


#include <string>
#include <comdef.h>	// Need this for BSTR<->std::string conversion




namespace stl
{
namespace utility
{

enum ETrim
{
	ETrim_START = 0x1,
	ETrim_END   = 0x2,
	ETrim_BOTH  = ETrim_START|ETrim_END
};

std::string& strTrim(std::string &s, ETrim e = ETrim_BOTH);

std::string& strToLower(std::string &s);

std::string & strToUpper(std::string &s);





inline bool strMatchIC(const std::string &s1, const std::string &s2)
{
	return (_stricmp(s1.c_str(), s2.c_str()) == 0);
}





inline int strCmpIC(const std::string &s1, const std::string &s2)
{
	return _stricmp(s1.c_str(), s2.c_str());
}





bool strIsBlank(const std::string &s);

bool ReadL(long &l, const char *&sz);





inline bool ReadL(long &l, int &pos, const std::string &s)
{
	bool ok = false;
	if (pos >= 0)
	{
		const char *sz = s.c_str() + pos;
		ok = ReadL(l, sz);
		pos = (sz - s.c_str());
	}
	return ok;
}

std::string& WriteL(std::string &s, long l);
std::string& WriteUL(std::string &s, unsigned long ul);





inline std::string& strLToStr(std::string &s, long l)
{
	s.resize(0);
	return WriteL(s, l);
}





inline std::string& strULToStr(std::string &s, unsigned long ul)
{
	s.resize(0);
	return WriteUL(s, ul);
}





inline void BStrToStr(std::string &s, const BSTR &bs)
{
	int len = ::SysStringLen(bs);
	char *buff = new char[len + 1];
	::WideCharToMultiByte(CP_ACP, 0, bs, len, buff, len, NULL, NULL);
	s.assign(buff, len);
	delete [] buff;
}





inline std::string& BSTRToString(const BSTR& bs, std::string& s)
{
	BStrToStr(s, bs);
	return s;
}





// DEPRECATED routines
inline std::string toStr(long l)
{
	static char sz[32];
	_ltoa_s(l, sz,32, 10);
	std::string s;
	s.assign(sz);
	return s;
}





inline std::string UlToStr(unsigned long ul)
{
	static char sz[32];
	_ultoa_s(ul, sz,32, 10);
	std::string s;
	s.assign(sz);
	return s;
}





inline std::string DblToStr(double d)
{
	static char sz[32];
	sprintf_s(sz,32, "%lf", d);
	std::string s;
	s.assign(sz);
	return s;
}





}
}


#endif // AFX_XSTRING_UTILITY_H__C1EB2693_3B8D_11D2_AFDB_004F49028E56__INCLUDED_