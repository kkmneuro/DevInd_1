#include "stdafx.h"
#include <cctype>	// For isspace, tolower, toupper etc.
#include <cassert>
#include <algorithm>	// For std::transform()
#include "xstring_util.h"


#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif






/******************************************************************************/
std::string& stl::utility::strTrim(std::string &s,	ETrim e /*= ETrim_BOTH*/)
{
	// l records the new size after trimming
	std::string::size_type l = s.size();
	UINT i;

	if (l > 0)
	{
		if (e & ETrim_END)
		{
			// Chop space from end - easy!
			for (i=s.size()-1; i >= 1 && isspace(s[i]); --i) // should be upto i >= 1, instead of i >= 0
				--l;
			s.resize(l);
		}

		/* To trim the space at the start we copy the contents after the leading
		space to the start of the string, to 'cover' the space, then re-size */
		if (e & ETrim_START)
		{
			for (i=0; i < s.size() && isspace(s[i]); ++i)
				--l;
			for (UINT j=0; j < l; ++j, ++i)
				s[j] = s[i];
			s.resize(l);
		}
	}
	return s;
}

/******************************************************************************/
std::string& stl::utility::strToLower(std::string &s)
{
	std::transform(s.begin(), s.end(), s.begin(), tolower);
	return s;
}

std::string& stl::utility::strToUpper(std::string &s)
{
	std::transform(s.begin(), s.end(), s.begin(), toupper);
	return s;
}

/******************************************************************************/
bool stl::utility::strIsBlank(const std::string &s)
{
	for (UINT i=0; i<s.size(); ++i)
		if (!isspace(s[i]))
			return false;

	return true;
}

/******************************************************************************/
std::string& stl::utility::WriteL(std::string &s, long l)
{
	if (l == 0)
	{
		/* Special case if zero - need single digit '0'. The standard logic
		would write NO digits */
		s += '0';
	}
	else
	{
		bool pos = (l > 0);

		// Digit count (allows for sign if -ve)
		int n = (pos ? 0 : 1);
		int q;
		int r;

		// Count digits
		if (pos)
		{
			for (q = l ; q > 0; q /= 10, ++n)
				; // EMPTY
		}
		else
		{
			for (q = l ; q < 0; q /= 10, ++n)
				; // EMPTY
		}

		std::string::size_type len = s.size();
		s.resize(len + n);

		// Write digits - quickly!
		if (pos)
		{
			for (q = l; q > 0; q /= 10)
			{
				r = q%10;
				s[--n + len] = (r + '0');
			}
		}
		else
		{
			for (q = l; q < 0; q /= 10)
			{
				r = q%10;
				// ASSERT - sign of r is implementation-dependent
				assert(r <= 0);
				s[--n + len] = ('0' - r);
			}
		}

		// Don't forget the sign if negative...
		if (!pos)
			s[len] = '-';
	}

	return s;
}

/******************************************************************************/
std::string& stl::utility::WriteUL(std::string &s, unsigned long ul)
{
	if (ul == 0)
	{
		/* Special case if zero - need single digit '0'. The standard logic
		would write NO digits */
		s += '0';
	}
	else
	{
		int n = 0;
		unsigned long q;
		unsigned long r;

		// Count digits
		for (q = ul ; q > 0; q /= 10, ++n)
			; // EMPTY

		std::string::size_type len = s.size();
		s.resize(len + n);

		// Write digits - quickly!
		for (q = ul; q > 0; q /= 10)
		{
			r = q%10;
			s[--n + len] = (static_cast<char>(r) + '0');
		}
	}

	return s;
}