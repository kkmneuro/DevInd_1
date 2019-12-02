using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace clsInterface4OME
{
    public class DicW4<T, U>
    {
        public DicW4()
        {
            val1 = new List<T>();
            val2 = new List<U>();
            Count = 0;
        }
        public int Count;

        //public int Count
        //{
        //    get { return count; }
        //}
        public void Add(T t, U u)
        {
            val1.Add(t);
            val2.Add(u);
            Count++;
        }
        public bool Remove(T t, U u)
        {
            bool result = false;
            if (val1.Contains(t) && val2.Contains(u))
            {
                val1.Remove(t);
                val2.Remove(u);
                Count--;
                result = true;
            }
            return result;
        }
        public KeyValuePair<T, U> this[int indexrange]
        {
            get
            {
                if (indexrange < this.Count)
                {
                    return new KeyValuePair<T, U>(val1[indexrange], val2[indexrange]);
                }
                else
                {
                    throw new Exception("Invalid Index Value");
                }
            }
        }


        public List<T> val1;
        public List<U> val2;
    }
    [Serializable]
    public struct Tmpl4MarkDepth //: ISerializable
    {
        public int NoOfBidders;
        public int Qty;
        public double Price;

        public int NoOfBidders1
        {
            get
            {
                return NoOfBidders;
            }
        }
        public int Qty1
        {
            get
            {
                return Qty;
            }
        }

        public double Price1
        {
            get
            {
                return Price;
            }
        }


        public Tmpl4MarkDepth(int _NoOfBidder, int _Qty, double _Price)
        {
            this.NoOfBidders = _NoOfBidder;
            this.Qty = _Qty;
            this.Price = _Price;
        }
        public override string ToString()
        {
            return "NoOfBidders:-> " + NoOfBidders.ToString() + " QTY:-> " + Qty.ToString() + " Price:-> " + Price.ToString();
        }
        //public Tmpl4MarkDepth(SerializationInfo info, StreamingContext ctxt)
        //{
        //    NoOfBidders = (int)info.GetValue("NoOfBidders", typeof(int));
        //    Qty = (int)info.GetValue("Qty", typeof(int));
        //    Price = (double)info.GetValue("Price", typeof(double));
        //}
        //#region ISerializable Members

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("NoOfBidders", NoOfBidders);
        //    info.AddValue("Qty", Qty);
        //    info.AddValue("Price", Price);
        //}

        //#endregion
    }
    [Serializable]
    public struct Tmpl4MarkDepth4SLTP //: ISerializable
    {
        public int NoOfBidders;
        public int Qty;
        public double SLPrice;
        public double TPPrice;

        public int NoOfBidders1
        {
            get
            {
                return NoOfBidders;
            }
        }
        public int Qty1
        {
            get
            {
                return Qty;
            }
        }

        public double SLPrice1
        {
            get
            {
                return SLPrice;
            }
        }
        public double TPPrice1
        {
            get
            {
                return TPPrice;
            }
        }

        public Tmpl4MarkDepth4SLTP(int _NoOfBidder, int _Qty, double _SLPrice, double _TPPrice)
        {
            this.NoOfBidders = _NoOfBidder;
            this.Qty = _Qty;
            this.SLPrice = _SLPrice;
            this.TPPrice = _TPPrice;
        }
        //public Tmpl4MarkDepth4SLTP(int _NoOfBidder, int _Qty, double _Price)
        //{
        //    this.NoOfBidders = _NoOfBidder;
        //    this.Qty = _Qty;
        //    this.SLPrice = _Price;
        //}
        public override string ToString()
        {
            return " NoOfBidders:-> " + NoOfBidders.ToString() + " QTY:-> " + Qty.ToString() + " SL Price:-> " + SLPrice.ToString() + " TP Price:-> " + TPPrice.ToString();
        }
        
    } 
}
