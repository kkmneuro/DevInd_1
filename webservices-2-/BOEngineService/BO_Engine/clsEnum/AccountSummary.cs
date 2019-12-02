using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clsInterface4OME
{
    /// <summary>
    /// Object of the class contains summary of particular account.
    /// </summary>
    public class AccountSummary
    {
        public AccountSummary(long AccountID, double balance, double UsedMargin, double dailyclosed, double _UsableCapital, double leverage)
        {
            _AccountID = AccountID;
            _Balance = balance;
            _Used_margin = UsedMargin;
            _dailyClosed = dailyclosed;
            UsableCapital = _UsableCapital;
            _Leverage = leverage;
            _OpenPnl = 0;
            _Equity = _Balance;
            _Free_margin = _Equity;
            _Leverage = leverage;
            setDerivedField();
            setDailyGain();
        }
        public AccountSummary(long AccountID, double balance, double UsedMargin, double dailyclosed, double leverage)
        {
            _AccountID = AccountID;
            _Balance = balance;
            _Used_margin = UsedMargin;
            _dailyClosed = dailyclosed;
            UsableCapital = 100;
            _OpenPnl = 0;
            _Equity = _Balance;
            _Free_margin = _Equity;
            _Leverage = leverage;
            setDerivedField();
            setDailyGain();
        }
        public AccountSummary(AccountSummary obj)
        {
            this._AccountID = obj._AccountID;
            this._Balance = obj._Balance;
            this._dailyClosed = obj._dailyClosed;
            this._dailyGain = obj._dailyGain;
            this._Equity = obj._Equity;
            this._Free_margin = obj._Free_margin;
            this._Leverage = obj._Leverage;
            this._OpenPnl = obj._OpenPnl;
            this._Used_margin = obj._Used_margin;
            this.UsableCapital = obj.UsableCapital;
            this._MarginLevel = obj.MarginLevel;
        }
        private long _AccountID;
        public long AccountID
        {
            get
            {
                return _AccountID;
            }
        }

        private double _Equity;
        public double Equity
        {
            get
            {
                return _Equity;
            }
        }

        private double _Balance;
        public double Balance
        {
            get
            {
                return _Balance;
            }
            set
            {
                _Balance = value;
                setDerivedField();
            }
        }

        private double _OpenPnl;
        public double OpenPnl
        {
            get
            {
                return _OpenPnl;
            }
            set
            {
                if (_OpenPnl == double.NaN)
                {
                    throw new Exception();
                }
                _OpenPnl = value;
                setDerivedField();
            }
        }

        private double _Used_margin;
        public double Used_margin
        {
            get
            {
                return _Used_margin;
            }
            set
            {
                _Used_margin = value;
                setDerivedField();
            }
        }

        private double _Free_margin;
        public double Free_margin
        {
            get
            {
                return _Free_margin;
            }
        }

        private double _Leverage;
        public double Leverage
        {
            get
            {
                return _Leverage;
            }
        }

        private double _dailyGain;
        public double DailyGain
        {
            get
            {
                return _dailyGain;
            }
        }

        private double _dailyClosed;
        public double DailyClosed
        {
            get
            {
                return _dailyClosed;
            }
            set
            {
                _dailyClosed = value;
                setDailyGain();
            }
        }

        private double _MarginLevel;
        public double MarginLevel
        {
            get
            {
                return _MarginLevel;
            }
        }

        public double UsableCapital;
        public double LiquidationLevel1;
        public double LiquidationLevel2;

        private void setDerivedField()
        {
            _Equity = _Balance + _OpenPnl;
            _Free_margin = _Equity - _Used_margin;
            if (_Used_margin > 0)
            {
                _MarginLevel = (_Equity * 100) / _Used_margin;
            }
            else
            {
                _MarginLevel = 0;
            }
        }
        private void setDailyGain()
        {
            if (Balance > 0)
            {
                _dailyGain = _dailyClosed * 100 / Balance;
            }
        }
    }
}
