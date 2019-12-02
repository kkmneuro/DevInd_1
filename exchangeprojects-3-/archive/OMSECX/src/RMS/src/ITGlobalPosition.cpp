#include "ITGlobalPosition.h"
#include "xlogger.h"

ITGlobalPosition::ITGlobalPosition()
{
  InitializeCriticalSection(&CS_GLOBALPOS);
}


void ITGlobalPosition::UpdatePosition(symbol& sym, 
									char side, 
									unsigned long filledPrice, 
									unsigned long filledQty, 
									double lfRealizedPnL,
									char PositionEffect)
{
	if (filledQty == 0 || filledPrice == 0)
		return;

  EnterCriticalSection(&CS_GLOBALPOS);

  std::map<std::string, GlobalPosition>::iterator iter = m_mapSymbolGlobalPos.find(sym.Contract);

  if (iter != m_mapSymbolGlobalPos.end())
  {
    // found. Update it
    GlobalPosition& ps = iter->second;

    if (PositionEffect == POSITION_OPENING_TRADE)
    {
      if (side == SIDE_BUY)
      {
        // Position is in same direction
        ps.m_ulLongPosition += filledQty;
        ps.m_ulTotalBuyVal += filledQty * filledPrice;

		if (ps.m_ulLongPosition != 0)
			ps.m_lfLongAvgPrice = ps.m_ulTotalBuyVal / ps.m_ulLongPosition;
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITGlobalPosition::UpdatePosition, m_ulLongPosition is 0" );
		}
      }
      else
      {
        // Position is in same direction
        ps.m_ulShortPosition += filledQty;
        ps.m_ulTotalSellVal += filledQty * filledPrice;

		if (ps.m_ulShortPosition != 0)
			ps.m_lfShortAvgPrice = ps.m_ulTotalSellVal / ps.m_ulShortPosition;
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITGlobalPosition::UpdatePosition, m_ulShortPosition is 0" );
		}
      }
    }
    else
    {
      // Closing trade. In this case the side is for the opening position order
      if (side == SIDE_BUY)
      {
          // Just subtract 
          ps.m_ulLongPosition -= filledQty;

          // the filled price is for the closed order in this case
          ps.m_ulTotalBuyVal -= filledPrice * filledQty;

		  if (ps.m_ulLongPosition == 0)
		  {
				ps.m_lfLongAvgPrice = 0;
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITGlobalPosition::UpdatePosition 1, m_ulLongPosition is 0" );
		  }
		  else
			ps.m_lfLongAvgPrice = ps.m_ulTotalBuyVal / ps.m_ulLongPosition;

      }
      else
      {
          // Just subtract 
          ps.m_ulShortPosition -= filledQty;

          // the filled price is for the closed order in this case
          ps.m_ulTotalSellVal -= filledPrice * filledQty;

		  if (ps.m_ulShortPosition == 0)
		  {
				ps.m_lfShortAvgPrice = 0;
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITGlobalPosition::UpdatePosition 1, m_ulShortPosition is 0" );
		  }
		  else
			ps.m_lfShortAvgPrice = ps.m_ulTotalSellVal / ps.m_ulShortPosition;
      }

	  ps.m_lfRealizedProfit += lfRealizedPnL;
    }
  }
  else
  {
    // Insert new position
    GlobalPosition pos;

    memset(&pos, 0, sizeof(pos));

    if (side == SIDE_BUY)
    {
      pos.m_ulLongPosition = filledQty;
      pos.m_ulTotalBuyVal = filledQty * filledPrice;
      pos.m_lfLongAvgPrice = filledPrice;
    }
    else
    {
      pos.m_ulShortPosition = filledQty;
      pos.m_ulTotalSellVal = filledQty * filledPrice;
      pos.m_lfShortAvgPrice = filledPrice;
    }

	std::pair<std::string, GlobalPosition> pr(sym.Contract, pos);
	m_mapSymbolGlobalPos.insert(pr);
  }

  LeaveCriticalSection(&CS_GLOBALPOS);
}


void ITGlobalPosition::GetPosition(symbol& sym, 
                          unsigned long& ulLongPos,
                          unsigned long& ultotalBuyVal,
                          unsigned long& ulshortPos,
                          unsigned long& ulTotalSellVal,
						  double&		   lgRealizedPnL,
                          double&        lfLongAvgPrice,
                          double&        lfShortAvgPrice)
{
  EnterCriticalSection(&CS_GLOBALPOS);

  std::map<std::string, GlobalPosition>::iterator iter = m_mapSymbolGlobalPos.find(sym.Contract);

  if (iter != m_mapSymbolGlobalPos.end())
  {
    GlobalPosition& pos = iter->second;

    ulLongPos = pos.m_ulLongPosition;
    ultotalBuyVal = pos.m_ulTotalBuyVal;
    ulshortPos = pos.m_ulShortPosition;
    ulTotalSellVal = pos.m_ulTotalSellVal;
    lfLongAvgPrice = pos.m_lfLongAvgPrice;
    lfShortAvgPrice = pos.m_lfShortAvgPrice; 
  }

  LeaveCriticalSection(&CS_GLOBALPOS);
}
